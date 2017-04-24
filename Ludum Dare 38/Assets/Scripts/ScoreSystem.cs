using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public int score;

    private Text scoreText;
  
	void Start () {
        this.score = 0;
        scoreText = (Text)this.GetComponentInChildren<Text>();
	}
	
    public void AddScore(int amount)
    {
        this.score += amount;
        scoreText.text = "SCORE " + score;
    }
}
