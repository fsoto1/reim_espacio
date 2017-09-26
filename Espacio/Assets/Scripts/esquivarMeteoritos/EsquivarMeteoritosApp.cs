using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquivarMeteoritosElement : NavegacionElement
{
    public static EsquivarMeteoritosApp app = new EsquivarMeteoritosApp();
}


public class EsquivarMeteoritosApp : MonoBehaviour
{
    public EsquivarMeteoritosControlador controlador = new EsquivarMeteoritosControlador();
    public EsquivarMeteoritosModelo modelo = new EsquivarMeteoritosModelo();
    public EsquivarMeteoritosVista vista = new EsquivarMeteoritosVista();

}
