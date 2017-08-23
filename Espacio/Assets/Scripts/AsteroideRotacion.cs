using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideRotacion : MonoBehaviour {

    public float rotacion;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotacion;
    }
}
