using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DebugMode
{
    public static void StartDebugMode()
    {

#if UNITY_EDITOR

        Debug.Log("Test mode is enable");

        Menu.data.maxHealth = StaticVariables.maxHealth;
        Menu.data.speed = StaticVariables.maxSpeed;
        Menu.data.protectionUnlock = true;
        Menu.data.coins = 99;

#endif

    }

    public static void ResetData()
    {
        Menu.data = new PlayerData();

        LoadSave.Save();

        Debug.Log("Data is clear.");
    }
}
