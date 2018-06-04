using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor2 : MonoBehaviour {
	Transform tr;
	Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tr.eulerAngles.z <= 20) {
			rb.isKinematic = true;
		}
	}
}
