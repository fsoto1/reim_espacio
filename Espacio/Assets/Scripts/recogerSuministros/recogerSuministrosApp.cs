using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerSuministrosElement : NavegacionElement
{
    public static RecogerSuministrosApp app = new RecogerSuministrosApp();
}


public class RecogerSuministrosApp : MonoBehaviour
{
    public RecogerSuministrosControlador controlador = new RecogerSuministrosControlador();
    public RecogerSuministrosModelo modelo = new RecogerSuministrosModelo();
    public RecogerSuministrosVista vista = new RecogerSuministrosVista();

}
