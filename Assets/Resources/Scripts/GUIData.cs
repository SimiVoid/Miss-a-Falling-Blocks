using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIData
{
    public static bool isEnable = false;

    public static float buttonHeight = 90;
    public static float buttonWidth = 400;
    public static float buttonMargin = 40;
    public static float buttonTextureSize = 120;

    public static float margin = 5;
    public static float scale;
    public static float textureWidth;
    public static float textureHeight;
    public static float coinSize;
    public static float numWidth;
    public static float numHeight;

    public static Rect[] point;

    public static GUISkin skin;

    public static Texture2D settingsTexture;
    public static Texture2D shopTexture;
    public static Texture2D leaderboardsTexture;
    public static Texture2D achivementsTexture;
    public static Texture2D menuTexture;
    public static Texture2D pauseTexture;
    public static Texture2D crossTexture;
    public static Texture2D checkTexture;
    public static Texture2D unlockTexture;
    public static Texture2D lockTexture;

    public static Texture2D coinGUI;
    public static Texture2D healthEmptyGUI;
    public static Texture2D healthFullGUI;
    public static Texture2D protectionTexture;

    public static Texture2D num0;
    public static Texture2D num1;
    public static Texture2D num2;
    public static Texture2D num3;
    public static Texture2D num4;
    public static Texture2D num5;
    public static Texture2D num6;
    public static Texture2D num7;
    public static Texture2D num8;
    public static Texture2D num9;

    public GUIData()
    {
        skin = Resources.Load<GUISkin>("GUI");

        settingsTexture = Resources.Load<Texture2D>("Graphics/GUI/gear");
        shopTexture = Resources.Load<Texture2D>("Graphics/GUI/shoppingCart");
        leaderboardsTexture = Resources.Load<Texture2D>("Graphics/GUI/leaderboardsComplex");
        achivementsTexture = Resources.Load<Texture2D>("Graphics/GUI/trophy");
        menuTexture = Resources.Load<Texture2D>("Graphics/GUI/menuList");
        pauseTexture = Resources.Load<Texture2D>("Graphics/GUI/pause");
        crossTexture = Resources.Load<Texture2D>("Graphics/GUI/cross");
        checkTexture = Resources.Load<Texture2D>("Graphics/GUI/checkmark");
        unlockTexture = Resources.Load<Texture2D>("Graphics/GUI/unlocked");
        lockTexture = Resources.Load<Texture2D>("Graphics/GUI/locked");

        coinGUI = Resources.Load<Texture2D>("Graphics/hud_coins");
        healthEmptyGUI = Resources.Load<Texture2D>("Graphics/hud_heartEmpty");
        healthFullGUI = Resources.Load<Texture2D>("Graphics/hud_heartFull");
        protectionTexture = Resources.Load<Texture2D>("Graphics/shieldSilver_HUD");

        num0 = Resources.Load<Texture2D>("Graphics/hud_0");
        num1 = Resources.Load<Texture2D>("Graphics/hud_1");
        num2 = Resources.Load<Texture2D>("Graphics/hud_2");
        num3 = Resources.Load<Texture2D>("Graphics/hud_3");
        num4 = Resources.Load<Texture2D>("Graphics/hud_4");
        num5 = Resources.Load<Texture2D>("Graphics/hud_5");
        num6 = Resources.Load<Texture2D>("Graphics/hud_6");
        num7 = Resources.Load<Texture2D>("Graphics/hud_7");
        num8 = Resources.Load<Texture2D>("Graphics/hud_8");
        num9 = Resources.Load<Texture2D>("Graphics/hud_9");

        SetSizes();

        isEnable = true;
    }

    void SetSizes()
    {
        scale = (float)Screen.width / 1920 * 2;

        buttonWidth = (buttonWidth * Screen.width) / 1920;
        buttonHeight = (buttonHeight * Screen.height) / 1080;
        buttonMargin = (buttonMargin * Screen.height) / 1080;
        buttonTextureSize = (buttonTextureSize * Screen.height) / 1080;

        margin *= scale;
        textureWidth = healthEmptyGUI.width * scale;
        textureHeight = healthEmptyGUI.height * scale;
        coinSize = coinGUI.width * scale;
        numWidth = num0.width * scale;
        numHeight = num0.height * scale;

        point = new Rect[]
        {
            new Rect(Screen.width - margin * 2 - numWidth, margin * 3.5f + textureHeight + coinSize, numWidth, numHeight),
            new Rect(Screen.width - margin * 2 - numWidth * 2, margin * 3.5f + textureHeight + coinSize, numWidth, numHeight),
            new Rect(Screen.width - margin * 2 - numWidth * 3, margin * 3.5f + textureHeight + coinSize, numWidth, numHeight)
        };
    }
}