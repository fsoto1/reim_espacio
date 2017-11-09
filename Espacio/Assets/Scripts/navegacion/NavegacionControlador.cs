using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionControlador : NavegacionElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private float velocidad = 1.5f;
    private GameObject jugador;
    private Vector3 offset;
    public Camera camara;
    private GameObject limite1;
    private GameObject limite1Visual;
    private GameObject limite2;
    private GameObject limite2Visual;

    private GameObject actividad1;
    private GameObject actividad2;
    private GameObject actividad3;
    private GameObject actividad4;
    private GameObject actividad5;


    public void moverJugador()
    {
        nav.modelo.DuracionNav = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            nav.modelo.DuracionToquesNav += Time.deltaTime;
            coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5.0f);
            posicion = Camera.main.ScreenToWorldPoint(coordenadas);
            jugador.transform.LookAt(posicion);
            jugador.transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
            jugador.transform.position = Vector3.Lerp(jugador.transform.position, posicion, velocidad * Time.deltaTime);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                nav.modelo.ToquesNav++;
            }
        }
        
    }

    private void rotarPortales() {
        actividad1.transform.Rotate(Vector3.up * Time.deltaTime * nav.modelo.VelocidadRotacion);
        actividad2.transform.Rotate(Vector3.up * Time.deltaTime * nav.modelo.VelocidadRotacion);
        actividad3.transform.Rotate(Vector3.up * Time.deltaTime * nav.modelo.VelocidadRotacion);
        actividad4.transform.Rotate(Vector3.up * Time.deltaTime * nav.modelo.VelocidadRotacion);
        actividad5.transform.Rotate(Vector3.up * Time.deltaTime * nav.modelo.VelocidadRotacion);
    }
    
    private void FixedUpdate()
    {
        camara.transform.position = jugador.transform.position + offset;
        moverJugador();
        rotarPortales();
    }

    private void Update()
    {
        jugador.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void reiniciarValores()
    {
        nav.modelo.DuracionNav = 0f;
        nav.modelo.ToquesNav = 0;
        nav.modelo.DuracionToquesNav = 0;
        nav.modelo.AyudasNav = 0;
    }


    private void Start()
    {
        reiniciarValores();
        jugador = GameObject.Find("Player");
        limite1 = GameObject.Find("Limite1");
        limite1Visual = GameObject.Find("Limite1Visual");
        limite2 = GameObject.Find("Limite2");
        limite2Visual = GameObject.Find("Limite2Visual");

        actividad1 = GameObject.Find("alcanzarSatelite");
        actividad2 = GameObject.Find("recolectarObjetos");
        actividad3 = GameObject.Find("recogerSuministros");
        actividad4 = GameObject.Find("ordenarFiguras");
        actividad5 = GameObject.Find("esquivarMeteoritos");

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
        //jugador.transform.position = new Vector3(-20f, 0.0f, 0.0f);
        jugador.transform.position = new Vector3(nav.modelo.JugadorPosX, nav.modelo.JugadorPosY, 0.0f);
        camara.transform.position = new Vector3(nav.modelo.JugadorPosX, nav.modelo.JugadorPosY, -5.0f);
        offset = camara.transform.position - jugador.transform.position;
    }
}
