﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private bool isJumped = false;
	private float jump_power = 300.0f;
	private float move_speed = 0.08f;
	private bool hasGameClear = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (hasGameClear == false) {
			Move ();
		}
	}

	void Move(){
		float dx = Input.GetAxis ("Horizontal") * move_speed;
		if (Input.GetKeyDown ("right")) {
			this.transform.localRotation = new Quaternion (0, 0, 0, 0);
		}
		if (Input.GetKeyDown ("left")) {
			this.transform.localRotation = new Quaternion (0, 180, 0, 0);
		}
		if (Input.GetKey ("right")) {
			this.transform.Translate (dx, 0, 0);
		}
		if (Input.GetKey ("left")) {
			this.transform.Translate (-dx, 0, 0);
		}

		if (Input.GetKeyDown ("space") && isJumped == false) {
			this.transform.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jump_power);
			isJumped = true;
		}
	}

}
