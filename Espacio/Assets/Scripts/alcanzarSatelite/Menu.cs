using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : AlcanzarSateliteElement
{

    public GameObject menu; 
    private bool mostrar;
    // Use this for initialization
    public void Cambiar(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        menu.SetActive(false);
    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Menu))
        {
            mostrar = !mostrar;
            menu.SetActive(mostrar);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }
}
