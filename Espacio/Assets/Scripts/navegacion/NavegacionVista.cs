using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavegacionVista : NavegacionElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;

    public void volverClick()
    {
        StartCoroutine(nav.general.enviarBd(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 1, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
        SceneManager.LoadScene("login");
    }

    public void ayudaClick()
    {
        nav.modelo.AyudasNav++;
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
        if (SceneManager.GetActiveScene().name == "navegacion")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(0, 0, 100, 100), " | Touch " + nav.modelo.ToquesNav + " Tiempo mov " + nav.modelo.DuracionToquesNav +
                " | Duracion " + nav.modelo.DuracionNav + " | Energia " + nav.modelo.Energia+ " \n ALUMNO: " + nav.general.IdAlumno + " | Ayudas " + nav.modelo.AyudasNav, style);

        }
    }

}