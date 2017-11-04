using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorControlador : AlcanzarSateliteElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    public AudioClip [] sonido;

    public void moverJugador()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (app.modelo.Duracion > 1f)
        {
            if (Input.touchCount == 1)
            {
                app.modelo.Duracion_toques += Time.deltaTime;               
                coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
                posicion = Camera.main.ScreenToWorldPoint(coordenadas);
                transform.LookAt(posicion);
                transform.Rotate(new Vector3(0, 0, -90));
                transform.position = Vector3.Lerp(transform.position, posicion, app.modelo.Jugador_velocidad * Time.deltaTime);
                
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    app.modelo.Toques++;
                }
            }
        }
        
    }

    public IEnumerator finalizar()
    {
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        SceneManager.LoadScene("alcanzarSatelite");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Satelite")
        {
            reproduceAudio(1);
            StartCoroutine(nav.general.enviarBd(nav.general.AlcanzarSatelite, app.modelo.Toques, app.modelo.Duracion_toques, app.modelo.Cantidad_colisiones, app.modelo.AsteroidesGen, 1, 1, 1, app.modelo.Ayudas, app.modelo.Duracion));
            app.modelo.Finalizado = true;
            nav.modelo.Energia++;
            Destroy(collision.gameObject);            
            StartCoroutine(finalizar());
        }
        else
        {
            app.modelo.Cantidad_colisiones++;
            reproduceAudio(0);
        }
    }

    private void reproduceAudio(int i)
    {
        GetComponent<AudioSource>().clip = sonido[i];
        GetComponent<AudioSource>().Play();
    }

    public void reiniciarValores()
    {
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Finalizado = false;
    }
    void FixedUpdate()
    {
        moverJugador();
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Start()
    {
        reiniciarValores();
    }
}
