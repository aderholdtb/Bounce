using UnityEngine;
using System.Collections;

public class EnemyPlayers : MonoBehaviour {
	private int NumberOfPlayers = 1;//change to public
	private int Player1BallType = 1;//change to public 
	public int Player2BallType;
	public int Player3BallType;
	public GameObject enemy;
	Vector2 startPosition = new Vector2(1, 3);
	public Sprite skin1;

	// Use this for initialization
	void Start () {
		enemy = (GameObject)Resources.Load("Enemy");
		setBalls (NumberOfPlayers);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setBalls(int NumberOfPlayers){
		if (NumberOfPlayers > 2) {
			setBallSkin(1);
			Instantiate(enemy, new Vector3(startPosition.x, startPosition.y, 0), Quaternion.identity);
			setBallSkin(2);
			Instantiate(enemy, new Vector3(startPosition.x, startPosition.y, 0), Quaternion.identity);
			setBallSkin(3);
			Instantiate(enemy, new Vector3(startPosition.x, startPosition.y, 0), Quaternion.identity);
			//Instantiate Ball here for 3 other players
		} else if (NumberOfPlayers > 1) {
			setBallSkin(1);
			Instantiate(enemy, new Vector3(startPosition.x, startPosition.y, 0), Quaternion.identity);
			setBallSkin(2);
			Instantiate(enemy, new Vector3(startPosition.x, startPosition.y, 0), Quaternion.identity);
			//Instantiate Ball here for 2 other players
		} else if (NumberOfPlayers > 0) {
			setBallSkin(1);
			Instantiate(enemy, new Vector3(startPosition.x, startPosition.y, 0), Quaternion.identity);
			//Instantiate Ball here for 1 other players
		}
	}

	void setBallSkin(int playerNumber){
	switch (playerNumber) {
		case 1:
			getSkin(Player1BallType);
			break;
		case 2:
			getSkin(Player2BallType);
			break;
		case 3:
			getSkin(Player3BallType);
			break;
		default:
			break;
		}
	}

	void getSkin(int skinNumber){
		switch (skinNumber) {
		case 1:
			enemy.GetComponent<SpriteRenderer>().sprite = skin1;
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		default:
			break;


		}
	}
}
