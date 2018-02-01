using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

	public GameObject target;
	public float speedSelfRotate;
	public float speedTargetRotate;
	public bool inverseRotation;
	
	// Update is called once per frame
	void Update () {
		if (!inverseRotation) {
			gameObject.transform.RotateAround (target.transform.position, target.transform.forward, speedTargetRotate * Time.deltaTime);
			gameObject.transform.RotateAround (transform.position, transform.forward, speedSelfRotate * Time.deltaTime);
		} else {
			gameObject.transform.RotateAround (target.transform.position, target.transform.forward, -speedTargetRotate * Time.deltaTime);
			gameObject.transform.RotateAround (transform.position, transform.forward, -speedSelfRotate * Time.deltaTime);
		}

	}
}
