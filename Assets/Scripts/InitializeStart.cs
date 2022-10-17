using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitializeStart : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI chosenName;
    public TextMeshProUGUI theName;
    private bool isNameSet;
    void Start()
    {
        isNameSet = false;
        GameManager.Instance.isNameSet = false;
        GameManager.Instance.LoadName();
        highScore.text = "High Score: " + GameManager.Instance.highScore + " by " + GameManager.Instance.highScoreName;

    }

    public void registerName()
    {
        isNameSet = true;
        GameManager.Instance.isNameSet = isNameSet;
        GameManager.Instance.playerName = theName.text;
        chosenName.text = "Chosen Name: " + theName.text;
    }
}
