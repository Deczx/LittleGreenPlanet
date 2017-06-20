using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FitnessFunction {

    private static int goalFitness = 110;

	//// Calculate inidividuals fittness by comparing it to our candidate solution
	//public static int GetFitness(GameObject individual)
	//{
	//	int fitness = 0;
	//	// Loop through our individuals genes and compare them to our cadidates
	//	for (int i = 0; i < individual.Size() && i < solution.Length; i++)
	//	{
	//		if (individual.GetGene(i) == solution[i])
	//		{
	//			fitness++;
	//		}
	//	}
	//	return fitness;
	//}

	// Get optimum fitness
	public static int GetGoalFitness()
	{
		//int maxFitness = solution.Length;
		return goalFitness;
	}   
}
