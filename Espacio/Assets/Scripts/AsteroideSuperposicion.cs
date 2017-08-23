using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideSuperposicion : MonoBehaviour {

    // Elimina asteroides superpuestos
    void Start()
    {
           
    }

    void a(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name != "Player" || collision.gameObject.name != "Space_object_O")
        {
            Destroy(collision.gameObject);
        }
    }


}
