using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecolectarObjetosVista : RecolectarObjetosElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;
    public AudioClip info;
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
        StartCoroutine(nav.general.enviarBd(nav.general.RecolectarObjectos, app.modelo.Toques, app.modelo.Duracion_toques, app.modelo.Cantidad_colisiones, app.modelo.ErroresGen,app.modelo.Recolectados, app.modelo.AciertosGen, 1, app.modelo.Ayudas, app.modelo.Duracion));
        nav.modelo.JugadorPosX = 5f;
        nav.modelo.JugadorPosY = 6f;
        StartCoroutine(faded());
    }

    public void ayudaClick()
    {
        app.modelo.Ayudas++;
        GetComponent<AudioSource>().clip = info;
        GetComponent<AudioSource>().Play();
    }

    private void LateUpdate()
    {
       barra.value = calcular();
    }
    private float calcular()
    {
        return nav.modelo.Energia / nav.modelo.MaxEnergia;
    }

    GameObject fondo;

    public void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "recolectarObjetos1")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + 
                " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion + 
                " | Energia " + nav.modelo.Energia + "\n | Objetos recolectados " + app.modelo.Recolectados +
                " | AciertosGen " + app.modelo.AciertosGen + "| ErroresGen " + app.modelo.ErroresGen, style);

        }
    }

    public float scrollSpeed;
    private Vector2 savedOffset;

    void Start()
    {
        barra.value = calcular();
        fondo = GameObject.Find("BackGround"); 
        savedOffset = fondo.GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * app.modelo.Velocidad_background, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        fondo.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        fondo.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}