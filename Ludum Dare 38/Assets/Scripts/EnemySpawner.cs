using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


    //TODO Make better spawn timer system

    // The time between each wave in seconds

	// Use this for initialization
	void Start()
    {
        Population myPop = new Population(50, true);

		int generationCount = 0;
		while (FitnessFunction.GetFitness(this.GetComponent<Population>().GetFittest()) < FitnessFunction.GetMaxFitness())
		{
			generationCount++;
            Debug.Log("Generation: " + generationCount + " Fittest: " + FitnessFunction.GetFitness(this.GetComponent<Population>().GetFittest()));
			myPop = Algorithm.EvolvePopulation(myPop);
		}
		Debug.Log("Solution found!");
		Debug.Log("Generation: " + generationCount);
		Debug.Log("Genes:");
		Debug.Log(myPop.GetFittest());
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
