using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm : MonoBehaviour {

	/* GA parameters */
	private static double mutationRate = 0.015;
    private static float scale = 0.5f;
    private static float speed = 1.0f;
    private static bool sizeMutate, speedMutate;
    private static int goalFitness, averageFitness;
    private static int goalReached, enemiesReached;
    private static float sizeModifier, speedModifier;

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
        Population newPopulation = new Population(pop.Size(), true, scale);
		GameObject newIndiv = null;
        averageFitness = pop.GetAverageFitness();
        goalFitness = FitnessFunction.GetGoalFitness();
        enemiesReached = pop.GetReached();
        goalReached = FitnessFunction.GetGoalReached();

		Debug.Log("Enemies Reached: " + enemiesReached);

        // Mutate population
        for (int i = 0; i < newPopulation.Size(); i++)
        {
            if (averageFitness > goalFitness)
			{
                sizeModifier = (averageFitness - goalFitness) * 0.002f;
				newIndiv = MutateSize(newPopulation.GetIndividual(i), sizeModifier, pop, true);
            }
            else if (averageFitness < goalFitness)
			{
                sizeModifier = (goalFitness - averageFitness) * 0.002f;
                newIndiv = MutateSize(newPopulation.GetIndividual(i), sizeModifier, pop, false);
			}

            if (enemiesReached > goalReached)
            {
                speedModifier = (enemiesReached - goalReached) * 0.01f;
                MutateSpeed(newIndiv, speedModifier, pop, true);
            }
            else if (enemiesReached < goalReached)
            {
                speedModifier = (goalReached - enemiesReached) * 0.01f;
                MutateSpeed(newIndiv, speedModifier, pop, false);
            }
            newPopulation.SaveIndividual(i, newIndiv);
        }

        if (sizeMutate)
            scale += sizeModifier;
        else if (!sizeMutate)
            scale -= sizeModifier;

		if (speedMutate)
			speed -= speedModifier;
		else if (!speedMutate)
			speed += speedModifier;

		for (int i = 0; i < pop.Size(); i++)
        {
            Destroy(pop.GetIndividual(i));
        }
        pop.ResetReached();
		return newPopulation;
	}

    // Mutate an individual to make it easier
    private static GameObject MutateSize(GameObject indiv, float mutation, Population pop, bool easy)
    {
        float modifier = 0.0f;

		if (easy)
        {
            sizeMutate = easy;
            modifier = scale + mutation;
        }
        else if (!easy)
		{
			sizeMutate = easy;
			modifier = scale - mutation;
        }
		indiv.GetComponent<Individual>().SetScale(modifier);
		return indiv;
	}

	// Mutate an individual to make it harder
	private static void MutateSpeed(GameObject indiv, float mutation, Population pop, bool slower)
	{
        float modifier = 0.0f;

        if (slower)
        {
            speedMutate = slower;
			modifier = speed - mutation;
        }
        else if (!slower)
        {
            speedMutate = slower;
			modifier = speed + mutation;
        }

        indiv.GetComponent<EnemyMovement>().SetSpeed(modifier);
	}
}
