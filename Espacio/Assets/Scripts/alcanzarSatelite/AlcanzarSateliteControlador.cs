using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlcanzarSateliteControlador : AlcanzarSateliteElement
{

    public void toques()
    {
        app.modelo.Duracion = Time.timeSinceLevelLoad;
        if (Input.touchCount == 1)
        {
            app.modelo.Duracion_toques += Time.deltaTime;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                app.modelo.Toques++;
            }
        }
    }
    public void reiniciarValores()
    {
        app.modelo.Cantidad_colisiones = 0;
        app.modelo.Duracion = 0f;
        app.modelo.Duracion_toques = 0f;
        app.modelo.Toques = 0;
        app.modelo.Finalizado = false;
    }

}
