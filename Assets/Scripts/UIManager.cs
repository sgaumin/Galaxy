using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text playerScore;

	private int score1;
	private int score2;

	// Use this for initialization
	void Start () {
		score1 = 0;
		score2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeScore(int player){

		if (player == 1) {
			score1++;
		} else if (player == 2) {
			score2++;
		}

		playerScore.text = score1 + "|" + score2;
	}
}
