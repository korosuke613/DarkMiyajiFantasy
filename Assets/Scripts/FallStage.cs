using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStage : MonoBehaviour {
	public GameObject[] oneGame;
	private Transform boardHolder;
	private Transform addedBoardHolder;
	private Transform oldAddedBoardHolder = null;
	private Transform oldOldAddedBoardHolder = null;

	private GameObject choiceData;
	private const float ADJ_X = 8.5f;
	private const float ADJ_Y = 4.5f;

	private float border; 

	private GameObject PlayerObj = null;
	private GameObject MiyajiPointUI = null;
	UpdateMIYAJI MiyajiTextScript;
	private float basisY;
	private float nowPositionY;
	private float nowPositionX;
	Player PlayerScript;

	private int[,] startStage = {
		{ 1, 1, 1, 1, 1, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 3, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 0, 0, 1, 0, 0, 1 },
		{ 1, 1, 1, 1, 1, 1 }
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
		InitPlayer ();
	}

	private void InitPlayer(){
		PlayerObj = GameObject.FindWithTag ("Player");
		basisY = PlayerObj.transform.position.y;
		border = basisY - 5.0f; // 最初の生成ステージの縦の長さ割る２
		PlayerScript = PlayerObj.GetComponent<Player>();
		MiyajiPointUI = GameObject.FindWithTag ("MiyajiUI");
		MiyajiTextScript = MiyajiPointUI.GetComponent<UpdateMIYAJI> ();
	}

	private void AddStage(int span){
		addedBoardHolder = new GameObject("addedBoard").transform;
		for (int y = 0; y < span; y++) {
			int block_num = (int)Random.Range (1, 17); 
			for (int x = 0; x < 18; x++) {
				int num;
				if (x == 0 || x == 17) {
					num = 1;
				} else {
					if (y == span-1) {
						if (x == block_num || x == block_num + 1) {
							num = 4;
						} else {
							num = 0;
						}
					} else {
							num = 0;
					}
				}
				choiceData = oneGame [num];
				GameObject obj = Instantiate (
					choiceData,
					new Vector3 (x - ADJ_X, (int)nowPositionY - y - ADJ_Y, 0),
					Quaternion.identity) as GameObject;
		
				obj.transform.SetParent (addedBoardHolder);
			}
		}
	}

	private void DestroyAddedStage(){
		if (oldOldAddedBoardHolder != null) {
			Transform.Destroy (oldOldAddedBoardHolder.gameObject);
		}
		oldOldAddedBoardHolder = oldAddedBoardHolder;
		oldAddedBoardHolder = addedBoardHolder;	
	}
	// Use this for initialization
	void Start () {
		CreateStage(startStage);
		AddStage (5);
	}

	void FixedUpdate(){
		nowPositionY = PlayerObj.transform.position.y;
		if (nowPositionY < border) {
			if (PlayerScript.hasMiyaji == true) {
				nowPositionX = PlayerObj.transform.position.x;
				border = nowPositionY - 5.0f;
				DestroyAddedStage ();
				AddStage (5);
				PlayerScript.hasMiyaji = false;
			} else {
				Player.hasGameClear = true;
			}
		}
		MiyajiTextScript.UpdateText (Score.MiyajiPoint.ToString ());
	}
}
