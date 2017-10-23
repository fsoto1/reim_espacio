﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionControlador : NavegacionElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private float velocidad = 2.0f;
    private GameObject jugador;
    //private GameObject alcanzarSatelite;
    private Vector3 offset;
    public Camera camara;
    public GameObject limite1;
    public GameObject limite1Visual;
    public GameObject limite2;
    public GameObject limite2Visual;

    public void moverJugador()
    {
        if (Input.touchCount == 1)
        {
           // Debug.Log("Posicion X "+Input.GetTouch(0).position.x+ "  Y "+ Input.GetTouch(0).position.y);
            coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5.0f);
            posicion = Camera.main.ScreenToWorldPoint(coordenadas);
            jugador.transform.LookAt(posicion);
            jugador.transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
            
            jugador.transform.position = Vector3.Lerp(jugador.transform.position, posicion, velocidad * Time.deltaTime);
            //jugador.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //jugador.transform.position= new Vector3(jugador.transform.position.x, jugador.transform.position, -90);
            //Vector3.

        }
        
    }
    
    private void FixedUpdate()
    {
        camara.transform.position = jugador.transform.position + offset;
        moverJugador();
    }

    private void Update()
    {
        Debug.Log(jugador.GetComponent<Rigidbody>().velocity);
        jugador.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Start()
    {
        // currentCameraIndex = 0;
        jugador = GameObject.Find("Player");
        limite1 = GameObject.Find("Limite1");
        limite1Visual = GameObject.Find("Limite1Visual");
        limite2 = GameObject.Find("Limite2");
        limite2Visual = GameObject.Find("Limite2Visual");
        if (nav.modelo.Energia >= 5)
        {
            Destroy(limite1);
            Destroy(limite1Visual);
        }
        if (nav.modelo.Energia >= 10)
        {
            Destroy(limite2);
            Destroy(limite2Visual);
        }
        jugador.transform.position = new Vector3(-20f, 0.0f, 0.0f);
        camara.transform.position = new Vector3(-20f, 0.0f, -5.0f);
        //alcanzarSatelite = GameObject.Find("AS");
        offset = camara.transform.position - jugador.transform.position;
        Debug.Log(offset);

    }
}
