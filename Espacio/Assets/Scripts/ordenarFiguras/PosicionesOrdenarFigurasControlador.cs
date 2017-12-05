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
            app.modelo.CantP1++;
        }
        else if (name == "P2")
        {
            app.modelo.Posicion2 = true;
            app.modelo.CantP2++;
        }
        else if (name == "P3")
        {
            app.modelo.Posicion3 = true;
            app.modelo.CantP3++;
        }
        else if (name == "P4")
        {
            app.modelo.Posicion4 = true;
            app.modelo.CantP4++;
        }
        else if (name == "P5")
        {
            app.modelo.Posicion5 = true;
            app.modelo.CantP5++;
        }
        else if (name == "P6")
        {
            app.modelo.Posicion6 = true;
            app.modelo.CantP6++;
        }
        else if (name == "P7")
        {
            app.modelo.Posicion7 = true;
            app.modelo.CantP7++;
        }
        else if (name == "P8")
        {
            app.modelo.Posicion8 = true;
            app.modelo.CantP8++;
        }
        else if (name == "P9")
        {
            app.modelo.Posicion9 = true;
            app.modelo.CantP9++;
        }
        StartCoroutine(app.controlador.ordenaFigura());
    }

    private void OnTriggerExit(Collider other)
    {
        if (name == "P1")
        {
            if (app.modelo.CantP1 == 1)
            {
                app.modelo.Posicion1 = false;
            }
            
            app.modelo.CantP1--;
        }
        else if (name == "P2")
        {
            if (app.modelo.CantP2 == 1)
            {
                app.modelo.Posicion2 = false;
            }
            app.modelo.CantP2--;
        }
        else if (name == "P3")
        {
            if (app.modelo.CantP3 == 1)
            {
                app.modelo.Posicion3 = false;
            }
            app.modelo.CantP3--;
        }
        else if (name == "P4")
        {
            if (app.modelo.CantP4 == 1)
            {
                app.modelo.Posicion4 = false;
            }
            app.modelo.CantP4--;
        }
        else if (name == "P5")
        {
            if (app.modelo.CantP5 == 1)
            {
                app.modelo.Posicion5 = false;
            }
            app.modelo.CantP5--;
        }
        else if (name == "P6")
        {
            if (app.modelo.CantP6 == 1)
            {
                app.modelo.Posicion6 = false;
            }
            app.modelo.CantP6--;
        }
        else if (name == "P7")
        {
            if (app.modelo.CantP7 == 1)
            {
                app.modelo.Posicion7 = false;
            }
            app.modelo.CantP7--;
        }
        else if (name == "P8")
        {
            if (app.modelo.CantP8 == 1)
            {
                app.modelo.Posicion8 = false;
            }
            app.modelo.CantP8--;
        }
        else if (name == "P9")
        {
            if (app.modelo.CantP9 == 1)
            {
                app.modelo.Posicion9 = false;
            }
            app.modelo.CantP9--;
        }
        StartCoroutine(app.controlador.ordenaFigura());
    }


 
}