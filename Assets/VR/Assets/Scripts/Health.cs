using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int hp = 3;
	Spawn spawn;
	GameObject spawner;

	void Start(){
		spawner = GameObject.FindGameObjectWithTag("SpawnManager");
	}

	public void AntHit(){
		hp = hp - 1;
		if (hp <= 0) {
			spawn = spawner.GetComponent<Spawn> ();
			spawn.antDeath ();
			Destroy (gameObject);
		}
	}
		
}
