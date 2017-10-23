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

    public void volverClick()
    {
        Debug.Log("Volver!");
        SceneManager.LoadScene("navegacion");
    }

    public void ayudaClick()
    {
        Debug.Log("Ayuda!");
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
        if (SceneManager.GetActiveScene().name == "recolectarObjetos")
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(0, 0, 100, 100), "Colisiones: " + app.modelo.Cantidad_colisiones + " | Finalizado " + app.modelo.Finalizado + 
                " | Touch " + app.modelo.Toques + "\n | Tiempo mov " + app.modelo.Duracion_toques + " | Duracion " + app.modelo.Duracion + 
                " | Energia " + nav.modelo.Energia + "\n | Objetos recolectados " + app.modelo.Recolectados, style);

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
        float x = Mathf.Repeat(Time.time * nav.modelo.Velocidad_background, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        fondo.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        fondo.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}