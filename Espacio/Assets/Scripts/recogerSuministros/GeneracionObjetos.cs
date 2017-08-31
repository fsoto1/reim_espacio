using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionObjetos : MonoBehaviour {
    public GameObject asteroide1;
    public GameObject asteroide2;
    public GameObject asteroide3;
    public GameObject suministro;
    public int cantidad_asteroide;
    public int cantidad_suministro;

    void Start()
    {
        for (int i = 0; i < cantidad_asteroide; i++)
        {
            Invoke("generar_asteroide", 0);
        }
        for (int j = 0; j < cantidad_suministro; j++)
        {
            Invoke("generar_suministro", 0);
        }

    }
    void generar_asteroide()
    {

        Vector3 posicion = new Vector3(Random.Range(-6, 6), Random.Range(-3, 1), 0);
        if (Random.Range(0, 2) == 0)
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
    void generar_suministro()
    {

        Vector3 posicion = new Vector3(Random.Range(-6, 6), Random.Range(-3, 1), 0);
        Instantiate(suministro, posicion, Quaternion.identity);

    }
}
