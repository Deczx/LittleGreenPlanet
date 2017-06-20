using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population {

    GameObject[] individuals;
    private float enemyScale = 0.6f;
    private float spawnDelay = 0.1f;

    private int deadIndividuals;

    public Population(int populationSize, bool initialize)
    {
        individuals = new GameObject[populationSize];

        if (initialize)
        {
            for (int i = 0; i < Size(); i++)
            {
				GameObject enemy = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>().SpawnEnemy(enemyScale);
				SaveIndividual(i, enemy);
            }
        }
    }

	public GameObject GetIndividual(int index)
	{
		return individuals[index];
	}

	public GameObject GetFittest()
	{
		GameObject fittest = individuals[0];
		// Loop through individuals to find fittest
		for (int i = 0; i < Size(); i++)
		{
			if (fittest.GetComponent<Individual>().GetFitness() <= GetIndividual(i).GetComponent<Individual>().GetFitness())
			{
				fittest = GetIndividual(i);
			}
		}
		return fittest;
	}

    public int Size()
    {
        return individuals.Length;
    }

	// Save individual
	public void SaveIndividual(int index, GameObject indiv)
	{
		individuals[index] = indiv;
	}

    public void IncreaseDeadIndividuals()
    {
        if (deadIndividuals < Size())
		{
			deadIndividuals++;
            Debug.Log(deadIndividuals);
        }

        if (deadIndividuals >= Size())
        {
            deadIndividuals = 0;
            Debug.Log(deadIndividuals);
            GameObject.FindWithTag("EnemySpawner").GetComponent<GA>().NewPopulation();
        }
    }

    public int GetDeadIndividuals()
    {
        return deadIndividuals;
    }
}
