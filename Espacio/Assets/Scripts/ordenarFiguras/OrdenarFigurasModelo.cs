using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenarFigurasModelo : OrdenarFigurasElement
{

    public float jugador_velocidad = 5f;
    public float velocidad_rotacion = 5f;
    private bool finalizado;
    private float duracion;
    private int toques;
    private float duracion_toques;
    private bool recompensa;    
    private int ayudas;
    private int aciertos;
    private int aciertosGen;

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

    public bool Recompensa
    {
        get
        {
            return recompensa;
        }

        set
        {
            recompensa = value;
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

    public int Aciertos
    {
        get
        {
            return aciertos;
        }

        set
        {
            aciertos = value;
        }
    }

    public int AciertosGen
    {
        get
        {
            return aciertosGen;
        }

        set
        {
            aciertosGen = value;
        }
    }
}
