using UnityEngine;
using System.Collections;

public class Mandibles : MonoBehaviour {

	float rotateTime = .2f;
	int rotateAngle = -3;
	// Use this for initialization
	void Start () {

	}

	//Rotate Left legs Back and Forth
	void Update () {

		if (rotateTime > 0) {
			gameObject.transform.Rotate (rotateAngle,0 , 0);
			rotateTime -= Time.deltaTime;
		} else {
			rotateTime = .2f;
			rotateAngle = -rotateAngle;
		}
	}
}
