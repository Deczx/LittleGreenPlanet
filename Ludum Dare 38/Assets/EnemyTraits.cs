using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {

    private float minimumScale = 0.1f;
	private float maximumScale = 1.0f;
	private int fitness = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScale(float scale)
	{
        if (scale > minimumScale || scale < maximumScale)
            this.transform.localScale = new Vector3(scale, scale, scale);
        else if (scale < minimumScale)
            this.transform.localScale = new Vector3(minimumScale, minimumScale, minimumScale);
        else if (scale > maximumScale)
            this.transform.localScale = new Vector3(maximumScale, maximumScale, maximumScale);
	}

    public int GetFitness()
    {
        if (fitness == 0)
        {
            fitness = FitnessFunction.GetFitness(this.gameObject);
        }
        return fitness;
    }
}
