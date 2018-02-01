using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject MotherStar;
	public GameObject MotherStarHeart;
	public float TimeToReload;

	private MotherStarManager theMSM;
	private MotherStarHeartManager theMSHM;
	private float TimeToReloadTemp;
	private float currentMSHealth;

	// Use this for initialization
	void Start () {
		theMSM = MotherStar.GetComponent<MotherStarManager> ();
		theMSHM = MotherStarHeart.GetComponent<MotherStarHeartManager> ();
		theMSM.Start ();
	}
	
	// Update is called once per frame
	void Update () {

		currentMSHealth = theMSM.GetCurrentHealth();

		if (currentMSHealth <= 0f) {
			MotherStar.SetActive (false);
			TimeToReloadTemp = TimeToReload;
			theMSM.SetCurrentHealth(theMSM.maxHealth);

		}

		if (TimeToReloadTemp > 0f) {
			TimeToReloadTemp -= Time.deltaTime;
		} 

		else if (TimeToReloadTemp < 0f && !theMSHM.captured) {
			
			MotherStar.SetActive (true);
		}
	}
}
