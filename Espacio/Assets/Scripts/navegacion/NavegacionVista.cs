using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavegacionVista : NavegacionElement
{
    public Slider barra;
    public Button volver;
    public Button ayuda;

    public void volverClick()
    {
        Debug.Log("Volver!");
    }

    public void ayudaClick()
    {
        Debug.Log("Ayuda!");
    }

    private void Start()
    {
        barra.value = calcular();
    }

    private void LateUpdate()
    {

        barra.value = calcular();
    }
    private float calcular()
    {
        return nav.modelo.Energia / nav.modelo.MaxEnergia;
    }

}