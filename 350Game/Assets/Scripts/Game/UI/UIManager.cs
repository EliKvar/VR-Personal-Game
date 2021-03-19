using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject loseScreen;
    public Text kills;

    void Awake()
    {
        Instance = this;
        kills = GameObject.Find("UI/Canvas/Kills").GetComponent<Text>();
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
    public void UpdateLives()
    {
        kills.text = GameManager.Instance.GetNumOfKills().ToString();

    }
    public void SetKLText(int k)
    {
        kills.text = k.ToString();

    }
  
}
