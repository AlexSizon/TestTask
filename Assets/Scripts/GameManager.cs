using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Text TurnCounter;
    int turnCounter = 1;
    public void NextMove()
    {
        PlayerManager.UpdatePlayerDataPerMove();
        TurnCounter.text = (turnCounter++).ToString();
    }
    public void UpgradeBuild(string BuildName)
    {
        PlayerManager.UpgradeBuildLevel(BuildName);
    }
}
