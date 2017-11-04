using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlcanzarSateliteVista  : AlcanzarSateliteElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;

    public Image negro;
    public Animator animador;

    
    public void OnGUI()
    {
        if (SceneManager.GetActiveScene().name =="alcanzarSatelite")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + 
                " | Duracion " + app.modelo.Duracion + " | Energia " + nav.modelo.Energia + "\n | Ayudas " + app.modelo.Ayudas, style);

        }
    }


    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene("navegacion");
    }

    public void volverClick()
    {
       StartCoroutine(nav.general.enviarBd(nav.general.AlcanzarSatelite, app.modelo.Toques, app.modelo.Duracion_toques, app.modelo.Cantidad_colisiones, app.modelo.AsteroidesGen, 0, 1, 0, app.modelo.Ayudas, app.modelo.Duracion));
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
}