using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgMiyaji : MonoBehaviour {
	public Text text;
	//private GameObject Player = null;
	//Player MiyajiTextScript;
	// Use this for initialization
	void Start () {
		//Player = GameObject.FindWithTag ("Player");
		//MiyajiTextScript = Player.GetComponent<Player> ();
		UpdateText();
	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateText(){
		text = this.GetComponent<Text>(); // <---- 追加3
		text.text = Player.MiyajiPoint.ToString() + " MIYAJI"; // <---- 追加4
		//text.text = MiyajiTextScript.ToString() + " MIYAJI";
	}
}
