using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount == 1) {
           // Debug.Log(Input.touchCount);
           // Debug.Log(Input.GetTouch(0).position);
            if (Input.GetTouch(0).phase == TouchPhase.Began){
                Debug.Log("Began");
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved){
                Debug.Log("Moved");
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended){
                Debug.Log("Ended");
            }

        }       
		
	}
}
