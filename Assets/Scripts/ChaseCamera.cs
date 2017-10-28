using UnityEngine;
using System.Collections;

public class ChaseCamera : MonoBehaviour {

	GameObject Player = null;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera");
	}
	// Update is called once per frame
	void Update () {
		if (Player == null) {
			Player = GameObject.FindWithTag ("Player");
		}
		mainCamera.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

	}
}