using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private bool ep1;
    private bool ep2;
    private bool ep3;
    private bool ep4;
    private bool ep5;
    private bool ep6;
    private bool ep7;
    private bool ep8;
    private bool ep9;

    float minDistance = 0.7f;

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
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Finalizado = false;
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
        planePizarra.GetComponent<Renderer>().sharedMaterial = pizarra[nPizarra];
        if (nPizarra <= 6)
        {
            planeta4.transform.position = new Vector3(-5f, -5f, 0);
        }
        if (nPizarra <= 12)
        {
            planeta5.transform.position = new Vector3(-5f, -5f, 0);
        }
    }

    public void posiciones()
    {
        Vector3 posp1 = planeta1.transform.position;
        Vector3 posp2 = planeta2.transform.position;
        Vector3 posp3 = planeta3.transform.position;
        Vector3 posp4 = planeta4.transform.position;
        Vector3 posp5 = planeta5.transform.position;
        if (cerca(p1.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep1 = true;
        }
        else
        {
            ep1 = false;
        }
        if (cerca(p2.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep2 = true;
        }
        else
        {
            ep2 = false;
        }
        if (cerca(p3.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep3 = true;
        }
        else
        {
            ep3 = false;
        }
        if (cerca(p4.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep4 = true;
        }
        else
        {
            ep4 = false;
        }
        if (cerca(p5.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep5 = true;
        }
        else
        {
            ep5 = false;
        }
        if (cerca(p6.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep6 = true;
        }
        else
        {
            ep6 = false;
        }
        if (cerca(p7.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep7 = true;
        }
        else
        {
            ep7 = false;
        }
        if (cerca(p8.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep8 = true;
        }
        else
        {
            ep8 = false;
        }
        if (cerca(p9.transform.position, posp1, posp2, posp3, posp4, posp5))
        {
            ep9 = true;
        }
        else
        {
            ep9 = false;
        }

    }

    public void comparar()
    {

        if (nPizarra == 1 && ep1 && ep5 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 2 && ep2 && ep5 && ep8)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 3 && ep3 && ep5 && ep7)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 4 && ep5 && ep7 && ep8)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 5 && ep4 && ep5 && ep6)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 6 && ep3 && ep7 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 7 && ep1 && ep2 && ep6 && ep8)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 8 && ep2 && ep4 && ep6 && ep8)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 9 && ep1 && ep3 && ep7 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 10 && ep2 && ep3 && ep5 && ep6)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 11 && ep2 && ep4 && ep5 && ep8)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 12 && ep2 && ep7 && ep8 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 13 && ep1 && ep2 && ep3 && ep7 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 14 && ep4 && ep5 && ep6 && ep7 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 15 && ep1 && ep3 && ep4 && ep5 && ep8)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 16 && ep3 && ep6 && ep7 && ep8 && ep9)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 17 && ep3 && ep4 && ep5 && ep6 && ep7)
        {
            app.modelo.Finalizado = true;
        }
        if (nPizarra == 18 && ep1 && ep3 && ep5 && ep7 && ep9)
        {
            app.modelo.Finalizado = true;
        }
    }


    private bool cerca(Vector3 p, Vector3 plan1, Vector3 plan2, Vector3 plan3, Vector3 plan4, Vector3 plan5)
    {
        return ((p.x < plan1.x + minDistance && p.x > plan1.x - minDistance) &&
            (p.y < plan1.y + minDistance && p.y > plan1.y - minDistance))
            ||
            ((p.x < plan2.x + minDistance && p.x > plan2.x - minDistance) &&
            (p.y < plan2.y + minDistance && p.y > plan2.y - minDistance))
            ||
            ((p.x < plan3.x + minDistance && p.x > plan3.x - minDistance) &&
            (p.y < plan3.y + minDistance && p.y > plan3.y - minDistance))
            ||
            ((p.x < plan4.x + minDistance && p.x > plan4.x - minDistance) &&
            (p.y < plan4.y + minDistance && p.y > plan4.y - minDistance))
            ||
            ((p.x < plan5.x + minDistance && p.x > plan5.x - minDistance) &&
            (p.y < plan5.y + minDistance && p.y > plan5.y - minDistance))
            ;
    }


    private void Update()
    {
        toques();
        posiciones();
        comparar();
        if (app.modelo.Finalizado && !app.modelo.Recompensa)
        {
            nav.modelo.Energia += 2;
            app.modelo.Recompensa = true;
        }
    }
    private void Start()
    {
        reiniciarValores();
        cargarObjetos();
        cargarPizarra();
    }

}
