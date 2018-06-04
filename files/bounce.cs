using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision arg){
		if (arg.gameObject.tag == "lava") {
			Vector3 boing = new Vector3 (0, 1f, 0);
			rb.AddForce (boing * 660f);
		}
	}
}
