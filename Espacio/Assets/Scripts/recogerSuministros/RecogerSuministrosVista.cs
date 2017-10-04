using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RecogerSuministrosVista : RecogerSuministrosElement
{
    public void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "recogerSuministross")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + 
                " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion + 
                " | Energia " + nav.modelo.Energia + "\n | Suministros " + app.modelo.Cantidad_suministros, style);

        }
    }
}