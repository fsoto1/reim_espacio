using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorControlador : AlcanzarSateliteElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private float velocidad = app.modelo.Jugador_velocidad;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
                posicion = Camera.main.ScreenToWorldPoint(coordenadas);
                transform.LookAt(posicion);
                transform.Rotate(new Vector3(0, 0, -90));
                transform.position = Vector3.Lerp(transform.position, posicion, velocidad * Time.deltaTime);
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Space_object_O")
        {
            Destroy(collision.gameObject);
            app.modelo.Finalizado = true;
            SceneManager.LoadScene("alcanzarSatelite");
        }
        else
        {
            app.modelo.Cantidad_colisiones++;
        }
    }
}
