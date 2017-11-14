using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlcanzarSateliteControlador : AlcanzarSateliteElement
{
    public GameObject asteroide1;
    public GameObject asteroide2;
    public GameObject asteroide3;
    public GameObject satelite;
    public int cantidadMin;
    public int cantidadMax;
    private int random;
    private Vector3 posicion_partida;
    private Quaternion rotacion_partida;

    private void generar()
    {
        posicion_partida = new Vector3(Random.Range(app.modelo.MinX, app.modelo.MaxX), Random.Range(app.modelo.MinY, app.modelo.MaxY), 0);
        rotacion_partida = Quaternion.identity;
        GameObject clone;
        random = Random.Range(0, 2);
        if (random == 0)
        {
            clone = Instantiate(asteroide1, posicion_partida, rotacion_partida) as GameObject;
        }
        else if (random == 1)
        {
            clone = Instantiate(asteroide2, posicion_partida, rotacion_partida) as GameObject;
        }
        else
        {
            clone = Instantiate(asteroide3, posicion_partida, rotacion_partida) as GameObject;
        }
        //clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down * app.modelo.Velocidad_objetos);
        clone.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
        clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void toques()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            app.modelo.Duracion_toques += Time.deltaTime;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                app.modelo.Toques++;
            }
        }
    }
    public void reiniciarValores()
    {
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Ayudas = 0;
        app.modelo.AsteroidesGen = 0;
        app.modelo.Finalizado = false;
    }

    private void Start()
    {
        satelite.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
        app.modelo.AsteroidesGen = Random.Range(cantidadMin, cantidadMax);

        for (int i = 0; i < app.modelo.AsteroidesGen; i++)
        {
            Invoke("generar", 0);
        }
    }

}
