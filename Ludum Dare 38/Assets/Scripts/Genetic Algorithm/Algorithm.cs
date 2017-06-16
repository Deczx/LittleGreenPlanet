using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm {
    
	/* GA parameters */
	private static double uniformRate = 0.5;
	private static double mutationRate = 0.015;
	private static int tournamentSize = 5;
	private static bool elitism = true;

	// Amount of enemies per wave.
	private float spawnAmount;
	private float startAmount;
	public float waveTimer, waveDelay;
	public float difficultyScale;

	private Quaternion rotation;

    void Start()
    {
		startAmount = spawnAmount;

		waveTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
	{
		spawnAmount += difficultyScale * Time.deltaTime;

		waveTimer += Time.deltaTime;
		if (waveTimer > waveDelay)
		{
			float waveAmount = Mathf.Round(spawnAmount - 0.5f);
			// Spawn a wave of enemies every time the timer expires.
			waveTimer = 0.0f;
		}
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
			GameObject indiv1 = TournamentSelection(pop);
			GameObject indiv2 = TournamentSelection(pop);
			GameObject newIndiv = Crossover(indiv1, indiv2);
			newPopulation.SaveIndividual(i, newIndiv);
		}

		// Mutate population
		for (int i = elitismOffset; i < newPopulation.Size(); i++)
		{
			Mutate(newPopulation.GetIndividual(i));
		}

		return newPopulation;
	}

	// Crossover individuals
	private static GameObject Crossover(GameObject indiv1, GameObject indiv2)
	{
		GameObject newSol = new GameObject();
		// Loop through genes
		//for (int i = 0; i < indiv1.Size(); i++)
		//{
		//	// Crossover
		//	if (Random.Range(0,1) <= uniformRate)
		//	{
		//		newSol.SetGene(i, indiv1.GetGene(i));
		//	}
		//	else
		//	{
		//		newSol.SetGene(i, indiv2.GetGene(i));
		//	}
		//}
		return newSol;
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
				indiv.GetComponent<EnemyTraits>().SetScale(Random.Range(0.1f, 1.0f));
			}
		//}
	}

	// Select individuals for crossover
	private static GameObject TournamentSelection(Population pop)
	{
		// Create a tournament population
		Population tournament = new Population(tournamentSize, false);
		// For each place in the tournament get a random individual
		for (int i = 0; i < tournamentSize; i++)
		{
			int randomId = (int)(Random.Range(0, 1) * pop.Size());
			tournament.SaveIndividual(i, pop.GetIndividual(randomId));
		}
		// Get the fittest
		GameObject fittest = tournament.GetFittest();
		return fittest;
	}
}
