using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private float gameTime = 0f;
    private int spawnInterval;
    private int maxRegular;
    private int numRegular;
    private int maxTank;
    private int numTanks;
    private string difficulty;
    private bool waveSpawn = true;
    private int waveNumber = 0;
    public GameObject regEnemy;
    public GameObject tankEnemy;
    private int regProgression;
    private int tankProgression;
    public List<GameObject> enemies = new List<GameObject>();
    public static WaveSpawner Instance;
    public GameObject parentRef;

    public GameObject[] spawnPoint;

    public void SetDifficulty(string diff)
    {
        difficulty = diff;
        switch (difficulty)
        {
            case "Easy":
                spawnInterval = 5;
                maxRegular = 4;
                maxTank = 1;
                tankProgression = 1;
                regProgression = 2;
                Debug.Log("Easy");
                break;

            case "Medium":
                spawnInterval = 3;
                maxRegular = 7;
                maxTank = 3;
                tankProgression = 1;
                regProgression = 4;
                Debug.Log("Medium");

                break;

            case "Hard":
                spawnInterval = 1;
                maxRegular = 10;
                maxTank = 4;
                tankProgression = 3;
                regProgression = 6;
                Debug.Log("Hard");

                break;
        }
    }
    void Start()
    {
        Instance = this;
        numRegular = 0;
        numTanks = 0;
        gameTime = 0;
    }
    
    void Update()
    {
        
            if (Time.time > gameTime && numRegular != maxRegular)
            {
                numRegular++;
                gameTime += spawnInterval;

            Instantiate(regEnemy, spawnPoint[(int)Random.Range(0.0f, spawnPoint.Length)].transform.position, Quaternion.identity, parentRef.transform);

            if (numTanks != maxTank)
                {
                    Instantiate(tankEnemy, spawnPoint[(int)Random.Range(0.0f, spawnPoint.Length)].transform.position, Quaternion.identity, parentRef.transform);
                
                    numTanks++;
                }
        }
        if (numRegular == maxRegular && numTanks == maxTank && GameObject.FindGameObjectsWithTag("RegEnemy").Length == 0 && GameObject.FindGameObjectsWithTag("TankEnemy").Length == 0) /*&& gameTime > (gameTime += 20)*/
        {
            Debug.Log("Ticked");

            numRegular = 0;
            numTanks = 0;
            maxTank += tankProgression;
            maxRegular += regProgression;
            gameTime = Time.time + 6;
        }
        

        

    }
}
