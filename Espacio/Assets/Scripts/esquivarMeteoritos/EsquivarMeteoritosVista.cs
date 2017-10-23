using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EsquivarMeteoritosVista : EsquivarMeteoritosElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;

    public void volverClick()
    {
        Debug.Log("Volver!");
        SceneManager.LoadScene("navegacion");
    }

    public void ayudaClick()
    {
        Debug.Log("Ayuda!");
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