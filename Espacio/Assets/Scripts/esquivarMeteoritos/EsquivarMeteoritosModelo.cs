using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquivarMeteoritosModelo : EsquivarMeteoritosElement
{

    public float velocidad_jugador = 15f;
    private float velocidad_rotacion = 3f;
    private float tiempo_espera_inicio = 5f;
    private int oleada_total = 30;
    private float tiempo_espera_aparicion = 0.5f;
    private float tiempo_espera_oleada = 3f;
    private float velocidad_objetos = 8f;
    private int cantidad_colisiones;
    private bool finalizado;
    private float duracion;
    private float min_posicion = -7.5f;
    private float max_posicion = 7.5f;
    private float acelerometro ;
    private int ayudas;
    private int meteoritosGen;

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

    public float Min_posicion
    {
        get
        {
            return min_posicion;
        }

        set
        {
            min_posicion = value;
        }
    }

    public float Max_posicion
    {
        get
        {
            return max_posicion;
        }

        set
        {
            max_posicion = value;
        }
    }

    public float Acelerometro
    {
        get
        {
            return acelerometro;
        }

        set
        {
            acelerometro = value;
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

    public int MeteoritosGen
    {
        get
        {
            return meteoritosGen;
        }

        set
        {
            meteoritosGen = value;
        }
    }
}

