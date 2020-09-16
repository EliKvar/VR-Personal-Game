using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int maxAllowedEscapedEnemies = 10;
    public int escapedEnemies;
    public bool gameOver;
    private int kills;
    private int lives;
  // private string test = UIManager.Instance.lives.text;
    //private string test2 = UIManager.Instance.kills.text;
    

    void Awake()
    {
        Instance = this;
       // Invoke("SetAsleep", 3f);     //Comment this out, comment setasleep func out
                                     //Test in vr, turn in
    }
    void SetAsleep()
     {
         //Time.timeScale = 0;
    StartAndLoad();

     }
    void Update()
    {
        
    }

    public int GetNumOfLives()
    {
        lives = maxAllowedEscapedEnemies - escapedEnemies;
        return lives;
    }
    public int GetNumOfKills()
    {
        return kills;
    }
    public void OnEnemyEscape()
    {
        escapedEnemies++;
        Debug.Log("Escaped" + escapedEnemies);

        if (escapedEnemies == maxAllowedEscapedEnemies)
        {
            OnGameLose();
        }
    }

    public void AddKill()
    {
        kills++;

    }

    private void OnGameLose()
    {
        gameOver = true;

            Time.timeScale = 0;
        

        UIManager.Instance.ShowLoseScreen();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void Quit()
    {

    }
    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.lives = GetNumOfLives();
        save.kills = GetNumOfKills();

       

        return save;
    }
    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

     

        Debug.Log("Game Saved");
        Debug.Log(file);
        Debug.Log(save);
    }
    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            SetGameData( save.kills, save.lives);

            Debug.Log("Game Loaded");

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
    public void SetGameData(int k, int l)
    {
        Debug.Log("Kills: " + k + " Lives: " +l );
        kills = k;
        lives = l;
        //UIManager.Instance.SetKLText(l, k);
       // UIManager.Instance.lives.text = lives.ToString(); //SHOULD WORK, BUT DOESNT
        //UIManager.Instance.kills.text = kills.ToString();
    }
    public void StartAndLoad()
    {
        SceneManager.LoadScene("Main");         //Play game, lose lives. Restart game, select load from save button, Main opens, select difficulty, 3 seconds later lives is updated to save.lives
       // Invoke("LoadGame", 3f);
        LoadGame();
    }

  
}
