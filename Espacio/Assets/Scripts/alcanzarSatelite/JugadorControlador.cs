using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorControlador : AlcanzarSateliteControlador
{
    private Vector3 coordenadas;
    private Vector3 posicion;

    public void moverJugador()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
                posicion = Camera.main.ScreenToWorldPoint(coordenadas);
                transform.LookAt(posicion);
                transform.Rotate(new Vector3(0, 0, -90));
                transform.position = Vector3.Lerp(transform.position, posicion, app.modelo.Jugador_velocidad * Time.deltaTime);
            }

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Satelite")
        {
            app.modelo.Finalizado = true;
            nav.modelo.Energia++;
            Destroy(collision.gameObject);
            SceneManager.LoadScene("alcanzarSatelite");
            
           

        }
        else
        {
            app.modelo.Cantidad_colisiones++;
        }
    }

    void FixedUpdate()
    {
        moverJugador();
        toques();
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
