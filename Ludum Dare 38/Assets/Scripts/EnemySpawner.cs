using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject enemyPrefab;
    private GameObject enemy;

	// Use this for initialization
	void Start()
    {
        
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnEnemy(float enemyScale)
	{
		RotateSpawnPoint();

		enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint.transform.position, transform.rotation);
		enemy.GetComponent<Individual>().SetScale(enemyScale);

        return enemy;
	}

	// Get a random position for the enemy to spawn at.
	void RotateSpawnPoint()
	{
		int rotationZ = Random.Range(0, 360);
		Quaternion rotation = Quaternion.Euler(0, 0, rotationZ);
		this.transform.rotation = rotation;
	}
}
