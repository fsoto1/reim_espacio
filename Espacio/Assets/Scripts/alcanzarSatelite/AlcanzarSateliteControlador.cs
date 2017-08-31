using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlcanzarSateliteControlador : AlcanzarSateliteElement
{

    // Detecta la colision con objetos
    

    void Update()
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

    

}
