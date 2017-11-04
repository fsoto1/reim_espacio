using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : NavegacionElement
{
    public InputField usuarioInput;
    public InputField contraseñaInput;
    public Button submit;
    public GameObject popUp;
    public Text popUpText;
    public GameObject usuarioPopUp;
    public Text usuarioPopUpText;
    public GameObject periodoPopUp;
    private string url;
    private string usuario;
    private string contraseña;
    public Transform padrePeriodo;
    public GameObject itemPeriodo;
    public GameObject botonAtras;
    private int idUsuario;
    private int idColegio;
    private int idPeriodo;
    private int idCurso;
    private int idAlumno;

    public void mensajePopUp(string mensaje) {
        popUpText.text = mensaje;
        popUp.SetActive(true);
    }
    
    public void mensajePopUpEsconder()
    {
        popUp.SetActive(false);
    }

    public void mensajeUsuarioPopUp(string mensaje)
    {
        usuarioPopUpText.text = mensaje;
        usuarioPopUp.SetActive(true);
    }

    public void mensajePopUpUsuarioAtras()
    {
      usuarioPopUp.SetActive(false);
    }

    public void mensajePopUpUsuarioOk()
    {
        usuarioPopUp.SetActive(false);
        periodoPopUp.SetActive(true);
        StartCoroutine(buscarPeriodos());
    }
    public void mensajePopUpPeriodoAtras()
    {

        if (botonAtras.name == "periodo")
        {
            usuarioPopUp.SetActive(true);
            periodoPopUp.SetActive(false);
        }
        else if (botonAtras.name == "colegio")
        {
            StartCoroutine(buscarPeriodos());
        }
        else if (botonAtras.name == "curso")
        {
            StartCoroutine(buscarColegios());
        }
        else if (botonAtras.name == "alumno")
        {
            StartCoroutine(buscarCurso());
        }
    }

    public void seleccionarPeriodo(int periodo)
    {
        Debug.Log("Periodo "+periodo);
        
        Debug.Log("nombre boton "+ botonAtras.name);
        idPeriodo = periodo;
        StartCoroutine(buscarColegios());
    }

    public void seleccionarColegio(int colegio)
    {
        Debug.Log("nombre boton " + botonAtras.name);
        idColegio = colegio;
        StartCoroutine(buscarCurso());
    }

    public void seleccionarCurso(int curso)
    {
        idCurso = curso;
        StartCoroutine(buscarAlumno());
    }

    public void seleccionarAlumno(int alumno)
    {
        idAlumno = alumno;
        mensajePopUp("ALUMNO = "+idAlumno);
        nav.general.IdAlumno = idAlumno;
        SceneManager.LoadScene("navegacion");
    }


    /**
     *   Extrae los periodos en la base de datos
     */
    public IEnumerator buscarPeriodos() {
        url = nav.general.BaseUrl + "Periodo";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        WWWForm form = new WWWForm();
        form.AddField("", 0);
        byte[] rawData = form.data;
        headers.Add("Authorization", nav.general.Token);
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        if (www.text != "")
        {
            Periodo[] periodos = JsonHelper.getJsonArray<Periodo>(www.text);
            foreach (Transform child in padrePeriodo)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach (var periodo in periodos)
            {
                Debug.Log(periodo.id);
                Debug.Log(periodo.nombre);
                GameObject elemento = Instantiate(itemPeriodo);
                elemento.name = periodo.nombre;
                elemento.GetComponentInChildren<Text>().text = periodo.nombre;
                elemento.GetComponent<Button>().onClick.AddListener(() => seleccionarPeriodo(periodo.id));
                elemento.transform.SetParent(padrePeriodo, false);
            }
        }
        botonAtras.name = "periodo";
    }

    /**
     *   Extrae los colegios en la base de datos
     */
    public IEnumerator buscarColegios()
    {
        url = nav.general.BaseUrl + "Pertenece/colegio";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        headers.Add("Authorization",  nav.general.Token);
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idUsuario", idUsuario);
        form.AddField("idPeriodo", idPeriodo);
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        if (www.text != "")
        {
            Colegio[] colegios = JsonHelper.getJsonArray<Colegio>(www.text);
            foreach (Transform child in padrePeriodo)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach (var colegio in colegios)
            {
                GameObject elemento = Instantiate(itemPeriodo);
                elemento.name = colegio.nombre;
                elemento.GetComponentInChildren<Text>().text = colegio.nombre;
                elemento.GetComponent<Button>().onClick.AddListener(() => seleccionarColegio(colegio.id));
                elemento.transform.SetParent(padrePeriodo, false);
            }

        }
        botonAtras.name = "colegio";
    }
    /**
     *   Extrae los cursos en la base de datos
     *   indicando usuario, periodo y colegio
     */
    public IEnumerator buscarCurso()
    {
        url = nav.general.BaseUrl + "Pertenece/curso";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        headers.Add("Authorization", nav.general.Token);
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idUsuario", idUsuario);
        form.AddField("idPeriodo", idPeriodo);
        form.AddField("idColegio", idColegio);
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        if (www.text != "")
        {
            Curso[] cursos = JsonHelper.getJsonArray<Curso>(www.text);
            foreach (Transform child in padrePeriodo)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach (var curso in cursos)
            {
                GameObject elemento = Instantiate(itemPeriodo);
                elemento.name = curso.nombre;
                elemento.GetComponentInChildren<Text>().text = curso.nombre;
                elemento.GetComponent<Button>().onClick.AddListener(() => seleccionarCurso(curso.id));
                elemento.transform.SetParent(padrePeriodo, false);
            }

        }
        botonAtras.name = "curso";
    }

    /**
     *   Extrae los alumnos en la base de datos
     *   indicando curso
     */
    public IEnumerator buscarAlumno()
    {
        url = nav.general.BaseUrl + "Pertenece/alumno";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        headers.Add("Authorization", nav.general.Token);
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idCurso", idCurso);
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        if (www.text != "")
        {
            Usuario[] usuarios = JsonHelper.getJsonArray<Usuario>(www.text);
            foreach (Transform child in padrePeriodo)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach (var usuario in usuarios)
            {
                GameObject elemento = Instantiate(itemPeriodo);
                elemento.name = usuario.nombres;
                elemento.GetComponentInChildren<Text>().text = usuario.nombres;
                elemento.GetComponent<Button>().onClick.AddListener(() => seleccionarAlumno(usuario.id));
                elemento.transform.SetParent(padrePeriodo, false);
            }

        }
        botonAtras.name = "alumno";
    }

    public IEnumerator autenticar()
    { 
        if (usuario.Trim() != "")
        {

            // url
            url = nav.general.BaseUrl + "Autenticacion/credencial";
            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //Form
            WWWForm form = new WWWForm();
            form.AddField("usuario", usuario);
            byte[] rawData = form.data;
            // Request
            WWW www = new WWW(url, rawData, headers);
            
            
            yield return www;
            Debug.Log(www.text);
            if (www.text == "")
            {
                mensajePopUp("No se estableció conexión");
            }
            else if (www.responseHeaders.Count > 0)
            {
                
                foreach (KeyValuePair<string, string> entry in www.responseHeaders)
                {
                    Debug.Log(entry.Value);
                    if (entry.Value.Contains( "200 OK"))
                    {
                        nav.general.Token = "Bearer "+ www.text;
                        Debug.Log(nav.general.Token);
                        url = nav.general.BaseUrl + "Autenticacion/login";
                        headers.Add("Authorization", nav.general.Token);
                        www = new WWW(url, rawData, headers);
                        yield return www;
                        Debug.Log(www.text);
                        Usuario usuario = JsonUtility.FromJson<Usuario>(www.text);
                        idUsuario = usuario.id;
                        Debug.Log("IDUSUARIO" + idUsuario);
                        mensajeUsuarioPopUp("Bienvenida(o)!\n " + usuario.nombres + " " + usuario.apellidoPaterno);
                        break;
                    }
                    else if (entry.Value.Contains("403 Forbidden"))
                    {
                        mensajePopUp("Usuario no encontrado");
                    }
                    else if (entry.Value.Contains("404 Not Found"))
                    {
                        mensajePopUp("No se encontró el acceso");
                    }
                }
            } 
        }
        else
        {
            mensajePopUp("Espacios en blanco");
        }
    }

    public void ingresar()
    {
        usuario = usuarioInput.text;
        StartCoroutine(autenticar());
    }

    public void reim() {
        SceneManager.LoadScene("navegacion");
    }
}
