using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EsquivarMeteoritosVista : EsquivarMeteoritosElement
{
    public void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "esquivarMeteoritos")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + 
                " | Acelerometro " + app.modelo.Acelerometro + "\n | Duracion " + app.modelo.Duracion + 
                " | Energia " + nav.modelo.Energia , style);

        }
    }
}