using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour {
    public float velocidad = 5f;
    private Vector3 coordenadas;
    private Vector3 posicion;

    void FixedUpdate () {

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // GetComponent<Rigidbody>().position.y - Camera.main.transform.position.y
                coordenadas = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,  5f );
                posicion = Camera.main.ScreenToWorldPoint(coordenadas);
                //transform.LookAt(posicion);
                //transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, posicion, velocidad * Time.deltaTime);
            }

        }
    }
}
