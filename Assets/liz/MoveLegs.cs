using UnityEngine;
using System.Collections;

public class MoveLegs : MonoBehaviour {


	public float top = 150f;
	public float bottom = 45f;
	public bool reverse = true;
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		if (reverse) {
			speed *= -1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localEulerAngles.y > top) {
			transform.localEulerAngles =  new Vector3(transform.localEulerAngles.x, top, transform.localEulerAngles.z);
			
			speed *= -1;
		} 
		if (transform.localEulerAngles.y < bottom) {
			transform.localEulerAngles =  new Vector3(transform.localEulerAngles.x, bottom, transform.localEulerAngles.z);

			speed *= -1;	
		
		
		}

		transform.Rotate (Vector3.up * speed * Time.deltaTime);
	}
}
