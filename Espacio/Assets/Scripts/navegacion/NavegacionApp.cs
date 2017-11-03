using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavegacionElement : MonoBehaviour
{
    public static NavegacionApp nav = new NavegacionApp();
}


public class NavegacionApp : MonoBehaviour
{
    public NavegacionControlador controlador = new NavegacionControlador();
    public NavegacionModelo modelo = new NavegacionModelo();
    public NavegacionVista vista = new NavegacionVista();
    public General general = new General();
    public Login login = new Login();

}
