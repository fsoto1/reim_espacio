using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JugadorRecogerSuministrosControlador : RecogerSuministrosControlador
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    public void moverJugador()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
            posicion = Camera.main.ScreenToWorldPoint(coordenadas);
            transform.position = Vector3.Lerp(transform.position, posicion, app.modelo.Velocidad_jugador * Time.deltaTime);
            app.modelo.Duracion_toques += Time.deltaTime;
                
     
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                app.modelo.Toques++;
            }
        }
    }

    private void Start()
    {
        app.modelo.Finalizado = false;
    }

    private void FixedUpdate()
    {
        moverJugador();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Suministro(Clone)")
        {
            Destroy(collision.gameObject);
            app.modelo.Cantidad_suministros++;

            if (app.modelo.Cantidad_suministros % 10 == 0)
            {
                nav.modelo.Energia++;
            }
        }
        else
        {
            app.modelo.Cantidad_colisiones++;            
        }
    }


}