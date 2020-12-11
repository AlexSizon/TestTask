using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Peoples = 100;
    public int Gold = 500;

    public int TownHallLevel=1;
    public int ResidentialBuildingsLevel = 1;
    public int TempleLevel = 1;
    public int WallLevel = 1;
    public int BarracksLevel = 1;

    public float TownHallIncreaseGoldPerMove = 0.1f;
    public int PeoplesPerMove = 10;
    public int WallHpBoostInDefence = 1;
    public int TempleDamageBoostInAttack = 1;
    public int TempleHpBoostInDefence = 1;

    public int MaxPeoplesOnCurrentLevel = 200;
    public int MaxPeoples = 5000;

    public int TownHallMaxLevel = 10;
    public int ResidentialBuildingsMaxLevel = 25;
    public int TempleMaxLevel = 9;
    public int WallMaxLevel = 10;
    public int BarracksMaxLevel = 10;

    public int TownHallUpgradePrice = 200;
    public int TempleUpgradePrice = 750;
    public int ResidentialBuildingsUpgradePrice = 150;
    public int WallUpgradePrice = 500;
}
