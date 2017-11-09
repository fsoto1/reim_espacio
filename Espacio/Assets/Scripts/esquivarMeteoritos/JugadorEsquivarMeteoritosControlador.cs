using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JugadorEsquivarMeteoritosControlador : EsquivarMeteoritosElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private Gyroscope gyro;
    private Quaternion rotacion;
    public AudioClip energiaClip;
    public AudioClip choqueClip;

    public void moverJugador()
    {
        

        posicion.x = Input.acceleration.x;
        app.modelo.Acelerometro = posicion.x;


        if (transform.position.x >= app.modelo.Min_posicion && transform.position.x <= app.modelo.Max_posicion)
        {
            transform.Translate(posicion * Time.deltaTime * app.modelo.Velocidad_jugador);
        }
        else if (transform.position.x <= app.modelo.Min_posicion && posicion.x > 0)
        {
            transform.Translate(posicion * Time.deltaTime * app.modelo.Velocidad_jugador);
        }
        else if (transform.position.x >= app.modelo.Max_posicion && posicion.x < 0)
        {
            transform.Translate(posicion * Time.deltaTime * app.modelo.Velocidad_jugador);
        }
    }

    public IEnumerator ganarEnergia()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            nav.modelo.Energia++;
            GetComponent<AudioSource>().clip = energiaClip;
            GetComponent<AudioSource>().Play();
        }
    }

    private void Start()
    {
        app.modelo.Finalizado = false;
        StartCoroutine(ganarEnergia());
    }

    private void FixedUpdate()
    {
        moverJugador();
    }

    private void OnCollisionEnter(Collision collision)
    {

        app.modelo.Cantidad_colisiones++;
        Vector3 dir = collision.contacts[0].point - transform.position;
        dir = -dir.normalized;
        GetComponent<Rigidbody>().AddForce(dir * 50f);
        GetComponent<AudioSource>().clip = choqueClip;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().clip = choqueClip;
        GetComponent<AudioSource>().Play();
    }


}