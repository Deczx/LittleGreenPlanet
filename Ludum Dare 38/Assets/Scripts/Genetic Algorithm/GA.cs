using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA : MonoBehaviour {

	int generationCount = 0;
    private Population myPop;

	// Use this for initialization
	void Start () {
		myPop = new Population(10, true, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewPopulation(){
		generationCount++;
		Debug.Log("Generation: " + generationCount);
		myPop = Algorithm.EvolvePopulation(myPop);
    }

    public Population GetPopulation()
    {
        return myPop;
    }
}
