using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavegacionModelo : NavegacionElement
{

    private int energia;

    public int Energia
    {
        get
        {
            return energia;
        }

        set
        {
            energia = value;
        }
    }
}