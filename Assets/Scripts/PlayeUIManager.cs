﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeUIManager : MonoBehaviour
{
    public void ClosePanel(GameObject Panel)
    {
        Panel.SetActive(false);
    }
    public void OpenPanel(GameObject Panel)
    {
        Panel.SetActive(true);
    }
    public void UpgradeBuild(string BuildName)
    {
       
    }
}
