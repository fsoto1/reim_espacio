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
    private bool botonSalir;
    private bool posicion1;
    private bool posicion2;
    private bool posicion3;
    private bool posicion4;
    private bool posicion5;
    private bool posicion6;
    private bool posicion7;
    private bool posicion8;
    private bool posicion9;
    private int pizarra;



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

    public bool BotonSalir
    {
        get
        {
            return botonSalir;
        }

        set
        {
            botonSalir = value;
        }
    }

    public bool Posicion1
    {
        get
        {
            return posicion1;
        }

        set
        {
            posicion1 = value;
        }
    }

    public bool Posicion2
    {
        get
        {
            return posicion2;
        }

        set
        {
            posicion2 = value;
        }
    }

    public bool Posicion3
    {
        get
        {
            return posicion3;
        }

        set
        {
            posicion3 = value;
        }
    }

    public bool Posicion4
    {
        get
        {
            return posicion4;
        }

        set
        {
            posicion4 = value;
        }
    }

    public bool Posicion5
    {
        get
        {
            return posicion5;
        }

        set
        {
            posicion5 = value;
        }
    }

    public bool Posicion6
    {
        get
        {
            return posicion6;
        }

        set
        {
            posicion6 = value;
        }
    }

    public bool Posicion7
    {
        get
        {
            return posicion7;
        }

        set
        {
            posicion7 = value;
        }
    }

    public bool Posicion8
    {
        get
        {
            return posicion8;
        }

        set
        {
            posicion8 = value;
        }
    }

    public bool Posicion9
    {
        get
        {
            return posicion9;
        }

        set
        {
            posicion9 = value;
        }
    }

    public int Pizarra
    {
        get
        {
            return pizarra;
        }

        set
        {
            pizarra = value;
        }
    }
}
