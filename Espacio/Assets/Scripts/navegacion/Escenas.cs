using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escenas : NavegacionElement
{
    public Animator animador;
    public Image negro;
    private string escena;
    public AudioClip entrar;
    public AudioClip pideEnergia;
    public AudioClip choque;
    public AudioClip info;
    public Image sliderBG;
    public Image sliderFill;
    private Color background;
    private Color fill;

    private bool puerta = true;

    private void OnCollisionEnter(Collision collision)
    {
        escena = collision.gameObject.name;
        if (!escena.Contains("Borde") && !escena.Contains("Limite") && puerta)
        {
            puerta = false;
            if (escena == "alcanzarSatelite")
            {
                // nav.modelo.Energia -= 1;
                StartCoroutine(nav.general.enviarBdId(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 0, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
            }
            else if (escena == "recogerSuministros")
            {
                // nav.modelo.Energia -= 1;
                StartCoroutine(nav.general.enviarBdId(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 0, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
            }
            else if (escena == "recolectarObjetos")
            {
                //nav.modelo.Energia -= 2;
                StartCoroutine(nav.general.enviarBdId(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 0, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
            }
            else if (escena == "ordenarFiguras")
            {
                //nav.modelo.Energia -= 3;
                StartCoroutine(nav.general.enviarBdId(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 0, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
            }
            else if (escena == "esquivarMeteoritos")
            {
                //nav.modelo.Energia -= 4;
                StartCoroutine(nav.general.enviarBdId(nav.general.Navegacion, nav.modelo.ToquesNav, nav.modelo.DuracionToquesNav, 0, 0, 0, 0, 0, nav.modelo.AyudasNav, nav.modelo.DuracionNav));
            }

            StartCoroutine(faded());
        }
        if (escena.Contains("Borde"))
        {
            GetComponent<AudioSource>().clip = choque;
            GetComponent<AudioSource>().Play();
            

        }
        if (escena.Contains("Limite"))
        {
            StartCoroutine(cambiarColor());
            nav.modelo.ChoqueBorde++;
            if (nav.modelo.ChoqueBorde % 4 == 0)
            {
                StartCoroutine(choqueLimite());
            }

        }
    }

    private IEnumerator choqueLimite()
    {

        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().clip = info;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(info.length);
    }

    public IEnumerator cambiarColor()
    {
        GetComponent<AudioSource>().clip = info;
        GetComponent<AudioSource>().Play();
        sliderBG.color = Color.red;
        sliderFill.color = Color.white;
        yield return new WaitForSeconds(pideEnergia.length);
        sliderBG.color = background;
        sliderFill.color =  fill;
    }
    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        GetComponent<AudioSource>().clip = entrar;
        GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene(escena);
    }

    private void Start()
    {
        background = sliderBG.color;
        fill = sliderFill.color;
        nav.modelo.ChoqueBorde = 0;
    }
}