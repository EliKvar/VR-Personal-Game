using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject loseScreen;
    public Text lives;
    public Text kills;

    void Awake()
    {
        Instance = this;
        lives = GameObject.Find("UI/Canvas/Lives").GetComponent<Text>();
        kills = GameObject.Find("UI/Canvas/Kills").GetComponent<Text>();
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
    public void UpdateLives()
    {
        lives.text = GameManager.Instance.GetNumOfLives().ToString();
        kills.text = GameManager.Instance.GetNumOfKills().ToString();

    }
    public void SetKLText(int l, int k)
    {
        lives.text = l.ToString();
        kills.text = k.ToString();

    }
  
}
