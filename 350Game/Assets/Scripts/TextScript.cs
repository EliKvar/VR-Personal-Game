using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //This is important as it allows you to edit UI elements

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject den;
    public GameObject enemy; //This is the position of the ball, once the code is written and attached, drag the ball gameobject onto this in the Inspector
    public GameObject loseGameWindow;

    
    public void ShowLoseScreen()
    {
        loseGameWindow.SetActive(true);
    }
}
