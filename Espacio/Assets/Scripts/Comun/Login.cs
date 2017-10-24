using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usuario;
    public InputField contraseña;
    public Button submit;
    private string user;
    private string pass;

    private void Update()
    {
        user = usuario.text;
        pass = contraseña.text;
        //submit.OnPointerDown.
    }

    public void ingresar() {
        Debug.Log(user+" "+pass);
    }
}
