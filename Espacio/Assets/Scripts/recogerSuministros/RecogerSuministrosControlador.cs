using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecogerSuministrosControlador : RecogerSuministrosElement
{
    public GameObject suministro;
    public GameObject asteroide1;
    public GameObject asteroide2;
    public GameObject asteroide3;
    public Material[] materials;
    private Vector3 coordenadas;
    private Vector3 posicion;


    public IEnumerator generarOleada()
    {
        yield return new WaitForSeconds(app.modelo.Tiempo_espera_inicio);
        int random;
        while (true)
        {
            for (int i = 0; i < app.modelo.Oleada_total; i++)
            {
                Vector3 posicion_partida = new Vector3(11, Random.Range(-3, 6), 0);
                Quaternion rotacion_partida = Quaternion.identity;
                GameObject clone;
                random = Random.Range(0, 5);
                if (random == 0)
                {
                    clone = Instantiate(asteroide1, posicion_partida, rotacion_partida) as GameObject;
                }
                else if (random == 1)
                {
                    clone = Instantiate(asteroide2, posicion_partida, rotacion_partida) as GameObject;
                }
                else if (random == 2)
                {
                    clone = Instantiate(asteroide3, posicion_partida, rotacion_partida) as GameObject;
                }
                else
                {
                    clone = Instantiate(suministro, posicion_partida, rotacion_partida) as GameObject;
                    clone.GetComponent<Renderer>().sharedMaterial = materials[Random.Range(0, materials.Length)];
                }
                clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.left * app.modelo.Velocidad_objetos);
                clone.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
                yield return new WaitForSeconds(app.modelo.Tiempo_espera_aparicion);
            }
            yield return new WaitForSeconds(app.modelo.Tiempo_espera_oleada);
        }
    }

    void Start()
    {
        StartCoroutine(generarOleada());
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Cantidad_suministros = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Finalizado = false;
    }
}
