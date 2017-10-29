﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int MiyajiPointTotal = 0;
	public static int MiyajiPoint = 0;

	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void ResetMiyajiPoint(){
		MiyajiPoint = 0;
	}

	public void ResetTotalMiyajiPoint(){
		MiyajiPointTotal = 0;
	}

	public static void AddMiyajiPoint(int additional){
		MiyajiPoint += additional;
		MiyajiPointTotal += additional;
	}
}
