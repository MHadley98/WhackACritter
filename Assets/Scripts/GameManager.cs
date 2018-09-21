using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency=1.0f;
    public Score scoreDisplay;
    public Timer timer;

    private float lastCritterSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //check if it is time to spawn the next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;
		if (Time.time >= nextSpawnTime&&timer.IsTimerRunning()==true)
        {
            //it's time
            //choose a random critter to spawn
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            //Spawn the critter
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            //get access to critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            //tEll th ecritter script the score object
            critterScript.scoreDisplay = scoreDisplay;

            //upadte the most recent critter spawn time to now
            lastCritterSpawn = Time.time;

        }
	}
}
