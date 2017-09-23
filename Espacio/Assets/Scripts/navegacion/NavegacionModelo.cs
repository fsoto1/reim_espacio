using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionModelo : NavegacionElement
{

    private int energia;
    private float velocidad_background = 0.25f;

    public int Energia
    {
        get
        {
            return energia;
        }

        set
        {
            energia = value;
        }
    }

    public float Velocidad_background
    {
        get
        {
            return velocidad_background;
        }

        set
        {
            velocidad_background = value;
        }
    }
}