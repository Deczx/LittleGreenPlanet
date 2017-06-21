using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population {

    GameObject[] individuals;
    private float enemyScale;
    private float spawnDelay = 0.1f;
    private int totalFitness, averageFitness;
    private int deadIndividuals;
    private static int reachedIndividuals;

	public Population(int populationSize, bool initialize, float scale)
	{
		individuals = new GameObject[populationSize];
        enemyScale = scale;

		if (initialize)
		{
			for (int i = 0; i < Size(); i++)
			{
				GameObject enemy = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>().SpawnEnemy(scale);
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
        }

        if (deadIndividuals >= Size())
        {
            CalculatePopulationFitness();
            deadIndividuals = 0;
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

    public static void IncrementReached()
    {
        reachedIndividuals++;
    }

	public void ResetReached()
	{
		reachedIndividuals = 0;
	}

    public int GetReached()
    {
        return reachedIndividuals;
    }
}
