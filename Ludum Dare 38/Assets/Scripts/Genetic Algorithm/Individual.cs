using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject spawnPoint;

	public float spawnDelay;

	// Create a random individual
	public void GenerateIndividual(int popSize, float enemyScale)
	{
        for (int i = 0; i < popSize; i++)
		{
            StartCoroutine(SpawnEnemy(i * spawnDelay, enemyScale, i));
		}
	}

	/* Getters and setters */
	//public static void SetDefaultGeneLength(int length)
	//{
	//	defaultGeneLength = length;
	//}

	//public byte GetGene(int index)
	//{
	//	return genes[index];
	//}

	//public void SetGene(int index, byte value)
	//{
	//	genes[index] = value;
	//	fitness = 0;
	//}

	/* Public methods */
	//public int Size()
	//{
	//	return genes.Length;
	//}

	//public string ToString()
	//{
	//	string geneString = "";
	//	for (int i = 0; i < Size(); i++)
	//	{
	//		geneString += GetGene(i);
	//	}
	//	return geneString;
	//}

    IEnumerator SpawnEnemy(float waitTime, float enemyScale, int enemyCount)
    {
        yield return new WaitForSeconds(waitTime);

        RotateSpawnPoint();
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint.transform.position, transform.rotation);
		enemy.GetComponent<EnemyTraits>().SetScale(enemyScale);
		this.GetComponent<Population>().SaveIndividual(enemyCount, enemy);
    }

	// Get a random position for the enemy to spawn at.
	void RotateSpawnPoint()
	{
		int rotationZ = Random.Range(0, 360);
		Quaternion rotation = Quaternion.Euler(0, 0, rotationZ);
		this.transform.rotation = rotation;
	}
}
