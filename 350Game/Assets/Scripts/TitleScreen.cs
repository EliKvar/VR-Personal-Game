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


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetAsleep", 1f);
    }
     void SetAsleep()
     {
        Time.timeScale = 0;
       // HardButton();

     }


// Update is called once per frame
public void EasyButton()
    {
        WaveSpawner.Instance.SetDifficulty("Easy");
        Time.timeScale = 1;

        easyButton.SetActive(false);
        hardButton.SetActive(false);
        mediumButton.SetActive(false);
        canvasD.SetActive(false);
    }
    public void MediumButton()
    {
        WaveSpawner.Instance.SetDifficulty("Medium");
        Time.timeScale = 1;


        easyButton.SetActive(false);
        hardButton.SetActive(false);
        mediumButton.SetActive(false);
        canvasD.SetActive(false);
    }
    public void HardButton()
    {
        Time.timeScale = 1;

        WaveSpawner.Instance.SetDifficulty("Hard");

        easyButton.SetActive(false);
        hardButton.SetActive(false);
        mediumButton.SetActive(false);
        canvasD.SetActive(false);
    }
}
