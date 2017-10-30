
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