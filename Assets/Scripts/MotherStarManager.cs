using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherStarManager : MonoBehaviour {

	public float maxHealth;
	public float moveSpeed;
	public GameObject followTarget;

	private Vector3 targetPos;
	private float currentHealth;

	// Use this for initialization
	public void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}

	public void AddDamage(float damageToGive){
		currentHealth -= damageToGive;
	}

	public float GetCurrentHealth(){
		return currentHealth;
	}

	public void SetCurrentHealth(float value){
		currentHealth = value;
	}
		
}
