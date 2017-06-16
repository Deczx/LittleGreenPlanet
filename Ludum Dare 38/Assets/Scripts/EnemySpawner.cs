using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, Individual{

    public float waveDelay; // Time between two waves
    public float difficultyScale; // How quickly does the difficulty scale up.

    public GameObject enemyPrefab;
    public GameObject spawnPoint;

    // Amount of enemies per wave.
    private float spawnAmount;
    public float startAmount; // Amount of enemies in the first wave
    private float waveTimer;
    

    public float spawnDelay;
    // Use this for initialization
    void Start()
    {
        spawnAmount = startAmount;

        waveTimer = 0.0f;

        Population myPop = new Population(50, true);

        int generationCount = 0;
        while (FitnessFunction.GetFitness(myPop.GetFittest() < FitnessFunction.GetMaxFitness())
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
        spawnAmount += difficultyScale * Time.deltaTime;

        waveTimer += Time.deltaTime;
        if (waveTimer > waveDelay)
        {
            float waveAmount = Mathf.Round(spawnAmount - 0.5f);
            // Spawn a wave of enemies every time the timer expires.
            for (int i = 0; i < spawnAmount; i++)
            {
                StartCoroutine(SpawnEnemy(i * spawnDelay, 1, i));
            }
            waveTimer = 0.0f;
        }
    }

    //TODO SLOOP ERUIT
    IEnumerator SpawnEnemy(float waitTime, float enemyScale, int enemyCount)
    {
        yield return new WaitForSeconds(waitTime);

        RotateSpawnPoint();
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint.transform.position, transform.rotation);
        enemy.GetComponent<EnemyTraits>().SetScale(enemyScale);
        this.GetComponent<Population>().SaveIndividual(enemyCount, enemy);
    }

    //TODO SLOOP ERUIT
    // Get a random position for the enemy to spawn at.
    void RotateSpawnPoint()
    {
        int rotationZ = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, 0, rotationZ);
        this.transform.rotation = rotation;
    }
}
