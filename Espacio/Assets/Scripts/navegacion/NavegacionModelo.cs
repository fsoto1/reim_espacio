using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionModelo : NavegacionElement
{

    private float energia;
    private float maxEnergia = 15f;
    private float velocidad_background = 0.25f;

    public float Energia
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

    public float MaxEnergia
    {
        get
        {
            return maxEnergia;
        }

        set
        {
            maxEnergia = value;
        }
    }
}