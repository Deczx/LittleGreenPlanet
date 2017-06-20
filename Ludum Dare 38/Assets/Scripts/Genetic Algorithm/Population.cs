using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population {

    GameObject[] individuals;
    private float enemyScale = 0.6f;
    private float spawnDelay = 0.1f;
    private int totalFitness, averageFitness;
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
            CalculatePopulationFitness();
            deadIndividuals = 0;
            Debug.Log(deadIndividuals);
            GameObject.FindWithTag("EnemySpawner").GetComponent<GA>().NewPopulation();
        }
    }

    public int GetDeadIndividuals()
    {
        return deadIndividuals;
    }

    public void SetEnemyScale(float value)
    {
        enemyScale = value;
    }

    public float GetEnemyScale()
    {
        return enemyScale;
    }

    private void CalculatePopulationFitness()
    {
        for (int i = 0; i < Size(); i++)
        {
            totalFitness += GetIndividual(i).GetComponent<Individual>().GetFitness();
        }
        averageFitness = totalFitness / Size();
    }

    public int GetAverageFitness()
    {
        return averageFitness;
    }
}
