using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrdenarFigurasControlador : OrdenarFigurasElement
{
    public Material[] pizarra;
    public Material[] mtPlaneta;
    private GameObject planePizarra;
    private GameObject p1;
    private GameObject p2;
    private GameObject p3;
    private GameObject p4;
    private GameObject p5;
    private GameObject p6;
    private GameObject p7;
    private GameObject p8;
    private GameObject p9;
    private GameObject planeta1;
    private GameObject planeta2;
    private GameObject planeta3;
    private GameObject planeta4;
    private GameObject planeta5;
    private int nPizarra;


    public AudioClip energiaClip;

    float minDistance = 0.7f;
    private int varSalir;

    public int NPizarra
    {
        get
        {
            return nPizarra;
        }

        set
        {
            nPizarra = value;
        }
    }

    private void toques()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            app.modelo.Duracion_toques += Time.deltaTime;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                app.modelo.Toques++;
            }
        }
    }
    public void reiniciarValores()
    {
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Ayudas = 0;
        app.modelo.Aciertos = 0;
        app.modelo.Finalizado = false;
        app.modelo.Posicion1 = false;
        app.modelo.Posicion2 = false;
        app.modelo.Posicion3 = false;
        app.modelo.Posicion4 = false;
        app.modelo.Posicion5 = false;
        app.modelo.Posicion6 = false;
        app.modelo.Posicion7 = false;
        app.modelo.Posicion8 = false;
        app.modelo.Posicion9 = false;
        app.modelo.BotonSalir = false;

    }

    public void cargarObjetos()
    {
        p1 = GameObject.Find("P1");
        p2 = GameObject.Find("P2");
        p3 = GameObject.Find("P3");
        p4 = GameObject.Find("P4");
        p5 = GameObject.Find("P5");
        p6 = GameObject.Find("P6");
        p7 = GameObject.Find("P7");
        p8 = GameObject.Find("P8");
        p9 = GameObject.Find("P9");
        planePizarra = GameObject.Find("Pizarra");
        planeta1 = GameObject.Find("Planeta1");        
        planeta2 = GameObject.Find("Planeta2");
        planeta3 = GameObject.Find("Planeta3");
        planeta4 = GameObject.Find("Planeta4");
        planeta5 = GameObject.Find("Planeta5");
        planeta1.GetComponent<Renderer>().sharedMaterial = mtPlaneta[Random.Range(0, mtPlaneta.Length)];
        planeta2.GetComponent<Renderer>().sharedMaterial = mtPlaneta[Random.Range(0, mtPlaneta.Length)];
        planeta3.GetComponent<Renderer>().sharedMaterial = mtPlaneta[Random.Range(0, mtPlaneta.Length)];
        planeta4.GetComponent<Renderer>().sharedMaterial = mtPlaneta[Random.Range(0, mtPlaneta.Length)];
        planeta5.GetComponent<Renderer>().sharedMaterial = mtPlaneta[Random.Range(0, mtPlaneta.Length)];
    }

    public void cargarPizarra()
    {
        nPizarra = Random.Range(1, pizarra.Length);
        app.modelo.Pizarra = nPizarra;
        Debug.Log("PIZARRA ASIG "+nPizarra);
        planePizarra.GetComponent<Renderer>().sharedMaterial = pizarra[nPizarra];
        app.modelo.AciertosGen = 5;
        if (nPizarra <= 6)
        {
            planeta4.transform.position = new Vector3(-5f, -5f, 0);
            app.modelo.AciertosGen--;
        }
        if (nPizarra <= 12)
        {
            planeta5.transform.position = new Vector3(-5f, -5f, 0);
            app.modelo.AciertosGen--;
        }
    }



    public IEnumerator finalizar()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ordenarFiguras");
    }

    public void compararPizarra()
    {

        if (nPizarra == 1 && app.modelo.Posicion1 && app.modelo.Posicion5 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 3;
        }
        else if (nPizarra == 2 && app.modelo.Posicion2 && app.modelo.Posicion5 && app.modelo.Posicion8)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 3;
        }
        else if (nPizarra == 3 && app.modelo.Posicion3 && app.modelo.Posicion5 && app.modelo.Posicion7)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 3;
        }
        else if (nPizarra == 4 && app.modelo.Posicion5 && app.modelo.Posicion7 && app.modelo.Posicion8)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 3;
        }
        else if (nPizarra == 5 && app.modelo.Posicion4 && app.modelo.Posicion5 && app.modelo.Posicion6)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 3;
        }
        else if (nPizarra == 6 && app.modelo.Posicion3 && app.modelo.Posicion7 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 3;
        }
        else if (nPizarra == 7 && app.modelo.Posicion1 && app.modelo.Posicion2 && app.modelo.Posicion6 && app.modelo.Posicion8)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 4;
        }
        else if (nPizarra == 8 && app.modelo.Posicion2 && app.modelo.Posicion4 && app.modelo.Posicion6 && app.modelo.Posicion8)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 4;
        }
        else if (nPizarra == 9 && app.modelo.Posicion1 && app.modelo.Posicion3 && app.modelo.Posicion7 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 4;
        }
        else if (nPizarra == 10 && app.modelo.Posicion2 && app.modelo.Posicion3 && app.modelo.Posicion5 && app.modelo.Posicion6)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 4;
        }
        else if (nPizarra == 11 && app.modelo.Posicion2 && app.modelo.Posicion4 && app.modelo.Posicion5 && app.modelo.Posicion8)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 4;
        }
        else if (nPizarra == 12 && app.modelo.Posicion2 && app.modelo.Posicion7 && app.modelo.Posicion8 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 4;
        }
        else if (nPizarra == 13 && app.modelo.Posicion1 && app.modelo.Posicion2 && app.modelo.Posicion3 && app.modelo.Posicion7 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 5;
        }
        else if (nPizarra == 14 && app.modelo.Posicion4 && app.modelo.Posicion5 && app.modelo.Posicion6 && app.modelo.Posicion7 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 5;
        }
        else if (nPizarra == 15 && app.modelo.Posicion1 && app.modelo.Posicion3 && app.modelo.Posicion4 && app.modelo.Posicion5 && app.modelo.Posicion8)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 5;
        }
        else if (nPizarra == 16 && app.modelo.Posicion3 && app.modelo.Posicion6 && app.modelo.Posicion7 && app.modelo.Posicion8 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 5;
        }
        else if (nPizarra == 17 && app.modelo.Posicion3 && app.modelo.Posicion4 && app.modelo.Posicion5 && app.modelo.Posicion6 && app.modelo.Posicion7)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 5;
        }
        else if (nPizarra == 18 && app.modelo.Posicion1 && app.modelo.Posicion3 && app.modelo.Posicion5 && app.modelo.Posicion7 && app.modelo.Posicion9)
        {
            app.modelo.Finalizado = true;
            app.modelo.Aciertos = 5;
        }
    }

    public void salir()
    {
        if (nPizarra == 1)
        {
            if (app.modelo.Posicion1)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 2)
        {
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 3)
        {
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 4)
        {
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 5)
        {
            if (app.modelo.Posicion4)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 6)
        {
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 7)
        {
            if (app.modelo.Posicion1)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 8)
        {
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion4)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 9)
        {
            if (app.modelo.Posicion1)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 10)
        {
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 11)
        {
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion4)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 12)
        {
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 13)
        {
            if (app.modelo.Posicion1)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion2)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 14)
        {
            if (app.modelo.Posicion4)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 15)
        {
            if (app.modelo.Posicion1)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion4)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 16)
        {
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion8)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 17)
        {
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion4)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion6)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
        }
        else if (nPizarra == 18)
        {
            if (app.modelo.Posicion1)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion3)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion5)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion7)
            {
                app.modelo.Aciertos++;
            }
            if (app.modelo.Posicion9)
            {
                app.modelo.Aciertos++;
            }
        }
        StartCoroutine(nav.general.enviarBd(nav.general.OrdenarFiguras, app.modelo.Toques, app.modelo.Duracion_toques, 0, 0, app.modelo.Aciertos, app.modelo.AciertosGen, 0, app.modelo.Ayudas, app.modelo.Duracion));
    }

    public void salirActividad() {
        if (varSalir == 0)
        {
            salir();
            varSalir++;
        }
    }

    public IEnumerator ordenaFigura()
    {

        string url = nav.general.BaseUrl + "Actividad/ordenaFigura";
        // Headers
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Authorization", nav.general.Token);
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idActividad", nav.general.IdActividadActual);
        form.AddField("idPizarra", app.modelo.Pizarra);
        if (app.modelo.Posicion1)
        {
            form.AddField("p1", 1);
        }
        else
        {
            form.AddField("p1", 0);
        }
        if (app.modelo.Posicion2)
        {
            form.AddField("p2", 1);
        }
        else
        {
            form.AddField("p2", 0);
        }
        if (app.modelo.Posicion3)
        {
            form.AddField("p3", 1);
        }
        else
        {
            form.AddField("p3", 0);
        }
        if (app.modelo.Posicion4)
        {
            form.AddField("p4", 1);
        }
        else
        {
            form.AddField("p4", 0);
        }
        if (app.modelo.Posicion5)
        {
            form.AddField("p5", 1);
        }
        else
        {
            form.AddField("p5", 0);
        }
        if (app.modelo.Posicion6)
        {
            form.AddField("p6", 1);
        }
        else
        {
            form.AddField("p6", 0);
        }
        if (app.modelo.Posicion7)
        {
            form.AddField("p7", 1);
        }
        else
        {
            form.AddField("p7", 0);
        }
        if (app.modelo.Posicion8)
        {
            form.AddField("p8", 1);
        }
        else
        {
            form.AddField("p8", 0);
        }
        if (app.modelo.Posicion9)
        {
            form.AddField("p9", 1);
        }
        else
        {
            form.AddField("p9", 0);
        }
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        if (www.text == "ingresado")
        {
            Debug.Log("1");
        }
        else
        {
            Debug.Log("0");
            Debug.Log(www.text);
        }
    }
    private void touch() {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            app.modelo.Duracion_toques += Time.deltaTime;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                app.modelo.Toques++;
            }
        }
    }

    private void Update()
    {
        compararPizarra();
        if (app.modelo.Finalizado && !app.modelo.Recompensa)
        {
            app.modelo.Recompensa = true;
            GetComponent<AudioSource>().clip = energiaClip;
            GetComponent<AudioSource>().Play();
            nav.modelo.Energia += 2;
            StartCoroutine(nav.general.enviarBd(nav.general.OrdenarFiguras, app.modelo.Toques, app.modelo.Duracion_toques, 0, 0, app.modelo.Aciertos, app.modelo.AciertosGen, 1, app.modelo.Ayudas, app.modelo.Duracion));
            StartCoroutine(finalizar());
        }
        touch();
        if (app.modelo.BotonSalir)
        {
            salirActividad();
        }
        /*
        toques();
        if (!app.modelo.Finalizado)
        {
            posiciones();
            comparar();
        }
        if (app.modelo.BotonSalir)
        {
            salirActividad();
        }
        if (app.modelo.Finalizado && !app.modelo.Recompensa)
        {
            app.modelo.Recompensa = true;
            GetComponent<AudioSource>().clip = energiaClip;
            GetComponent<AudioSource>().Play();
            nav.modelo.Energia += 2;            
            StartCoroutine(nav.general.enviarBd(nav.general.OrdenarFiguras, app.modelo.Toques, app.modelo.Duracion_toques, 0, 0, app.modelo.Aciertos, app.modelo.AciertosGen, 1, app.modelo.Ayudas, app.modelo.Duracion));
            StartCoroutine(finalizar());
        }
        */
    }

    private void Start()
    {
        app.modelo.Recompensa = false;
        reiniciarValores();
        cargarObjetos();
        cargarPizarra();
        StartCoroutine(nav.general.enviarBdId(nav.general.OrdenarFiguras, 0, 0, 0, 0, 0, 0, 0, 0, 0));
    }

}
