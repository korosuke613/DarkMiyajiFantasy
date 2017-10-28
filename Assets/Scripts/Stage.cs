using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
	public GameObject[] oneGame;
	private Transform boardHolder;

	private GameObject choiceData;
	private const float ADJ_X = 8.5f;
	private const float ADJ_Y = 4.5f;

	private int[,] firstStageMapData = {
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 0, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 1 },
		{ 1, 1, 0, 0, 0, 0, 0, 1, 1, 1 },
		{ 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 1, 0, 0, 1, 1, 0, 1, 1, 1 },
		{ 1, 1, 0, 0, 1, 1, 0, 1, 1, 1 },
		{ 1, 1, 0, 0, 0, 0, 0, 1, 1, 1 },
		{ 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 },
		{ 1, 1, 1, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 0, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 2, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
	};

	private int[,] secondStageMapData = {
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
		{ 1, 1, 1, 0, 0, 1, 0, 0, 1, 1 },
		{ 1, 1, 1, 0, 0, 1, 0, 0, 0, 1 },
		{ 1, 1, 1, 0, 0, 1, 0, 0, 0, 1 },
		{ 1, 1, 1, 0, 0, 1, 2, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 1, 1, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 1, 1, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
		{ 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 },
		{ 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 },
		{ 1, 1, 0, 0, 0, 0, 0, 1, 1, 1 },
		{ 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 },
		{ 1, 1, 1, 0, 0, 0, 1, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 0, 1, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 0, 0, 0, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
	};

	private void CreateStage(){
		boardHolder = new GameObject("Board").transform;

		for(int i = 0; i < firstStageMapData.GetLength(0); i++){
			for(int j = 0; j < firstStageMapData.GetLength(1); j++){
				int num = firstStageMapData[i, j];
				choiceData = oneGame[num];
				GameObject obj = Instantiate(choiceData, new Vector3(i - ADJ_X, j - ADJ_Y, 0), Quaternion.identity) as GameObject;
				obj.transform.SetParent(boardHolder);
			}
		}
	}

	// Use this for initialization
	void Start () {
		CreateStage ();			
	}
}
