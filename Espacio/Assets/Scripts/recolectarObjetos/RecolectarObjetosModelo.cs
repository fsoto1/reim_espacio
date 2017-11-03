using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarObjetosModelo : RecolectarObjetosElement
{

    public float velocidad_jugador = 5f;
    private float velocidad_rotacion = 3f;
    private float tiempo_espera_inicio = 5f;
    private int oleada_total = 30;
    private float tiempo_espera_aparicion = 1.5f;
    private float tiempo_espera_oleada = 6f;
    private float velocidad_objetos = 2f;
    private int cantidad_colisiones;
    private bool finalizado;
    private float duracion;
    private int toques;
    private float duracion_toques;
    private string[] nombreColores;
    private int recolectados;
    private float velocidad_background = 0.1f;
    private int ayudas;
    private int erroresGen;
    private int aciertosGen;

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

    public string[] NombreColores
    {
        get
        {
            return nombreColores;
        }

        set
        {
            nombreColores = value;
        }
    }

    public int Recolectados
    {
        get
        {
            return recolectados;
        }

        set
        {
            recolectados = value;
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

    public int ErroresGen
    {
        get
        {
            return erroresGen;
        }

        set
        {
            erroresGen = value;
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
