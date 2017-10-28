using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgMiyaji2 : MonoBehaviour {
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

	string CreateMiyajiMIKOTONORI(){
		int msg_num = (int)Random.Range (0, 6); 
		string msg;
		switch(msg_num){
		case 0:
			msg = "おめでとう\nこれで君もC++初学者だ";
			break;
		case 1:
			msg = "大丈夫\n僕もC++初学者だから";
			break;

		case 2:
			msg = "ﾌﾞﾋｨ！！";
			break;

		case 3:
			msg = "その書き方古いよ(笑)";
			break;

		case 4:
			msg = "僕、clang使うから\ngccわかんない";
			break;

		case 5:
			msg = "Testing A Miyaji\nI'm Yes A System";
			break;

		default:
			msg = "おめでとう\nこれで君もC++初学者だ";
			break;


		}

		return msg;
	}
	public void UpdateText(){
		text = this.GetComponent<Text>(); // <---- 追加3
		text.text = CreateMiyajiMIKOTONORI(); // <---- 追加4
		//text.text = MiyajiTextScript.ToString() + " MIYAJI";
	}
}
