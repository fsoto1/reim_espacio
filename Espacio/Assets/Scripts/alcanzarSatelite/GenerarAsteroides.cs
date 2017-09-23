using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarAsteroides : AlcanzarSateliteVista
{
    public GameObject asteroide1;
    public GameObject asteroide2;
    public GameObject asteroide3;
    public int cantidad;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < cantidad; i++)
        {
            Invoke("generar", 0);
        }
    }
    // Update is called once per frame
    void generar () {
 
        Vector3 posicion = new Vector3(Random.Range(-5, 6), Random.Range(-3, 4), 0);
        if (Random.Range(0,2) == 0)
        {
            Instantiate(asteroide1, posicion, Quaternion.identity);
        }
        else if (Random.Range(0, 2) == 1)
        {
            Instantiate(asteroide2, posicion, Quaternion.identity);
        }
        else
        {
            Instantiate(asteroide3, posicion, Quaternion.identity);
        }
        
    }
}
