using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {

	void Start () {
		this.transform.position = Input.mousePosition;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = Input.mousePosition;
	}
}
