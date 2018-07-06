using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerNumber;
	public GameObject spawnPoint;
	public GameObject objectBullet;
	public GameObject boostEffect;
	public float moveSpeed;
	public float moveDuration;
	public float waitDuration;
	public float moveSpeedRotation;
	public float timeToShoot;
	public float timeToReloadBoost;
	public float[] timeToReloadBoostTemp;
	public float timeToWin;
	public string jumpCmd;
	public string fireCmd;
	public string horizontalCmd;

	private Animator anim;
	private Rigidbody2D theRB;
	private MotherStarHeart theMSHM;
	private int nbBoostmax = 3;
	private int nbBoost;
	private float moveDurationTemp;
	private float waitDurationTemp;
	private float timeToShootTemp;
	private float timeToWinTemp;
	private bool moving;
	private bool shooting;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
		theMSHM = FindObjectOfType<MotherStarHeart> ();

		moving = false;
		shooting = false;
		moveDurationTemp = -1f;
		timeToShootTemp = -1f;
		nbBoost = nbBoostmax;
		timeToWinTemp = timeToWin;  // Variable a mettre dans le GameManager

        // A indiquer dans l'editeur
		if (playerNumber == 1) {
			jumpCmd = "Jump";
			fireCmd = "Fire1";
			horizontalCmd = "Horizontal";

		} else if (playerNumber == 2) {
			jumpCmd = "Jump p2";
			fireCmd = "Fire p2";
			horizontalCmd = "Horizontal p2";
		}
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 move = Vector3.zero;
		move.z = Input.GetAxisRaw (horizontalCmd);
		//move.z = Input.GetAxisRaw ("Vertical");
		gameObject.transform.Rotate (move * moveSpeedRotation);

		if (!moving) {

			moveDurationTemp -= Time.deltaTime;

			if (moveDurationTemp < 0f && Input.GetButton  (jumpCmd) && nbBoost > 0) {
				moving = true;
				moveDurationTemp = moveDuration;
				if (timeToReloadBoostTemp[0] <= 0f) {
					timeToReloadBoostTemp[0] = timeToReloadBoost;
				} else if (timeToReloadBoostTemp[1] <= 0f) {
					timeToReloadBoostTemp[1] = timeToReloadBoost;
				} else if (timeToReloadBoostTemp[2] <= 0f) {
					timeToReloadBoostTemp[2] = timeToReloadBoost;
				}
				nbBoost--;
				GameObject effect = Instantiate (boostEffect, transform.position, Quaternion.AngleAxis(90, transform.right) * transform.rotation);
                //effect.transform.SetParent(transform.parent);
            }
		}
			
//		if (nbBoost < nbBoostmax) {
			for (int i = 0; i < nbBoostmax; i++) {
				if (timeToReloadBoostTemp[i]>0f) {
					timeToReloadBoostTemp [i] -= Time.deltaTime;
				}
				if (timeToReloadBoostTemp [i]<0f ) {
					nbBoost++;
					timeToReloadBoostTemp [i] = -0f;
				}
			}
//		}

		if (moving) {
			moveDurationTemp -= Time.deltaTime;
			theRB.velocity = gameObject.transform.up * moveSpeed;
			if (moveDurationTemp < 0f) {
				moving = false;
				moveDurationTemp = waitDuration;
				theRB.velocity = Vector2.zero;
			}
		}

		if (!shooting) {
			if (Input.GetButton(fireCmd)) {
				GameObject bullet = Instantiate(objectBullet, transform.up + transform.position, Quaternion.AngleAxis(90, Vector3.forward) * transform.rotation);
                bullet.transform.SetParent(transform.parent);
                shooting = true;
				timeToShootTemp = timeToShoot;
			}
		} else if(shooting){
			timeToShootTemp -= Time.deltaTime;
			if (timeToShootTemp < 0f) {
				shooting = false;
			}
		}

		if (theMSHM.captured) {
			
			timeToWinTemp -= Time.deltaTime;
			if (timeToWinTemp < 0) {
				
				if (playerNumber == 1) {
					UIManager.instance.changeScore (1);
				} else if (playerNumber == 2) {
                    UIManager.instance.changeScore (2);
				}


				// Restart position
				gameObject.transform.position = spawnPoint.transform.position;
					
				timeToWinTemp = 0;
				theMSHM.resetPosition ();

			}
		} else if(!theMSHM.captured) {
			
			timeToWinTemp = timeToWin;

		}

		anim.SetInteger ("nbBoost", nbBoost);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Star" || other.gameObject.tag == "Mother Star" ) {
			Restart();
		}
	}
	
    // TO DO - A mettre dans un script GameManager
	private void Restart(){
		// Stop Star Heart following
		theMSHM.resetStar();

		// Restart position
		gameObject.transform.position = spawnPoint.transform.position;

		// Initialize Rotation
		if (playerNumber == 1) {
			gameObject.transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward) * Quaternion.Euler (Vector3.zero);
		} else if (playerNumber == 2) {
			gameObject.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward) * Quaternion.Euler (Vector3.zero);
		}
		// Reset Boost
		nbBoost = 3;
		for (int i = 0; i < nbBoostmax; i++) {
			timeToReloadBoostTemp [i] = 0;
		}
	}
}
