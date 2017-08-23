using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour {
    int contador = 0;
    bool recogido;
    float tiempo;
    int touch = 0;
    float movimiento = 0;
    // Detecta la colision con objetos
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Space_object_O")
        {
            Destroy(collision.gameObject);
            recogido = true;
            SceneManager.LoadScene("alcanzarSatelite");
        }
        else
        {
            contador++;
            Debug.Log(contador);
            
        }
    }

    void Update()
    {
        tiempo = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            movimiento += Time.deltaTime;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch++;
            }   
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + contador+ " | Finalizado "+ recogido + " | Touch " + touch +" | Tiempo mov " + movimiento + " | Duracion " + tiempo, style);
    }
}
