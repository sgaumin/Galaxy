using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float moveSpeed;
	public int numberDamage;

	private Rigidbody2D theRD;

	// Use this for initialization
	void Start () {
		theRD = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		theRD.velocity = gameObject.transform.right * moveSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Star") {
			Destroy (gameObject);
		} else if (other.gameObject.tag == "Mother Star") {
			Destroy (gameObject);
            other.GetComponent<MotherStar>().AddDamage (numberDamage);
		}
	}
}
