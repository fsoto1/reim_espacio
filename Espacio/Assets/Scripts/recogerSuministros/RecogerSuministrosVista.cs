using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RecogerSuministrosVista : RecogerSuministrosElement
{
    public void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion + " | Energia " + nav.modelo.Energia, style);
        /*
        if (app.modelo.Finalizado)
        {
            GUIStyle ss = new GUIStyle();
            ss.fontSize = 100;
            ss.normal.textColor = Color.white;
            GUI.Label(new Rect(110, 110, 100, 100), "Juego Finalizado ", ss);
        }*/
    }    
}