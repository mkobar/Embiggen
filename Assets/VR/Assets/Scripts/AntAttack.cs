using UnityEngine;
using System.Collections;

public class AntAttack : MonoBehaviour {
	GameObject player;
	float speed =0.01f;
	GameObject canvasGr;
	DamageFlash damageFlash;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainCamera");
		canvasGr = GameObject.FindGameObjectWithTag ("Flash");
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (player.transform.position);
		gameObject.transform.position += transform.forward * speed * (Time.deltaTime);
	}


	//In order for this to work the player must have a rigidbody and box collider
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "MainCamera") {
			damageFlash = canvasGr.GetComponent<DamageFlash>();
			damageFlash.damage();
		}
	}
		

}
