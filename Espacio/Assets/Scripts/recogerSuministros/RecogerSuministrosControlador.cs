using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecogerSuministrosControlador : RecogerSuministrosElement
{

    private Vector3 coordenadas;
    private Vector3 posicion;
    private float velocidad = 1;
    public GameObject jugador;
    public void moverJugador()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
                posicion = Camera.main.ScreenToWorldPoint(coordenadas);
                jugador.transform.LookAt(posicion);
                jugador.transform.Rotate(new Vector3(0, 0, -90));
                jugador.transform.position = Vector3.Lerp(jugador.transform.position, posicion, velocidad * Time.deltaTime);
            }

        }
    }
    public GameObject asteroide1;
    public GameObject asteroide2;
    public GameObject asteroide3;
    public GameObject suministro;
    public int cantidad_asteroide;
    public int cantidad_suministro;

    void Start()
    {

        Invoke("generar_asteroide", 0);


        Invoke("generar_suministro", 0);


    }
    void generar_asteroide()
    {
        
        Vector3 posicion = new Vector3(Random.Range(-6, 6), Random.Range(-3, 1), 0);
        Instantiate(asteroide1, posicion, Quaternion.identity);

        /*
        else if (Random.Range(0, 2) == 1)
        {
            Instantiate(asteroide2, posicion, Quaternion.identity);
        }
        else
        {
            Instantiate(asteroide3, posicion, Quaternion.identity);
        }
        */
    }
    void generar_suministro()
    {

        Vector3 posicion = new Vector3(Random.Range(-6, 6), Random.Range(-3, 1), 0);
        Instantiate(suministro, posicion, Quaternion.identity);

    }
    private void Update()
    {
        moverJugador();
        asteroide1.transform.Translate(Vector3.left * Time.deltaTime , Space.World);
        asteroide2.transform.Translate(Vector3.left * Time.deltaTime);
        asteroide3.transform.Translate(Vector3.left * Time.deltaTime);
        suministro.transform.Translate(Vector3.left * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(asteroide1);
        Destroy(asteroide2);
        Destroy(asteroide3);
        Destroy(suministro);
    }

}
