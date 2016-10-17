using UnityEngine;
using System.Collections;

public class projectileExplosion : MonoBehaviour {

	float lifespan = 2.0f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0) {
			Explode ();
		}
      //  GetComponent<Rigidbody>().AddForce();

    }

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ant") {
			Destroy (gameObject);
			Health anthealth = col.gameObject.GetComponent<Health>();
			anthealth.AntHit ();
		}
	}

	void Explode(){
		Destroy (gameObject);
	}
}
