using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private bool isJumped = false;
	private float jump_power = 300.0f;
	private float move_speed = 0.08f;
	public static bool hasGameClear = false;
	public bool hasMiyaji = true;
	private GameObject MiyajiPointUI = null;
	UpdateMIYAJI MiyajiTextScript;

	// Use this for initialization
	void Start () {
	}

	void Awake()
	{
		//DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (hasGameClear == false) {
			Move ();
		} else {
			SceneManager.LoadScene ("GameClear");
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

	void OnCollisionEnter2D(Collision2D collision_event){
		if (collision_event.gameObject.tag == "Ground") {
			isJumped = false;
		}
		if (collision_event.gameObject.tag == "MiyajiGround") {
			if (hasMiyaji == false) {
				Score.AddMiyajiPoint(1);
				hasMiyaji = true;
			}
			isJumped = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider_event){
		if (collider_event.gameObject.tag == "Flag") {
			Destroy (collider_event);
			hasGameClear = true;
		}
	}
}
