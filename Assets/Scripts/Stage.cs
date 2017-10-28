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
		{ 1, 1, 1, 1, 1, 1, 2, 0, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
	};

	private int[,] secondStageMapData = {
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
	};

	private void CreateStage(int [,] stageMap){
		//親となるコンテナを作成
		boardHolder = new GameObject("Board").transform;

		for(int i = 0; i < stageMap.GetLength(0); i++){
			for(int j = 0; j < stageMap.GetLength(1); j++){
				int num = stageMap[i, j];
				choiceData = oneGame[num];
				// ゲームオブジェクトの生成
				GameObject obj = Instantiate(
					choiceData,  // 生成するデータ
					new Vector3(i - ADJ_X, j - ADJ_Y, 0), //生成する場所 
					Quaternion.identity) as GameObject;

				//Boardコンテナにブロックを子として設定
				obj.transform.SetParent(boardHolder);
			}
		}
	}

	// Use this for initialization
	void Start () {
		CreateStage (firstStageMapData);
	}
}
