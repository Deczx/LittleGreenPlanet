using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm : MonoBehaviour {

	/* GA parameters */
	private static double mutationRate = 0.015;

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

        float scale = pop.GetEnemyScale();
        float random = Random.Range(0.03f, 0.09f);

        // Mutate population
        for (int i = 0; i < newPopulation.Size(); i++)
        {
            if (pop.GetAverageFitness() > FitnessFunction.GetGoalFitness())
            {
                newIndiv = EasyMutate(newPopulation.GetIndividual(i), scale, random, pop);
            }
            else if (pop.GetAverageFitness() < FitnessFunction.GetGoalFitness())
			{
                newIndiv = HardMutate(newPopulation.GetIndividual(i), scale, random, pop);
            }
            else
            {

            }
			newPopulation.SaveIndividual(i, newIndiv);
        }

        for (int i = 0; i < pop.Size(); i++)
        {
            Destroy(pop.GetIndividual(i));
        }

		return newPopulation;
	}

	// Mutate an individual to make it harder
	private static GameObject EasyMutate(GameObject indiv, float scale, float random, Population pop)
	{
		float scaleModifier = scale + random;
        Debug.Log("Easy: " + scaleModifier);
		indiv.GetComponent<Individual>().SetScale(scaleModifier);
		pop.SetEnemyScale(scaleModifier);
		return indiv;
	}

	// Mutate an individual to make it harder
	private static GameObject HardMutate(GameObject indiv, float scale, float random, Population pop)
	{
		float scaleModifier = scale - random;
		Debug.Log("Hard: " + scaleModifier);
        indiv.GetComponent<Individual>().SetScale(scaleModifier);
        pop.SetEnemyScale(scaleModifier);
		return indiv;
	}
}
