using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrastrarOrdenarFigurasControlador : OrdenarFigurasElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private float velocidad = app.modelo.Jugador_velocidad;

    private void OnMouseDrag()
    {
        coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
        posicion = Camera.main.ScreenToWorldPoint(coordenadas);
        //transform.LookAt(posicion);
        //transform.Rotate(new Vector3(0, 0, -90));
        transform.position = Vector3.Lerp(transform.position, posicion, velocidad * Time.deltaTime);
    }

    
    
   
}
