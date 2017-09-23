using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerSuministrosModelo : RecogerSuministrosElement
{

    public float velocidad_jugador = 5f;
    private float velocidad_rotacion = 3f;
    private float tiempo_espera_inicio = 2f;
    private int oleada_total = 100;
    private float tiempo_espera_aparicion = 1f;
    private float tiempo_espera_oleada = 5f;
    private float velocidad_objetos = 3f;
    private int cantidad_colisiones;
    private bool finalizado;
    private float duracion;
    private int toques;
    private float duracion_toques;
    private int cantidad_suministros;

    public float Velocidad_jugador
    {
        get
        {
            return velocidad_jugador;
        }

        set
        {
            velocidad_jugador = value;
        }
    }

    public float Tiempo_espera_inicio
    {
        get
        {
            return tiempo_espera_inicio;
        }

        set
        {
            tiempo_espera_inicio = value;
        }
    }

    public int Oleada_total
    {
        get
        {
            return oleada_total;
        }

        set
        {
            oleada_total = value;
        }
    }

    public float Tiempo_espera_aparicion
    {
        get
        {
            return tiempo_espera_aparicion;
        }

        set
        {
            tiempo_espera_aparicion = value;
        }
    }

    public float Tiempo_espera_oleada
    {
        get
        {
            return tiempo_espera_oleada;
        }

        set
        {
            tiempo_espera_oleada = value;
        }
    }

    public float Velocidad_objetos
    {
        get
        {
            return velocidad_objetos;
        }

        set
        {
            velocidad_objetos = value;
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

    public int Cantidad_suministros
    {
        get
        {
            return cantidad_suministros;
        }

        set
        {
            cantidad_suministros = value;
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
}
