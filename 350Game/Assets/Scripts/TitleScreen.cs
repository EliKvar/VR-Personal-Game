using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject startButton;
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject canvasD;
    public GameObject platform;
    public GameObject canvasE;

public void EasyButton()
    {
        Time.timeScale = 1;
        DestroyStart();
        WaveSpawner.Instance.SetDifficulty("Easy");
        GameManager.Instance.StartGame();
        
    }
    public void MediumButton()
    {
        Time.timeScale = 1;
        DestroyStart();
        WaveSpawner.Instance.SetDifficulty("Medium");
        GameManager.Instance.StartGame();

    }
    public void HardButton()
    {
        Time.timeScale = 1;
        DestroyStart();
        GameManager.Instance.StartGame();
        WaveSpawner.Instance.SetDifficulty("Hard");

    }
    public void DestroyStart()
    {
        easyButton.SetActive(false);
        hardButton.SetActive(false);
        mediumButton.SetActive(false);
        canvasD.SetActive(false);
        platform.SetActive(false);
        canvasE.SetActive(false);
    }
}
