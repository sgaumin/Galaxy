using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyObject : MonoBehaviour {

	public float timeToDestroy;
	private float timeToDestroyTemp;

	// Use this for initialization
	void Start () {
		timeToDestroyTemp = timeToDestroy;
	}
	
	// Update is called once per frame
	void Update () {
		timeToDestroyTemp -= Time.deltaTime;
		if (timeToDestroyTemp < 0f) {
			Destroy (gameObject);
		}
	}
}
