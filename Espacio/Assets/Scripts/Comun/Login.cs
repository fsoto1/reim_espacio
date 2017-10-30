using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usuarioInput;
    public InputField contraseñaInput;
    public Button submit;
    public GameObject popUp;
    public Text popUpText;
    public GameObject usuarioPopUp;
    public Text usuarioPopUpText;
    public GameObject periodoPopUp;
    private string baseUrl = "http://localhost:8080/reim/ws/";
    private string url;
    private string usuario;
    private string contraseña;
    public Transform padrePeriodo;
    public GameObject itemPeriodo;
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
        usuarioPopUp.SetActive(true);
        periodoPopUp.SetActive(false);
    }

    public void seleccionarPeriodo(int periodo)
    {
        Debug.Log("Periodo "+periodo);
        idPeriodo = periodo;
        StartCoroutine(buscarColegios());
    }

    public void seleccionarColegio(int colegio)
    {
        Debug.Log("Colegio " + colegio);
        idColegio = colegio;
        StartCoroutine(buscarCurso());
    }

    public void seleccionarCurso(int curso)
    {
        Debug.Log("Curso " + curso);
        idCurso = curso;
        StartCoroutine(buscarAlumno());
    }

    public void seleccionarAlumno(int alumno)
    {
        Debug.Log("Alumno " + alumno);
        idAlumno = alumno;
        mensajePopUp("ALUMNO = "+idAlumno);
        //StartCoroutine(buscarAlumno());
    }

    private void Start()
    {
        Debug.Log("Colegios");
        //StartCoroutine(buscarColegios());
        //StartCoroutine(buscarPeriodos());
        //StartCoroutine(buscarPeriodos());
    }

    /**
     *   Extrae los periodos en la base de datos
     */
    public IEnumerator buscarPeriodos() {
        url = baseUrl + "Periodo";
        WWW www = new WWW(url);
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
    }

    /**
     *   Extrae los colegios en la base de datos
     */
    public IEnumerator buscarColegios()
    {
        url = baseUrl + "Pertenece/colegio";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
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
                Debug.Log(colegio.id);
                Debug.Log(colegio.nombre);
                GameObject elemento = Instantiate(itemPeriodo);
                elemento.name = colegio.nombre;
                elemento.GetComponentInChildren<Text>().text = colegio.nombre;
                elemento.GetComponent<Button>().onClick.AddListener(() => seleccionarColegio(colegio.id));
                elemento.transform.SetParent(padrePeriodo, false);
            }

        }
    }
    /**
     *   Extrae los cursos en la base de datos
     *   indicando usuario y colegio
     */
    public IEnumerator buscarCurso()
    {
        url = baseUrl + "Pertenece/curso";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
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
    }

    /**
     *   Extrae los alumnos en la base de datos
     *   indicando curso
     */
    public IEnumerator buscarAlumno()
    {
        url = baseUrl + "Pertenece/alumno";
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //Form
        WWWForm form = new WWWForm();
        form.AddField("idCurso", idCurso);
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData, headers);
        yield return www;
        Debug.Log(www.text);
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
    }

    public IEnumerator ir()
    { 
        if (usuario.Trim() != "" && contraseña.Trim() != "")
        {

            // url
            url = baseUrl+"Usuario/login";
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
            if (www.text != "")
            {
                Debug.Log(www.text);
                Usuario usuario = JsonUtility.FromJson<Usuario>(www.text);
                idUsuario = usuario.id;
                Debug.Log("IDUSUARIO"+ idUsuario );
                mensajeUsuarioPopUp("Bienvenida!\n "+ usuario.nombres+" "+ usuario.apellidoPaterno);
            }
            else
            {
                mensajePopUp("Usuario no encontrado");
            }
        }
        else
        {
            mensajePopUp("Espacios en blanco");
        }
        
        
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = www.texture;
    }

    IEnumerator registrar()
    {
        yield return new WaitForSeconds(1);
        /*

        Debug.Log(usuario + " " + contraseña);
        if (usuario.Trim() != "" && contraseña.Trim() != "")
        {
            Usuarios nuevo = new Usuarios();
            nuevo.nombreUsuarios = usuario;
            nuevo.username = usuario;
            nuevo.tipoUsuarios = "Test";
            nuevo.contrasenaUsuarios = contraseña;
            nuevo.idColegios = new Colegios { idColegios = 1};
            
            string json = JsonUtility.ToJson(nuevo);
            Debug.Log("JSON "+json);
            byte[] pData = System.Text.Encoding.ASCII.GetBytes(json.ToCharArray());
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
 
            WWW www = new WWW(url, pData, headers);
            
            yield return www;
            Debug.Log("RESPUESTA " + www.text);
            if (www.text == "")
            {
                mostrar("Usuario registrado correctamente!");
            }
            else
            {
                mostrar("Atención!\n No se pudo registrar correctamente");
            }
            //yield return new WaitForSeconds(1);
            /*
             * WWW www = new WWW(url, pData);
            yield return www;
            Debug.Log(www.text);
            if (www.text != "")
            {
                Debug.Log(www.text);
                Usuarios usuarios = JsonUtility.FromJson<Usuarios>(www.text);

                Debug.Log(usuarios.idUsuarios);
                Debug.Log(usuarios.nombreUsuarios);
                Debug.Log(usuarios.tipoUsuarios);
                Debug.Log(usuarios.username);
                Debug.Log(usuarios.contrasenaUsuarios);
                Debug.Log("COlegio " + usuarios.idColegios.nombreColegio);
                mostrar("Bienvenido!\n Sr(a):" + usuarios.nombreUsuarios + "\n" + usuarios.tipoUsuarios + "\n" + usuarios.idColegios.nombreColegio);
            }
            else
            {
                Debug.Log("Usuario no encontrado");
                mostrar("Usuario no encontrado");
            }
            ///////
        }
        else
        {
            Debug.Log("Espacios en blanco");
            mostrar("Espacios en blanco");
        }

*/
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = www.texture;
    }

    public void ingresar()
    {
        usuario = usuarioInput.text;
        contraseña = contraseñaInput.text;
        StartCoroutine(ir());
    }

    public void botonRegistrar()
    {
        usuario = usuarioInput.text;
        contraseña = contraseñaInput.text;
        StartCoroutine(registrar());
    }

    public void reim() {
        SceneManager.LoadScene("navegacion");
    }
}
