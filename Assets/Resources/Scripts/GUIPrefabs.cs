using System;
using System.Collections.Generic;
using UnityEngine;

public class GUIPrefabs
{
    public static void Coins()
    {
        int coins = Menu.data.coins;

        GUI.DrawTexture(new Rect(Screen.width - GUIData.margin - GUIData.coinSize, GUIData.margin, GUIData.coinSize, GUIData.coinSize), GUIData.coinGUI);

        if (coins % 10 == 0)
            DrawCoin(0, GUIData.num0);
        else if (coins % 10 == 1)
            DrawCoin(0, GUIData.num1);
        else if (coins % 10 == 2)
            DrawCoin(0, GUIData.num2);
        else if (coins % 10 == 3)
            DrawCoin(0, GUIData.num3);
        else if (coins % 10 == 4)
            DrawCoin(0, GUIData.num4);
        else if (coins % 10 == 5)
            DrawCoin(0, GUIData.num5);
        else if (coins % 10 == 6)
            DrawCoin(0, GUIData.num6);
        else if (coins % 10 == 7)
            DrawCoin(0, GUIData.num7);
        else if (coins % 10 == 8)
            DrawCoin(0, GUIData.num8);
        else if (coins % 10 == 9)
            DrawCoin(0, GUIData.num9);

        if ((coins - coins % 10) / 10 == 0)
            DrawCoin(1, GUIData.num0);
        else if ((coins - coins % 10) / 10 == 1)
            DrawCoin(1, GUIData.num1);
        else if ((coins - coins % 10) / 10 == 2)
            DrawCoin(1, GUIData.num2);
        else if ((coins - coins % 10) / 10 == 3)
            DrawCoin(1, GUIData.num3);
        else if ((coins - coins % 10) / 10 == 4)
            DrawCoin(1, GUIData.num4);
        else if ((coins - coins % 10) / 10 == 5)
            DrawCoin(1, GUIData.num5);
        else if ((coins - coins % 10) / 10 == 6)
            DrawCoin(1, GUIData.num6);
        else if ((coins - coins % 10) / 10 == 7)
            DrawCoin(1, GUIData.num7);
        else if ((coins - coins % 10) / 10 == 8)
            DrawCoin(1, GUIData.num8);
        else if ((coins - coins % 10) / 10 == 9)
            DrawCoin(1, GUIData.num9);
    }

    public static void ShopItemRecord(ShopItem shopItem)
    {
        if(GUI.Button(new Rect(Screen.width / 8, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1), GUIData.buttonTextureSize, GUIData.buttonTextureSize), Resources.Load<Texture2D>(shopItem.graphicsLocation)))
        {
            if(Menu.data.coins >= shopItem.price)
            {
                if (shopItem.type == "block")
                {
                    if (ShopActions.AddBlock(shopItem))
                        Menu.data.coins -= shopItem.price;
                }
                else if (shopItem.type == "health")
                {
                    if(ShopActions.AddHealth())
                        Menu.data.coins -= shopItem.price;
                }
                else if (shopItem.type == "speed")
                {
                    if(ShopActions.AddSpeed())
                        Menu.data.coins -= shopItem.price;
                }
            }
        }

        GUI.skin.label.fontSize = 30;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;

        GUI.Label(new Rect(Screen.width / 8 + GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) - GUIData.buttonMargin / 2, Screen.width / 2, GUIData.buttonTextureSize), shopItem.name);
        GUI.Label(new Rect(Screen.width / 8 + GUIData.buttonTextureSize + Screen.width / 3, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) - GUIData.buttonMargin / 2, Screen.width / 2, GUIData.buttonTextureSize), shopItem.price.ToString());

        GUI.skin.label.fontSize = 20;
        GUI.skin.label.alignment = TextAnchor.LowerLeft;

        GUI.Label(new Rect(Screen.width / 8 + GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) - GUIData.buttonMargin / 2, Screen.width / 2, GUIData.buttonTextureSize), shopItem.description);

        if(shopItem.id == 0)
        {
            if(Menu.data.protectionUnlock)
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.unlockTexture);
            else
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.lockTexture);
        }
        else if(shopItem.id == 1)
        {
            if (Menu.data.maxHealth == StaticVariables.maxHealth)
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.unlockTexture);
            else
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.lockTexture);
        }
        else if(shopItem.id == 2)
        {
            if (Menu.data.speed == StaticVariables.maxSpeed)
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.unlockTexture);
            else
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.lockTexture);
        }
        else if(shopItem.id == 3)
        {
            if (Menu.data.wraithBlockUnlock)
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.unlockTexture);
            else
                GUI.Label(new Rect(Screen.width / 8 - GUIData.buttonTextureSize, (GUIData.buttonMargin + GUIData.buttonHeight) * (shopItem.id + 1) + GUIData.buttonMargin / 2, GUIData.buttonTextureSize - GUIData.buttonMargin, GUIData.buttonTextureSize - GUIData.buttonMargin), GUIData.lockTexture);
        }
    }

    public static void DrawCoin(int index, Texture2D texture)
    {
        GUI.DrawTexture(new Rect(Screen.width - GUIData.margin * 2 - GUIData.coinSize - GUIData.numWidth * (index + 1), GUIData.margin * 1.75f, GUIData.numWidth, GUIData.numHeight), texture);
    }

    public static void DrawHealths()
    {
        for(int i = 0; i < Menu.data.maxHealth; i++)
        {
            if(Player.health > i)
                GUI.DrawTexture(new Rect(Screen.width - (GUIData.margin + GUIData.textureWidth) * (i + 1), GUIData.margin, GUIData.textureWidth, GUIData.textureHeight), GUIData.healthFullGUI);
            else
                GUI.DrawTexture(new Rect(Screen.width - (GUIData.margin + GUIData.textureWidth) * (i + 1), GUIData.margin, GUIData.textureWidth, GUIData.textureHeight), GUIData.healthEmptyGUI);
        }
    }
}
