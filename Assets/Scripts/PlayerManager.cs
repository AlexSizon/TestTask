using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    public Text GoldCounter;
    public Text PeoplesCounter;
    public Text TownHallLevel;
    public Text ToWnHallIncomeGold;
    public Text TempleLevel;
    public Text TempleDamageBoost;
    public Text TempleHpBoost;
    public Text ResidentialBuildingsLevel;
    public Text ResidentialBuildingsCurrentMax;
    public Text ResidentialBuildingsIncrease;
    public Text WallLevel;
    public Text WallHpBoost;
    public Text TownHallUpgradePrice;
    public Text TempleUpgradePrice;
    public Text ResidentialBuildingsUpgradePrice;
    public Text WallUpgradePrice;
    private void Start()
    {
        Invoke("InitialezeUIFields", 1);
    }
    public void InitialezeUIFields()
    {
        GoldCounter.text = PlayerInfo.Gold.ToString();
        PeoplesCounter.text = PlayerInfo.Peoples.ToString();
        TownHallLevel.text = PlayerInfo.TownHallLevel.ToString();
        ToWnHallIncomeGold.text = (PlayerInfo.Peoples * PlayerInfo.TownHallIncreaseGoldPerMove).ToString();
        TempleLevel.text = PlayerInfo.TempleLevel.ToString();
        TempleDamageBoost.text = PlayerInfo.TempleDamageBoostInAttack.ToString();
        TempleHpBoost.text = PlayerInfo.TempleHpBoostInDefence.ToString();
        ResidentialBuildingsLevel.text = PlayerInfo.ResidentialBuildingsLevel.ToString();
        ResidentialBuildingsCurrentMax.text = PlayerInfo.MaxPeoplesOnCurrentLevel.ToString();
        ResidentialBuildingsIncrease.text = PlayerInfo.PeoplesPerMove.ToString();
        WallLevel.text = PlayerInfo.WallLevel.ToString();
        WallHpBoost.text = PlayerInfo.WallHpBoostInDefence.ToString();
        TownHallUpgradePrice.text = PlayerInfo.TownHallUpgradePrice.ToString();
        TempleUpgradePrice.text = PlayerInfo.TempleUpgradePrice.ToString();
        ResidentialBuildingsUpgradePrice.text = PlayerInfo.ResidentialBuildingsUpgradePrice.ToString();
        WallUpgradePrice.text = PlayerInfo.WallUpgradePrice.ToString();
    }
    public void UpdatePlayerDataPerMove()
    {
        if (PlayerInfo.Peoples + PlayerInfo.PeoplesPerMove >= PlayerInfo.MaxPeoplesOnCurrentLevel)
        {
            PlayerInfo.Peoples = PlayerInfo.MaxPeoplesOnCurrentLevel;
            PeoplesCounter.text = PlayerInfo.Peoples.ToString();
        }
        else
        {
            PlayerInfo.Peoples += PlayerInfo.PeoplesPerMove;
            PeoplesCounter.text = PlayerInfo.Peoples.ToString();
        }
        PlayerInfo.Gold += (int)(PlayerInfo.Peoples * PlayerInfo.TownHallIncreaseGoldPerMove);
        GoldCounter.text = PlayerInfo.Gold.ToString();
    }
    public void UpgradeBuildLevel(string BuildName)
    {
        switch (BuildName)
        {
            case "TownHall":
                {
                    if (PlayerInfo.TownHallLevel < PlayerInfo.TownHallMaxLevel && PlayerInfo.Gold >= (PlayerInfo.TownHallUpgradePrice * PlayerInfo.TownHallLevel))
                    {
                        PlayerInfo.Gold -= PlayerInfo.TownHallUpgradePrice * PlayerInfo.TownHallLevel;
                        PlayerInfo.TownHallLevel++;
                        PlayerInfo.TownHallIncreaseGoldPerMove += 0.02f;
                        TownHallLevel.text = PlayerInfo.TownHallLevel.ToString();
                        ToWnHallIncomeGold.text = (PlayerInfo.Peoples * PlayerInfo.TownHallIncreaseGoldPerMove).ToString();
                        GoldCounter.text = PlayerInfo.Gold.ToString();
                        TownHallUpgradePrice.text = (PlayerInfo.TownHallUpgradePrice * PlayerInfo.TownHallLevel).ToString();
                    }
                    break;
                }
            case "Temple":
                {
                    if (PlayerInfo.TempleLevel < PlayerInfo.TempleMaxLevel && PlayerInfo.Gold >= (PlayerInfo.TempleUpgradePrice * PlayerInfo.TempleLevel))
                    {
                        PlayerInfo.TempleLevel++;

                    }
                    break; ;
                }
            case "Wall":
                {
                    break; ;
                }
            case "ResidentialBuildings":
                {
                    if (PlayerInfo.ResidentialBuildingsLevel < PlayerInfo.ResidentialBuildingsMaxLevel && PlayerInfo.Gold >= (PlayerInfo.ResidentialBuildingsLevel * PlayerInfo.ResidentialBuildingsUpgradePrice))
                    {
                        PlayerInfo.Gold -= PlayerInfo.ResidentialBuildingsUpgradePrice;
                        PlayerInfo.ResidentialBuildingsLevel++;
                        PlayerInfo.PeoplesPerMove += 10;
                        PlayerInfo.MaxPeoplesOnCurrentLevel += 200;
                        ResidentialBuildingsLevel.text = PlayerInfo.ResidentialBuildingsLevel.ToString();
                        GoldCounter.text = PlayerInfo.Gold.ToString();
                        ResidentialBuildingsCurrentMax.text = PlayerInfo.MaxPeoplesOnCurrentLevel.ToString();
                        ResidentialBuildingsIncrease.text = PlayerInfo.PeoplesPerMove.ToString();
                        ResidentialBuildingsUpgradePrice.text = (PlayerInfo.ResidentialBuildingsUpgradePrice * PlayerInfo.ResidentialBuildingsLevel).ToString();
                    }
                    break; ;
                }
        }
    }
}
