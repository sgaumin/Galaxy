using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

	public Transform target;
	public float speedSelfRotate;
	public float speedTargetRotate;
	public bool inverseRotation;
	
	// Update is called once per frame
	void Update () {
		if (!inverseRotation) {
			gameObject.transform.RotateAround (target.position, target.forward, speedTargetRotate * Time.deltaTime);
			gameObject.transform.RotateAround (transform.position, transform.forward, speedSelfRotate * Time.deltaTime);
		} else {
			gameObject.transform.RotateAround (target.position, target.forward, -speedTargetRotate * Time.deltaTime);
			gameObject.transform.RotateAround (transform.position, transform.forward, -speedSelfRotate * Time.deltaTime);
		}

	}
}
