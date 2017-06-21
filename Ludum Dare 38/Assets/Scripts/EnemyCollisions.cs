using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    public GameObject[] powerups;
    [SerializeField]
    private int fitnessValue; // value for reaching planet
    [SerializeField]
    private int fitnessDistanceMultiplier;

    private bool firstHit = true;

    private GameObject scoreSystem;

    private void Start()
    {
        scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Explode();
            SpawnPowerup();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            scoreSystem.GetComponent<ScoreSystem>().AddScore(scoreValue);
            GameObject.FindWithTag("EnemySpawner").GetComponent<GA>().GetPopulation().IncreaseDeadIndividuals();
            AddDistanceScore();
            //Destroy(gameObject, audio.clip.length);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("World"))
        {
            var particleSystem = gameObject.GetComponentInChildren<ParticleSystem>().emission;
            particleSystem.enabled = true;
            this.GetComponent<Individual>().AddFitness(fitnessValue);
            if (firstHit)
            {
                Population.IncrementReached();
                firstHit = false;
            }
        }
    }

    private void Explode()
    {
        Instantiate(
            explosion,
            transform.position,
            transform.rotation);
    }

    private void SpawnPowerup()
    {
       if(Random.Range(0, 20) < 1)
        {
            Instantiate(powerups[Random.Range(0,powerups.Length)],
                transform.position,
                transform.rotation);
        }
    }

    private void AddDistanceScore()
    {
        int score = fitnessDistanceMultiplier * (int) Mathf.Floor(10.0f - (Vector2.Distance(Vector2.zero, this.transform.position)));

        this.GetComponent<Individual>().AddFitness(score);
    }

    


}
