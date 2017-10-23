using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    /*
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "esquivarMeteoritos")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado +
                " | Acelerometro " + app.modelo.Acelerometro + "\n | Duracion " + app.modelo.Duracion +
                " | Energia " + nav.modelo.Energia, style);

        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.name.Contains("Borde") && !collision.gameObject.name.Contains("Limite"))
        {
            SceneManager.LoadScene(collision.gameObject.name);
        }
        
    }


}