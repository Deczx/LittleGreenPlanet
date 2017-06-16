using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population  {

    Individual[] individuals;
    private float enemyScale = 0.6f;

    public Population(int populationSize, bool initialize)
    {
        individuals = new Individual[populationSize];
        
        if (initialize)
        {
            for (int i = 0; i < individuals.Length ; i++)
            {
                //Individual newIndividual = new Individual();
                individuals[i].GenerateIndividual(populationSize, enemyScale);
               // this.GetComponent<Individual>().GenerateIndividual(populationSize, enemyScale);
            }
        }
    }
	
	public Individual GetIndividual(int index)
	{
		return individuals[index];
	}

	public Individual GetFittest()
	{
		Individual fittest = individuals[0];
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
	public void SaveIndividual(int index, Individual indiv)
	{
		individuals[index] = indiv;
	}
}
