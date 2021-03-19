using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private float gameTime = 0f;
    private int spawnInterval;
    private int maxEnemies;
    private int numEnemies;
    private string difficulty;
    private bool waveSpawn = true;
    private int waveNumber = 0;
    public GameObject regEnemy;
    public GameObject tankEnemy;
    private int enemyProgression;
    public List<GameObject> enemies = new List<GameObject>();
    public static WaveSpawner Instance;

    public GameObject spawnPoint;

    public void SetDifficulty(string diff)
    {
        difficulty = diff;
        switch (difficulty)
        {
            case "Easy":
                spawnInterval = 5;
                maxEnemies = 3;
                enemyProgression = 1;
                Debug.Log("Easy");
                break;

            case "Medium":
                spawnInterval = 3;
                maxEnemies = 7;
                enemyProgression = 2;
                Debug.Log("Medium");

                break;

            case "Hard":
                spawnInterval = 1;
                maxEnemies = 10;
                enemyProgression = 5;
                Debug.Log("Hard");

                break;
        }
    }
    void Start()
    {
        Instance = this;
        numEnemies = 0;
        gameTime = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        
            if (Time.time > gameTime && numEnemies != maxEnemies)
            {
                numEnemies++;
                gameTime += spawnInterval;
                // Instantiate(ShieldEnemy, randomSpawn);
                Instantiate(regEnemy, spawnPoint.transform.position, Quaternion.identity);
         

            }
        if (numEnemies == maxEnemies && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) /*&& gameTime > (gameTime += 20)*/
        {
            Debug.Log("Ticked");

            numEnemies = 0;
            maxEnemies += enemyProgression;
            gameTime = Time.time + 6;
        }
        

        

    }
}
