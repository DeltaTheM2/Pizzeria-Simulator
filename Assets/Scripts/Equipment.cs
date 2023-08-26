using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment 
{

    public float upgradeMultiplier = 1.2f;

    public int upgradeLevel { get; private set; } = 0;

    public Equipment()
    {
        upgradeMultiplier = 1.2f;
    }
    
    public float GetCookingTimeMultiplier()
    {
    return upgradeMultiplier;
    }

    public void UpgradeOven()
    {
     upgradeMultiplier *= 0.3f;
    }
}




