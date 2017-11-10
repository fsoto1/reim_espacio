using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JugadorRecolectarObjetosControlador : RecolectarObjetosElement
{
    private Vector3 coordenadas;
    private Vector3 posicion;
    private bool encontrado;
    public AudioClip choqueClip;
    public AudioClip energiaClip;

    public void moverJugador()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f);
            posicion = Camera.main.ScreenToWorldPoint(coordenadas);
            transform.LookAt(posicion);
            transform.Rotate(new Vector3(0, 0, 270));
            transform.position = Vector3.Lerp(transform.position, posicion, app.modelo.Velocidad_jugador * Time.deltaTime);
            app.modelo.Duracion_toques += Time.deltaTime;


            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                app.modelo.Toques++;
            }
        }
    }


    private IEnumerator enviaObjetos(int correcto, string color)
    {
        string url = nav.general.BaseUrl + "Actividad/recolectaObjeto/recolecta";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Authorization", nav.general.Token);
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        WWWForm form = new WWWForm();
        form.AddField("idPatron", app.modelo.IdPatron);
        form.AddField("correcto", correcto);
        form.AddField("color", color);
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

    private void OnCollisionEnter(Collision collision)
    {
        encontrado = false;
        foreach (var nombre in app.modelo.NombreColores)
        {
            if (nombre == collision.gameObject.GetComponent<Renderer>().sharedMaterial.name)
            {
                Destroy(collision.gameObject);
                encontrado = true;
                app.modelo.Recolectados++;
                GetComponent<AudioSource>().clip = energiaClip;
                GetComponent<AudioSource>().Play();
                StartCoroutine(enviaObjetos(1, nombre));
            }
        }
        if (!encontrado)
        {
            app.modelo.Cantidad_colisiones++;
            StartCoroutine(enviaObjetos(0, collision.gameObject.GetComponent<Renderer>().sharedMaterial.name));
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * 50f);
            GetComponent<AudioSource>().clip = choqueClip;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().clip = choqueClip;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            if (app.modelo.Recolectados % 10 == 0)
            {
                nav.modelo.Energia++;
            }
        }
    }
  

    private void FixedUpdate()
    {
        moverJugador();
    }
    

}
