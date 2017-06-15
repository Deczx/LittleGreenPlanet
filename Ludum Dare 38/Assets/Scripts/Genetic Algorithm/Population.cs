using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour {

    GameObject[] individuals;
    private float enemyScale = 0.6f;

    public Population(int populationSize, bool initialize)
    {
        individuals = new GameObject[populationSize];

        if (initialize)
        {
            for (int i = 0; i < Size(); i++)
            {
                this.GetComponent<Individual>().GenerateIndividual(populationSize, enemyScale);
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
			if (fittest.GetComponent<EnemyTraits>().GetFitness() <= GetIndividual(i).GetComponent<EnemyTraits>().GetFitness())
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
}
