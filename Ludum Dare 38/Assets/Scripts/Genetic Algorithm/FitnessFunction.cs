using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessFunction : MonoBehaviour {

	static byte[] solution = new byte[64];
    private static int goalFitness = 300;

	/* Public methods */
	// Set a candidate solution as a byte array
	public static void SetSolution(byte[] newSolution)
	{
		solution = newSolution;
	}

	// To make it easier we can use this method to set our candidate solution 
	// with string of 0s and 1s
	public static void SetSolution(string newSolution)
	{
		solution = new byte[newSolution.Length];
		// Loop through each character of our string and save it in our byte 
		// array
		for (int i = 0; i < newSolution.Length; i++)
		{
			string character = newSolution.Substring(i, i + 1);
			if (character.Contains("0") || character.Contains("1"))
			{
                solution[i] = byte.Parse(character);
			}
			else
			{
				solution[i] = 0;
			}
		}
	}

	// Calculate inidividuals fittness by comparing it to our candidate solution
	public static int GetFitness(GameObject individual)
	{
		int fitness = 0;
		// Loop through our individuals genes and compare them to our cadidates
		//for (int i = 0; i < individual.Size() && i < solution.Length; i++)
		//{
			//if (individual.GetGene(i) == solution[i])
			//{
				fitness++;
			//}
		//}
		return fitness;
	}

	// Get optimum fitness
	public static int GetGoalFitness()
	{
		//int maxFitness = solution.Length;
		return goalFitness;
	}   
}
