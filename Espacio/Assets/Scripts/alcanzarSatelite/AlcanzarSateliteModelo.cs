﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcanzarSateliteModelo : AlcanzarSateliteElement
{

    public float jugador_velocidad = 5f;
    public float velocidad_rotacion = 5f;
    public int cantidad_asteroides = 5;
    private int cantidad_colisiones;
    private bool finalizado;
    private float duracion;
    private int toques;
    private float duracion_toques;
    private float minX = -5f;
    private float maxX = 6f;
    private float minY = -3f;
    private float maxY = 4f;
    private int ayudas;
    private int asteroidesGen;

    public float Jugador_velocidad
    {
        get
        {
            return jugador_velocidad;
        }

        set
        {
            jugador_velocidad = value;
        }
    }

    public float Velocidad_rotacion
    {
        get
        {
            return velocidad_rotacion;
        }

        set
        {
            velocidad_rotacion = value;
        }
    }

    public int Cantidad_asteroides
    {
        get
        {
            return cantidad_asteroides;
        }

        set
        {
            cantidad_asteroides = value;
        }
    }

    public int Cantidad_colisiones
    {
        get
        {
            return cantidad_colisiones;
        }

        set
        {
            cantidad_colisiones = value;
        }
    }

    public bool Finalizado
    {
        get
        {
            return finalizado;
        }

        set
        {
            finalizado = value;
        }
    }

    public float Duracion
    {
        get
        {
            return duracion;
        }

        set
        {
            duracion = value;
        }
    }

    public int Toques
    {
        get
        {
            return toques;
        }

        set
        {
            toques = value;
        }
    }

    public float Duracion_toques
    {
        get
        {
            return duracion_toques;
        }

        set
        {
            duracion_toques = value;
        }
    }

    public float MinX
    {
        get
        {
            return minX;
        }

        set
        {
            minX = value;
        }
    }

    public float MaxX
    {
        get
        {
            return maxX;
        }

        set
        {
            maxX = value;
        }
    }

    public float MinY
    {
        get
        {
            return minY;
        }

        set
        {
            minY = value;
        }
    }

    public float MaxY
    {
        get
        {
            return maxY;
        }

        set
        {
            maxY = value;
        }
    }

    public int Ayudas
    {
        get
        {
            return ayudas;
        }

        set
        {
            ayudas = value;
        }
    }

    public int AsteroidesGen
    {
        get
        {
            return asteroidesGen;
        }

        set
        {
            asteroidesGen = value;
        }
    }
}
