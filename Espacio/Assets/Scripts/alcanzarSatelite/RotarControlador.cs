﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarControlador : AlcanzarSateliteControlador
{
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
    }
}