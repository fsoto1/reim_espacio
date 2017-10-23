using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarObjetosElement : NavegacionElement
{
    public static RecolectarObjetosApp app = new RecolectarObjetosApp();
}


public class RecolectarObjetosApp : MonoBehaviour
{
    public RecolectarObjetosControlador controlador = new RecolectarObjetosControlador();
    public RecolectarObjetosModelo modelo = new RecolectarObjetosModelo();
    public RecolectarObjetosVista vista = new RecolectarObjetosVista();

}
