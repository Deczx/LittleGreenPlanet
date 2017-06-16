using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour {

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
}
