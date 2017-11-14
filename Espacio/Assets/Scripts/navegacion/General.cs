
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General : NavegacionElement
{
    private string baseUrl = "http://localhost:8080/reim/ws/";
   private int idReim = 570;
    private int idAlumno = 25387;
    private int navegacion = 167;
    private int alcanzarSatelite = 168;
    private int recogerSuministros = 169;
    private int recolectarObjectos = 170;
    private int ordenarFiguras = 171;
    private int esquivarMeteoritos = 172;
    private int idSesion = 1;
    private int idActividadActual = 200;

    public IEnumerator enviarBd(int actividad, int toques, float duracion_toques, int errores, int erroresGen, int aciertos, int aciertosGen, int finalizado, int ayudas, float duracion)
    {

        // url
        string url = baseUrl + "Actividad/ingresar";
        // Headers
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Authorization", nav.general.Token);
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idUser", idAlumno);
        form.AddField("idActividad", actividad);
        form.AddField("idSesion", idSesion);
        form.AddField("idReim", idReim);
        form.AddField("touchCantidad", toques);
        form.AddField("touchTiempo", duracion_toques.ToString());
        form.AddField("errores", errores);
        form.AddField("erroresGen", erroresGen);
        form.AddField("aciertos", aciertos);
        form.AddField("aciertosGen", aciertosGen);
        form.AddField("finalizado", finalizado);
        form.AddField("ayudas", ayudas);
        form.AddField("duracion", duracion.ToString());
        byte[] rawData = form.data;
        // Request
        WWW www = new WWW(url, rawData, headers);


        yield return www;
        //Debug.Log(www.text);
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

    public IEnumerator enviarBdId(int actividad, int toques, float duracion_toques, int errores, int erroresGen, int aciertos, int aciertosGen, int finalizado, int ayudas, float duracion)
    {

        // url
        string url = baseUrl + "Actividad/ingresar/id";
        // Headers
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Authorization", nav.general.Token);
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idUser", idAlumno);
        form.AddField("idActividad", actividad);
        form.AddField("idSesion", idSesion);
        form.AddField("idReim", idReim);
        form.AddField("touchCantidad", toques);
        form.AddField("touchTiempo", duracion_toques.ToString());
        form.AddField("errores", errores);
        form.AddField("erroresGen", erroresGen);
        form.AddField("aciertos", aciertos);
        form.AddField("aciertosGen", aciertosGen);
        form.AddField("finalizado", finalizado);
        form.AddField("ayudas", ayudas);
        form.AddField("duracion", duracion.ToString());
        byte[] rawData = form.data;
        // Request
        WWW www = new WWW(url, rawData, headers);


        yield return www;
        Debug.Log(www.text);
        idActividadActual = int.Parse(www.text);
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

    public IEnumerator detalleActividad(int correcto, float tiempoActividad)
    {
        string url = nav.general.BaseUrl + "Actividad/detalle";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Authorization", nav.general.Token);
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        WWWForm form = new WWWForm();
        form.AddField("idActividad", idActividadActual);
        form.AddField("correcto", correcto);
        form.AddField("tiempoActividad", tiempoActividad.ToString());
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

    public string BaseUrl
    {
        get
        {
            return baseUrl;
        }

        set
        {
            baseUrl = value;
        }
    }

    public int IdReim
    {
        get
        {
            return idReim;
        }

        set
        {
            idReim = value;
        }
    }

    public int IdAlumno
    {
        get
        {
            return idAlumno;
        }

        set
        {
            idAlumno = value;
        }
    }

    public int Navegacion
    {
        get
        {
            return navegacion;
        }

        set
        {
            navegacion = value;
        }
    }

    public int AlcanzarSatelite
    {
        get
        {
            return alcanzarSatelite;
        }

        set
        {
            alcanzarSatelite = value;
        }
    }

    public int RecogerSuministros
    {
        get
        {
            return recogerSuministros;
        }

        set
        {
            recogerSuministros = value;
        }
    }

    public int RecolectarObjectos
    {
        get
        {
            return recolectarObjectos;
        }

        set
        {
            recolectarObjectos = value;
        }
    }

    public int OrdenarFiguras
    {
        get
        {
            return ordenarFiguras;
        }

        set
        {
            ordenarFiguras = value;
        }
    }

    public int EsquivarMeteoritos
    {
        get
        {
            return esquivarMeteoritos;
        }

        set
        {
            esquivarMeteoritos = value;
        }
    }

    public int IdSesion
    {
        get
        {
            return idSesion;
        }

        set
        {
            idSesion = value;
        }
    }

    public string Token
    {
        get
        {
            return token;
        }

        set
        {
            token = value;
        }
    }

    public int IdActividadActual
    {
        get
        {
            return idActividadActual;
        }

        set
        {
            idActividadActual = value;
        }
    }
}