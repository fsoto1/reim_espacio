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
    public Image negro;
    public Animator animador;
    public AudioClip info;

    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene("navegacion");
    }

    public void volverClick()
    {
        StartCoroutine(nav.general.enviarBd(nav.general.EsquivarMeteoritos, 0, 0f, app.modelo.Cantidad_colisiones, app.modelo.MeteoritosGen, 0, 0, 1, app.modelo.Ayudas, app.modelo.Duracion));
        nav.modelo.JugadorPosX = 23f;
        nav.modelo.JugadorPosY = 3f;
        StartCoroutine(faded());
    }

    public void ayudaClick()
    {
        app.modelo.Ayudas++;
        GetComponent<AudioSource>().clip = info;
        GetComponent<AudioSource>().Play();
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
        if (SceneManager.GetActiveScene().name == "esquivarMeteoritos1")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + 
                " | Acelerometro " + app.modelo.Acelerometro + "\n | Duracion " + app.modelo.Duracion + 
                " | Energia " + nav.modelo.Energia + " | Generados" + app.modelo.MeteoritosGen, style);

        }
    }
}