using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static PlayerData data;
    public static SettingsData settingsData;

    void Awake()
    {
        GUIData guiData;

        if (!GUIData.isEnable)
            guiData = new GUIData();

        data = new PlayerData();
        settingsData = new SettingsData();

        LoadSave.Load();
    }

    void OnGUI()
    {
        GUI.skin = GUIData.skin;

        if (GUI.Button(new Rect(Screen.width / 2 - GUIData.buttonWidth / 2, Screen.height / 2 - GUIData.buttonHeight / 2, GUIData.buttonWidth, GUIData.buttonHeight), "Play"))
            SceneManager.LoadScene(1);
        if (GUI.Button(new Rect(0, 0, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.settingsTexture))
            SceneManager.LoadScene(3);
        if (GUI.Button(new Rect(0, GUIData.buttonTextureSize, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.shopTexture))
            SceneManager.LoadScene(4);
        if (GUI.Button(new Rect(0, GUIData.buttonTextureSize * 2, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.leaderboardsTexture))
            ;// load leaderboards
        if (GUI.Button(new Rect(0, GUIData.buttonTextureSize * 3, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.achivementsTexture))
            ;// load achievements

        GUIPrefabs.Coins();
    }

    void Quit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif

    }
}