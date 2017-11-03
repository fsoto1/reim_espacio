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
    void reiniciarValores()
    {
        StartCoroutine(generarOleada());
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Finalizado = false;
    }

    private void Start()
    {
        app.modelo.Finalizado = false;
        cargarColores();
        reiniciarValores();
    }

    

}
