using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

	public Vector3 direction = new Vector3(0f, 0f, 1f);
	public float speed = 1f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate(direction * speed * Time.deltaTime,  Space.Self);
		if (transform.localPosition.z > 2200f) {
			transform.Translate(new Vector3(0f,0f,-2200f));
		}
	}
}
