using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public string MapSize;
    public GameObject MapSizeSelectPanel;
    public void NewGame()
    {
        MapSizeSelectPanel.SetActive(true);
    }
    public void StartGame(int mapSize)
    {
        GridGenerator.gridHeight = mapSize;
        GridGenerator.gridWidth = mapSize;
        SceneManager.LoadScene("GameScene");
    }
}