using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionesOrdenarFigurasControlador : OrdenarFigurasElement
{
    private void OnTriggerEnter(Collider other)
    {
        if (name == "P1")
        {
            app.modelo.Posicion1 = true;
        }
        else if (name == "P2")
        {
            app.modelo.Posicion2 = true;
        }
        else if (name == "P3")
        {
            app.modelo.Posicion3 = true;
        }
        else if (name == "P4")
        {
            app.modelo.Posicion4 = true;
        }
        else if (name == "P5")
        {
            app.modelo.Posicion5 = true;
        }
        else if (name == "P6")
        {
            app.modelo.Posicion6 = true;
        }
        else if (name == "P7")
        {
            app.modelo.Posicion7 = true;
        }
        else if (name == "P8")
        {
            app.modelo.Posicion8 = true;
        }
        else if (name == "P9")
        {
            app.modelo.Posicion9 = true;
        }
        StartCoroutine(app.controlador.ordenaFigura());
    }

    private void OnTriggerExit(Collider other)
    {
        if (name == "P1")
        {
            app.modelo.Posicion1 = false;
        }
        else if (name == "P2")
        {
            app.modelo.Posicion2 = false;
        }
        else if (name == "P3")
        {
            app.modelo.Posicion3 = false;
        }
        else if (name == "P4")
        {
            app.modelo.Posicion4 = false;
        }
        else if (name == "P5")
        {
            app.modelo.Posicion5 = false;
        }
        else if (name == "P6")
        {
            app.modelo.Posicion6 = false;
        }
        else if (name == "P7")
        {
            app.modelo.Posicion7 = false;
        }
        else if (name == "P8")
        {
            app.modelo.Posicion8 = false;
        }
        else if (name == "P9")
        {
            app.modelo.Posicion9 = false;
        }
        StartCoroutine(app.controlador.ordenaFigura());
    }
}