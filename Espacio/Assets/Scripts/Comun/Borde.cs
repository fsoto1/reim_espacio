using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Borde : MonoBehaviour
{
 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("navegacion");
        }
    }
}
