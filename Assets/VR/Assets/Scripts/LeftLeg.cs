using UnityEngine;
using System.Collections;

public class LeftLeg : MonoBehaviour {

	float rotateTime = .1f;
	int rotateAngle = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	//Rotate Left legs Back and Forth
	void Update () {

		if (rotateTime > 0) {
			gameObject.transform.Rotate (0, 0, rotateAngle);
			rotateTime -= Time.deltaTime;
		} else {
			rotateTime = .1f;
			rotateAngle = -rotateAngle;
		}
	}
}
