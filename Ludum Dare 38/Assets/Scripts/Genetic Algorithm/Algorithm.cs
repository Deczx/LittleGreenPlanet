using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm : MonoBehaviour {


	/* GA parameters */
	private static double mutationRate = 0.015;
	private static bool elitism = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
        
	}

	/* Public methods */
	// Evolve a population
	public static Population EvolvePopulation(Population pop)
	{
		Population newPopulation = new Population(pop.Size(), true);

		// Keep our best individual
		if (elitism)
		{
			newPopulation.SaveIndividual(0, pop.GetFittest());
		}

		// Crossover population
		int elitismOffset;
		if (elitism)
		{
			elitismOffset = 1;
		}
		else
		{
			elitismOffset = 0;
		}
		// Loop over the population size and create new individuals with
		// crossover
		for (int i = elitismOffset; i < pop.Size(); i++)
		{
			//GameObject indiv1 = TournamentSelection(pop);
			//GameObject indiv2 = TournamentSelection(pop);
			//GameObject newIndiv = Crossover(indiv1, indiv2);
			//newPopulation.SaveIndividual(i, newIndiv);
		}

		// Mutate population
		for (int i = elitismOffset; i < newPopulation.Size(); i++)
		{
			Mutate(newPopulation.GetIndividual(i));
		}

        for (int i = 0; i < pop.Size(); i++)
        {
            Destroy(pop.GetIndividual(i));
        }

		return newPopulation;
	}

	// Mutate an individual
	private static void Mutate(GameObject indiv)
	{
		// Loop through genes
		//for (int i = 0; i < indiv.Size(); i++)
		//{
			if (Random.Range(0, 1) <= mutationRate)
			{
				// Create random gene
				//byte gene = (byte)Mathf.Round(Random.Range(0,1));
                
                //TODO: Change range
				indiv.GetComponent<Individual>().SetScale(Random.Range(0.1f, 1.0f));
			}
		//}
	}
}
