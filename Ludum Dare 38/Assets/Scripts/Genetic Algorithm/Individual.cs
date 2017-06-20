using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour {
    
	private float minimumScale = 0.2f;
	private float maximumScale = 1.0f;
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
		if (scale > minimumScale && scale < maximumScale)
			this.transform.localScale = new Vector3(scale, scale, scale);
		else if (scale < minimumScale)
			this.transform.localScale = new Vector3(minimumScale, minimumScale, minimumScale);
		else if (scale > maximumScale)
			this.transform.localScale = new Vector3(maximumScale, maximumScale, maximumScale);
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
