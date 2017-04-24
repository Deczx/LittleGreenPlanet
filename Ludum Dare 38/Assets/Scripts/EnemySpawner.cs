using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    //TODO Make better spawn timer system
    public float difficultyScale;
    

    // The time between each wave in seconds
    public float spawnDelay;

    // Amount of enemies per wave.
    public float spawnAmount;

    private Vector2 topLeft;
    private Vector2 bottomLeft;
    private Vector2 topRight;
    private Vector2 bottomRight;

    private float timer;
    private float startAmount;

    private const int NORTH = 0;
    private const int EAST = 1;
    private const int SOUTH = 2;
    private const int WEST = 3;

    // Use this for initialization
    void Start()
    {
        float dist = (transform.position - Camera.main.transform.position).z;
        topLeft =      Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist));
        bottomLeft =   Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
        topRight =     Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist));
        bottomRight =  Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist));

        timer = 0.0f;

        startAmount = spawnAmount;

    }

    // Update is called once per frame
    void Update()
    {
        spawnAmount += difficultyScale * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            float waveAmount = Mathf.Round(spawnAmount - 0.5f);
            // Spawn a wave of enemies every time the timer expires.
            for (int i = 0; i < waveAmount; i++)
            {
                // Spawn an enemy
                Instantiate(
                enemyPrefab,
                GetRandomPosition(),
                transform.rotation);
            }
            // Reset timer
            timer = 0.0f;
        }
    }

    // Get a random position for the enemy to spawn at.
    Vector2 GetRandomPosition()
    {
        int direction = Random.Range(0, 4);
        // The max distance outside the edge of the screen enemies will spawn.
        float maxOffset = 5.0f;

        switch (direction)
        {
            case NORTH:
                return new Vector2( Random.Range(topLeft.x, topRight.x),
                                    Random.Range(topRight.y, topRight.y + maxOffset));
            case EAST:
                return new Vector2(Random.Range(topRight.x, topRight.x + maxOffset),
                                    Random.Range(bottomRight.y, topRight.y));
            case SOUTH:
                return new Vector2(Random.Range(bottomLeft.x, bottomRight.x),
                                    Random.Range(bottomRight.y, bottomRight.y - maxOffset));
            case WEST:
                return new Vector2(Random.Range(topLeft.x, topLeft.x - maxOffset),
                                    Random.Range(bottomLeft.y, topLeft.y));
            default:
                Debug.LogError("Something went wrong with RNG");
                return  new Vector2(100, 100);
        }

    }
}
