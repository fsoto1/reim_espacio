using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EsquivarMeteoritosControlador : EsquivarMeteoritosElement
{
    public GameObject asteroide1;
    public GameObject asteroide2;
    public GameObject asteroide3;
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
                Vector3 posicion_partida = new Vector3(Random.Range(app.modelo.Min_posicion, app.modelo.Max_posicion), 6, 0);
                Quaternion rotacion_partida = Quaternion.identity;
                GameObject clone;
                random = Random.Range(0, 2);
                if (random == 0)
                {
                    clone = Instantiate(asteroide1, posicion_partida, rotacion_partida) as GameObject;
                }
                else if (random == 1)
                {
                    clone = Instantiate(asteroide2, posicion_partida, rotacion_partida) as GameObject;
                }
                else
                {
                    clone = Instantiate(asteroide3, posicion_partida, rotacion_partida) as GameObject;
                }
                clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down * app.modelo.Velocidad_objetos);
                clone.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * app.modelo.Velocidad_rotacion;
                yield return new WaitForSeconds(app.modelo.Tiempo_espera_aparicion);
            }
            yield return new WaitForSeconds(app.modelo.Tiempo_espera_oleada);
        }
    }

    public IEnumerator ganarEnergia()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            nav.modelo.Energia++;
        }
    }

    private void Update()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
    }
    
    void Start()
    {
        StartCoroutine(generarOleada());
        StartCoroutine(ganarEnergia());
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Acelerometro = 0f;
        app.modelo.Duracion = 0;
        app.modelo.Finalizado = false;        
    }
}
