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
    private bool puerta = true;

    /*
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "esquivarMeteoritos")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado +
                " | Acelerometro " + app.modelo.Acelerometro + "\n | Duracion " + app.modelo.Duracion +
                " | Energia " + nav.modelo.Energia, style);

        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        escena = collision.gameObject.name;
        if (!escena.Contains("Borde") && !escena.Contains("Limite") && puerta)
        {
            puerta = false;
            if (escena == "recogerSuministros")
            {
                nav.modelo.Energia -= 1;
            }
            else if (escena == "recolectarObjetos")
            {
                nav.modelo.Energia -= 2;
            }
            else if (escena == "ordenarFiguras")
            {
                nav.modelo.Energia -= 3;
            }
            else if (escena == "esquivarMeteoritos")
            {
                nav.modelo.Energia -= 4;
            }
            StartCoroutine(faded());
        }

    }

    public IEnumerator faded()
    {
        animador.SetBool("Fade", true);
        GetComponent<AudioSource>().clip = entrar;
        GetComponent<AudioSource>().Play();
        //yield return new WaitForSeconds(entrar.length);
        yield return new WaitUntil(() => negro.color.a == 1);
        SceneManager.LoadScene(escena);
    }
}