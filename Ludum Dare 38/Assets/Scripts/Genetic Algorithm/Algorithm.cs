using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm : MonoBehaviour {

	/* GA parameters */
	private static double mutationRate = 0.015;
    private static float scale;

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
		GameObject newIndiv = null;

        scale = pop.GetEnemyScale();
        float random = Random.Range(0.03f, 0.09f);
        Debug.Log(scale);

        // Mutate population
        for (int i = 0; i < newPopulation.Size(); i++)
        {
            if (pop.GetAverageFitness() > FitnessFunction.GetGoalFitness())
            {
                newIndiv = EasyMutate(newPopulation.GetIndividual(i), random, pop);
            }
            else if (pop.GetAverageFitness() < FitnessFunction.GetGoalFitness())
			{
                newIndiv = HardMutate(newPopulation.GetIndividual(i), random, pop);
			}
			newPopulation.SaveIndividual(i, newIndiv);
        }

		for (int i = 0; i < pop.Size(); i++)
        {
            Destroy(pop.GetIndividual(i));
        }

		return newPopulation;
	}

	// Mutate an individual to make it easier
	private static GameObject EasyMutate(GameObject indiv, float random, Population pop)
	{
		float modifier = scale + random;
		Debug.Log("Scale Easy: " + modifier);
		//Debug.Log("Easy: " + modifier);
		indiv.GetComponent<Individual>().SetScale(modifier);
		pop.SetEnemyScale(modifier);
		return indiv;
	}

	// Mutate an individual to make it harder
	private static GameObject HardMutate(GameObject indiv, float random, Population pop)
	{
		float modifier = scale - random;
		Debug.Log("Scale Hard: " + modifier);
		//Debug.Log("Hard: " + modifier);
		indiv.GetComponent<Individual>().SetScale(modifier);
		pop.SetEnemyScale(modifier);
		return indiv;
	}
}
