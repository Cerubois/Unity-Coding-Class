using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

	// Target Spawner is going to spawn a number of targets in the level.
	// Info it needs:
	// - What object it needs to spawn
	// - How many objects to spawn
	// - How often does it spawn
	// - Where do we spawn objects
	// - Limitations in where they spawn

	public GameObject targetPrefab;
	public int numberToSpawn;
	public enum SpawnMode {
		SpawnAtStart,
		SpawnByTimer,
		SpawnToLimit
	}
	public SpawnMode spawnMode;
	public List<GameObject> targetList;

	public Vector3 minPos;
	public Vector3 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
		if(spawnMode == SpawnMode.SpawnAtStart) {

			for(int curTarget = 0; curTarget < numberToSpawn; curTarget++) {
				float xPos = Random.Range(minPos.x, maxPos.x);
				float yPos = Random.Range(minPos.y, maxPos.y);
				float zPos = Random.Range(minPos.z, maxPos.z);

				Instantiate(targetPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
			}

		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
