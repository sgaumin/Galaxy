using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherStarHeart : MonoBehaviour {

	public bool captured;
	public float moveSpeed;
	public Transform spawnPoint; 
	public Transform followTarget;

	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		captured = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (captured) {
			targetPos = new Vector3 (followTarget.position.x, followTarget.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			followTarget = other.gameObject.transform;
			captured = true;
		}
	}

	public void resetStar(){
		captured = false;
	}

	public void resetPosition(){
		// Restart position
		gameObject.transform.position = spawnPoint.transform.position;
        resetStar();
    }
}	
