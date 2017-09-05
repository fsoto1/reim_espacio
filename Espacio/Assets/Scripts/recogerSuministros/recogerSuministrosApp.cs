using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerSuministrosElement : NavegacionElement
{
    public static RecogerSuministrosApp app = new RecogerSuministrosApp();
}


public class RecogerSuministrosApp : MonoBehaviour
{
    public AlcanzarSateliteControlador controlador = new AlcanzarSateliteControlador();
    public AlcanzarSateliteModelo modelo = new AlcanzarSateliteModelo();
    public AlcanzarSateliteVista vista = new AlcanzarSateliteVista();
    
}

