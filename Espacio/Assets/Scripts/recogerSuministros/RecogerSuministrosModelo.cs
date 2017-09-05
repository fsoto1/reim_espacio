using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerSuministrosSateliteModelo : RecogerSuministrosElement
{

    public float jugador_velocidad = 5f;
    public float velocidad_rotacion = 5f;
    public int cantidad_asteroides = 5;
    private int cantidad_colisiones;
    private bool finalizado;
    private float duracion;
    private int toques;
    private float duracion_toques;
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
}
