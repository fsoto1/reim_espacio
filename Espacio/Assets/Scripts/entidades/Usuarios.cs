
[System.Serializable]
public class Usuario
{
    public int id;
    public string nombres;
    public string apellidoMaterno;
    public string apellidoPaterno;
    public string username;
    public string password;
    public string salt;
    public string emailAddress;
}

[System.Serializable]
public class Periodo
{
    public int id;
    public string nombre;
}


[System.Serializable]
public class Colegio
{
    public int id;
    public string nombre;
}

[System.Serializable]
public class Curso
{
    public int id;
    public string nombre;
}

public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

[System.Serializable]
public class RealizarActividad
{
    private int touchCantidad { get; set; }
    private float touchTiempo { get; set; }
    private int aciertos { get; set; }
    private int errores { get; set; }
    private int finalizado { get; set; }
    private int ayudas { get; set; }
    private int idReim = 570;
    private int idUser { get; set; }
    private int idSesion { get; set; }
    private int idActividad { get; set; }

    public RealizarActividad(int idActividad, int idSesion, int touchCantidad, float touchTiempo, int errores, int aciertos, int finalizado, int idUser, int ayudas) {
        this.touchCantidad = touchCantidad;
        this.touchTiempo = touchTiempo;
        this.aciertos = aciertos;
        this.errores = errores;
        this.finalizado = finalizado;
        this.ayudas = ayudas;
        this.idUser = idUser;
        this.idSesion = idSesion;
        this.idActividad = idActividad;
    }

}