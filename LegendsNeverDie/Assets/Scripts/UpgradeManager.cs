using UnityEngine;
using System;

[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public double baseCost;
    public double costMultiplier = 1.15;
    public double valuePerLevel;
    public int level = 0;

    public double GetCost()
    {
        double rawCost = baseCost * Math.Pow(costMultiplier, level);
        return rawCost * GameManager.Instance.costReductionMultiplier;
    }

    public void LevelUp()
    {
        level++;
    }
}

public class UpgradeManager : MonoBehaviour
{
    public Upgrade clickUpgrade;
    public Upgrade passiveUpgrade;

    public void UpgradeClick()
    {
        double cost = clickUpgrade.GetCost();
        if (GameManager.Instance.SpendSouls(cost))
        {
            clickUpgrade.LevelUp();
            GameManager.Instance.soulsPerClick += clickUpgrade.valuePerLevel;
        }
    }

    public void UpgradePassive()
    {
        double cost = passiveUpgrade.GetCost();
        if (GameManager.Instance.SpendSouls(cost))
        {
            passiveUpgrade.LevelUp();
            GameManager.Instance.soulsPerSecond += passiveUpgrade.valuePerLevel;
        }
    }
}
