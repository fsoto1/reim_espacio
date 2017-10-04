using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenarFigurasElement : NavegacionElement
{
    // Gives access to the application and all instances.
    //public static AlcanzarSateliteApp app { get { return GameObject.FindObjectOfType<AlcanzarSateliteApp>(); } }
    public static OrdenarFigurasApp app = new OrdenarFigurasApp();
}


public class OrdenarFigurasApp : MonoBehaviour
{
    public OrdenarFigurasControlador controlador = new OrdenarFigurasControlador();
    public OrdenarFigurasModelo modelo = new OrdenarFigurasModelo();
    public OrdenarFigurasVista vista = new OrdenarFigurasVista();
    
}

