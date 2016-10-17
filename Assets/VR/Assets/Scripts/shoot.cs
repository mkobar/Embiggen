using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	// Use this for initialization
	public GameObject projectile_prefab;
	float bulletImpulse = 50f;

	void Start () {
        //var device = SteamVR_Controller.Input((int)trackedObj.index);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {	//Change to trigger
			Camera cam = Camera.main;		//Change to vive cam
			GameObject projectile = (GameObject)Instantiate (projectile_prefab, cam.transform.position + cam.transform.forward,cam.transform.rotation);
			projectile.GetComponent<Rigidbody>().AddForce(cam.transform.forward*bulletImpulse, ForceMode.Impulse);
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
