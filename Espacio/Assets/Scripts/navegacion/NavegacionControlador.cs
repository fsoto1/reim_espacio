using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionControlador : NavegacionElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private float velocidad = 2;
    public GameObject jugador;

    public void moverJugador()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
                posicion = Camera.main.ScreenToWorldPoint(coordenadas);
                jugador.transform.LookAt(posicion);
                jugador.transform.Rotate(new Vector3(0, 0, -90));
                jugador.transform.position = Vector3.Lerp(jugador.transform.position, posicion, velocidad * Time.deltaTime);
            }

        }
    }
    private void Update()
    {
        moverJugador();
    }

}
