using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecolectarObjetosControlador : RecolectarObjetosElement
{ 
    public GameObject[] objetos;
    public Material[] colores;
    public GameObject[] cuboColor;
    private Vector3 coordenadas;
    private Vector3 posicion;
    private int[] numColores;
    private bool encontrado;

    private void cargarColores()
    {
        numColores =  new int[cuboColor.Length];
        app.modelo.NombreColores = new string[cuboColor.Length];
        
        bool usado;
        for (int i = 0; i < numColores.Length; i++)
        {
            usado = true;
            while (usado)
            {
                usado = false;
                numColores[i] = Random.Range(0, colores.Length);
                for (int j = 0; j < i; j++)
                {
                    if (numColores[i] == numColores[j])
                    {
                        usado = true;
                    }
                }
            }
        }
        for (int i = 0; i < cuboColor.Length; i++)
        {
            cuboColor[i].GetComponent<Renderer>().sharedMaterial = colores[numColores[i]];
            app.modelo.NombreColores[i] = cuboColor[i].GetComponent<Renderer>().sharedMaterial.name;
        }
    }



    public IEnumerator generarOleada()
    {
        yield return new WaitForSeconds(app.modelo.Tiempo_espera_inicio);
        while (true)
        {
            for (int i = 0; i < app.modelo.Oleada_total; i++)
            {
                Vector3 posicion_partida = new Vector3(11, Random.Range(-3, 6), 0);
                Quaternion rotacion_partida = Quaternion.identity;
                GameObject clone;
                clone = Instantiate(objetos[Random.Range(0,objetos.Length)], posicion_partida, rotacion_partida) as GameObject;
                clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.left * app.modelo.Velocidad_objetos);
                clone.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
                clone.GetComponent<Renderer>().sharedMaterial = colores[Random.Range(0,colores.Length)];
                encontrado = false;
                foreach (var nombre in app.modelo.NombreColores)
                {
                    if (nombre == clone.GetComponent<Renderer>().sharedMaterial.name)
                    {
                        encontrado = true;
                        app.modelo.AciertosGen++;
                    }
                }
                if (!encontrado)
                {
                    app.modelo.ErroresGen++;
                }
                yield return new WaitForSeconds(app.modelo.Tiempo_espera_aparicion);
            }
            yield return new WaitForSeconds(app.modelo.Tiempo_espera_oleada);
        }
    }

    public void reiniciarValores()
    {
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Recolectados = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Ayudas = 0;
        app.modelo.ErroresGen = 0;
        app.modelo.AciertosGen = 0;
        app.modelo.Finalizado = false;
    }

    private IEnumerator cargarPatron()
    {
        string url = nav.general.BaseUrl + "Actividad/recolectaObjeto/patron";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Authorization", nav.general.Token);
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        WWWForm form = new WWWForm();
        form.AddField("idActividad", nav.general.IdActividadActual);
        form.AddField("color1", app.modelo.NombreColores[0]);
        form.AddField("color2", app.modelo.NombreColores[1]);
        form.AddField("color3", app.modelo.NombreColores[2]);
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        app.modelo.IdPatron = int.Parse(www.text);
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
    private void Start()
    {
        app.modelo.Finalizado = false;
        cargarColores();
        reiniciarValores();
        StartCoroutine(cargarPatron());
        StartCoroutine(generarOleada());
    }

    

}
