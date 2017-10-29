using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgMiyaji : MonoBehaviour {
	public Text text;
	void Start () {
		UpdateText();
	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateText(){
		text = this.GetComponent<Text>(); // <---- 追加3
		text.text = Player.MiyajiPoint.ToString() + " MIYAJI"; // <---- 追加4
	}
}
