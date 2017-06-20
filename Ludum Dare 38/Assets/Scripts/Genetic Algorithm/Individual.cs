using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour {
    
    private float currentScale = 1.0f;
	private int fitness = 0;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetScale(float scale)
	{
        currentScale = scale;
		this.transform.localScale = new Vector3(scale, scale, scale);
	}

    public float GetScale() {
        return currentScale;
    }

	public int GetFitness()
	{
		return fitness;
	}

    public void AddFitness(int value)
    {
        fitness += value;
    }

    public void RemoveFitness(int value)
    {
        fitness -= value;
    }
}
