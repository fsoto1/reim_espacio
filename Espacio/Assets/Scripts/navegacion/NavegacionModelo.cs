﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionModelo : NavegacionElement
{

    private float energia;
    private float maxEnergia = 15f;
    private float velocidad_background = 0.25f;
    private float velocidadRotacion = 20f;
    private float duracionNav;
    private int toquesNav;
    private float duracionToquesNav;
    private int ayudasNav;
    private float jugadorPosX = -20f;
    private float jugadorPosY = 0f;
    private int choqueBorde;



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

    public float VelocidadRotacion
    {
        get
        {
            return velocidadRotacion;
        }

        set
        {
            velocidadRotacion = value;
        }
    }

    public float DuracionNav
    {
        get
        {
            return duracionNav;
        }

        set
        {
            duracionNav = value;
        }
    }

    public int ToquesNav
    {
        get
        {
            return toquesNav;
        }

        set
        {
            toquesNav = value;
        }
    }

    public float DuracionToquesNav
    {
        get
        {
            return duracionToquesNav;
        }

        set
        {
            duracionToquesNav = value;
        }
    }

    public int AyudasNav
    {
        get
        {
            return ayudasNav;
        }

        set
        {
            ayudasNav = value;
        }
    }

    public float JugadorPosX
    {
        get
        {
            return jugadorPosX;
        }

        set
        {
            jugadorPosX = value;
        }
    }

    public float JugadorPosY
    {
        get
        {
            return jugadorPosY;
        }

        set
        {
            jugadorPosY = value;
        }
    }

    public int ChoqueBorde
    {
        get
        {
            return choqueBorde;
        }

        set
        {
            choqueBorde = value;
        }
    }
}