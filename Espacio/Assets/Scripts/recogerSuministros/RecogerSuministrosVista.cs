using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecogerSuministrosVista : RecogerSuministrosElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;

    public Image negro;
    public Animator animador;

    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene("navegacion");
    }

    public void volverClick()
    {
        StartCoroutine(nav.general.enviarBd(nav.general.RecogerSuministros , app.modelo.Toques, app.modelo.Duracion_toques, app.modelo.Cantidad_colisiones, app.modelo.MeteoritosGen, app.modelo.Cantidad_suministros, app.modelo.SuministrosGen, 1, app.modelo.Ayudas, app.modelo.Duracion));
        nav.modelo.JugadorPosX = -17f;
        nav.modelo.JugadorPosY = -6f;
        StartCoroutine(faded());
    }

    public void ayudaClick()
    {
        app.modelo.Ayudas++;
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
        if (SceneManager.GetActiveScene().name == "recogerSuministros")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + 
                " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion + 
                " | Energia " + nav.modelo.Energia + "\n | Suministros " + app.modelo.Cantidad_suministros +
                " | Suministros " + app.modelo.SuministrosGen + "\n | Meteoritos " + app.modelo.MeteoritosGen, style);

        }
    }
}