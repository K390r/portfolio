using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	Rigidbody rb;
	Transform tr;
	float v,x,h,num=1.6f,y,g=1.5f;
	bool check,H,jump,gg=false;
	public Rigidbody rb2;
	public Rigidbody[] rb4;
	public Transform[] tr4;
	public Transform tr2,tr3;
	public Transform[] enemy;
	public Rigidbody[] enemyp;
	bool complete=false;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
	}

	void Update () {
		if(!gg){
			v = Input.GetAxis ("Vertical");
			rb.AddForce (tr.forward * v * 50f);
			h = Input.GetAxis ("Horizontal");
			rb.AddForce (tr.right * h * 50f);
		}
		x = Input.GetAxis ("Mouse X");
		Vector3 mouseX = new Vector3 (0, x, 0);

		tr.Rotate (mouseX * 5f);

		y = Input.GetAxis ("Mouse Y");
		Vector3 mouseY = new Vector3 (y, 0, 0);

		tr2.Rotate (mouseY * 5f);


		H = Input.GetKeyDown (KeyCode.Space);
		if (check) {
			num = num - Time.deltaTime;
			Debug.Log (num);
		} else {
			num = 1.6f;
		}

		for (int i = 0; i < enemyp.Length; i++) {
			if (Vector3.Distance (tr.position, enemy [i].position) <= 1.42f && !jump) {
				enemyp[i].isKinematic = false;
			}
		}
		for (int i = 0; i < rb4.Length; i++) {
			if (Vector3.Distance (tr.position, tr4 [i].position) <= 1.42f && !complete) {
				rb4[i].isKinematic = false;
			}
		}
		if(enemy[0].position.y<=4){
			enemyp[0].isKinematic = true;
		}
		if (jump) {
			if (H) {
				Vector3 up = new Vector3 (0, 1, 0);
				rb.AddForce (up * 600f);
				check = true;
				jump = false;
			}

		} else {
			if (num <= 0) {
				gg = true;
				num = 1.6f;
			} 
		}
		Vector3 rotateObj = new Vector3 (0, g, 0);
		if (Vector3.Distance (tr.position, tr3.position) <= 5.0f) {
			tr3.Rotate(rotateObj);
		}
	}

	void OnCollisionEnter(Collision arg){
		if (arg.gameObject.tag == "lava") {
			Debug.Log ("Вы утонули в лаве");
			jump = false;
			gg = true;
			check =false;
		}
		if (arg.gameObject.tag == "Finish") {
			Debug.Log ("You win!");
			jump = true;
			check = false;
		}
		if (arg.gameObject.tag == "floor"||arg.gameObject.tag=="false2"||arg.gameObject.tag=="Rotate"||arg.gameObject.tag=="floor2"||arg.gameObject.tag == "false1") {
			if (tr.position.y <= arg.gameObject.transform.position.y) {
				jump = false;
			} else {
				jump = true;
			}
			check =false;
			if (gg) {
				Debug.Log ("Вы разбились");
				jump = false;
			}
		}
		if (arg.gameObject.tag == "fireball") {
			jump = false;
			gg = true;
			check =false;
			Debug.Log ("Вы сгорели");
		}
		if (arg.gameObject.tag == "floor2") {
			complete = true;
		}
	}
}
