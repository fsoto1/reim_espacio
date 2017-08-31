using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AlcanzarSateliteVista  : AlcanzarSateliteElement
{
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + " | Touch " + app.modelo.Toques + " | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion, style);
    }
}