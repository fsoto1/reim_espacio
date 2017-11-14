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
    public Image negro;
    public Animator animador;
    public GameObject panel;
    public AudioClip info;

    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene("login");
    }

    public void volverClick()
    {
        panel.SetActive(true);
    }

    private IEnumerator audioAyuda()
    {
        yield return new WaitForSeconds(info.length);
    }

    public void ayudaClick()
    {
        nav.modelo.AyudasNav++;
        GetComponent<AudioSource>().clip = info;
        GetComponent<AudioSource>().Play();
    }

    public void salirAceptar()
    {
        StartCoroutine(nav.general.enviarBd(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 1, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
        StartCoroutine(faded());
    }

    public void salirCancelar()
    {
        panel.SetActive(false);
    }

    private void Start()
    {
        barra.value = calcular();
        nav.modelo.AyudasNav = 0;
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
        if (SceneManager.GetActiveScene().name == "navegacion1")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.green;
            GUI.Label(new Rect(0, 0, 100, 100), " | Touch " + nav.modelo.ToquesNav + " Tiempo mov " + nav.modelo.DuracionToquesNav +
                " | Duracion " + nav.modelo.DuracionNav + " | Energia " + nav.modelo.Energia+ " \n Alumno : " + nav.general.IdAlumno + " Sesion : " + nav.general.IdSesion  +" | Ayudas " + nav.modelo.AyudasNav, style);

        }
    }

}