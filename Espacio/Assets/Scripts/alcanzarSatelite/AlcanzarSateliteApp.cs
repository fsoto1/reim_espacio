using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcanzarSateliteElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    //public static AlcanzarSateliteApp app { get { return GameObject.FindObjectOfType<AlcanzarSateliteApp>(); } }
    public static AlcanzarSateliteApp app = new AlcanzarSateliteApp();
}


public class AlcanzarSateliteApp : MonoBehaviour
{
    public AlcanzarSateliteControlador controlador = new AlcanzarSateliteControlador();
    public AlcanzarSateliteModelo modelo = new AlcanzarSateliteModelo();
    public AlcanzarSateliteVista vista = new AlcanzarSateliteVista();
}

