using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject ant;
	public float spawnTime = 1f;
	public Transform[] spawnPoints;
	public int antCount = 0;
	public int totalCount = 0;
    public GameObject GameWorld;
    public bool isConflicting = true;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameWorld.transform.localScale.x <= 0.05f && isConflicting)
        {
            isConflicting = false;
            InvokeRepeating("spawn", spawnTime, spawnTime);
        }
	}

	void spawn(){
       
        if (antCount < 5 && totalCount < 6) {
           
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            
            Instantiate (ant, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			antCount++;
			totalCount++;
            
        }
	}

	public void antDeath(){
		antCount--;
	}
}
