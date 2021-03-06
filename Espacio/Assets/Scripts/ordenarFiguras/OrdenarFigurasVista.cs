﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrdenarFigurasVista  : OrdenarFigurasElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;
    public AudioClip info;
    public Image negro;
    public Animator animador;

    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene("navegacion");
    }

    public void volverClick()
    {
        app.modelo.BotonSalir = true;
        nav.modelo.JugadorPosX = 5f;
        nav.modelo.JugadorPosY = -6f;
        StartCoroutine(faded());
    }

    public void ayudaClick()
    {
        app.modelo.Ayudas++;
        GetComponent<AudioSource>().clip = info;
        GetComponent<AudioSource>().Play();
    }

    private void Start()
    {
        barra.value = calcular();
    }

    private void LateUpdate()
    {

        barra.value = calcular();
    }
    private float calcular()
    {
        return nav.modelo.Energia / nav.modelo.MaxEnergia;
    }

    public void OnGUI()
    {
        if (SceneManager.GetActiveScene().name =="ordenarFiguras1")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            if (app.modelo.Finalizado)
            {
                style.normal.textColor = Color.green;
            }
            else
            {
                style.normal.textColor = Color.white;
            }            
            GUI.Label(new Rect(0, 0, 100, 100), " | Finalizado " + app.modelo.Finalizado + " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion + " | Energia " + nav.modelo.Energia, style);

            GUI.Label(new Rect(0, 200, 100, 100), " | P1 " + app.modelo.Posicion1 +
                                                  " | P2 " + app.modelo.Posicion2 +
                                                  " | P3 " + app.modelo.Posicion3 +
                                                  "\n | P4 " + app.modelo.Posicion4 +
                                                  " | P5 " + app.modelo.Posicion5 +
                                                  " | P6 " + app.modelo.Posicion6 +
                                                  "\n | P7 " + app.modelo.Posicion7 +
                                                  " | P8 " + app.modelo.Posicion8 +
                                                  " | P9 " + app.modelo.Posicion9 


                , style);

            GUI.Label(new Rect(0, 400, 100, 100), " | P1 " + app.modelo.CantP1 +
                                                  " | P2 " + app.modelo.CantP2 +
                                                  " | P3 " + app.modelo.CantP3 +
                                                  "\n | P4 " + app.modelo.CantP4 +
                                                  " | P5 " + app.modelo.CantP5 +
                                                  " | P6 " + app.modelo.CantP6 +
                                                  "\n | P7 " + app.modelo.CantP7 +
                                                  " | P8 " + app.modelo.CantP8 +
                                                  " | P9 " + app.modelo.CantP9


                , style);
        }
    }    
}