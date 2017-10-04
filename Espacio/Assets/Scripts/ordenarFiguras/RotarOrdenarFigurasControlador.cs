using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarOrdenarFigurasControlador : OrdenarFigurasControlador
{
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
    }
}