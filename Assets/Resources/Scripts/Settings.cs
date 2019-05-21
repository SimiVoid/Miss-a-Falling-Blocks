using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            LoadSave.SaveSettings();
            SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        GUI.skin = GUIData.skin;
        GUI.skin.label.fontSize = 30;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;

        if (GUI.Button(new Rect(0, Screen.height - GUIData.buttonTextureSize, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.menuTexture))
        {
            LoadSave.SaveSettings();
            SceneManager.LoadScene(0);
        }

        GUI.Label(new Rect(Screen.width / 4, Screen.height / 2 - GUIData.buttonMargin - 180, Screen.width / 2, 100), "Master volume");
        Menu.settingsData.master = GUI.HorizontalSlider(new Rect(Screen.width / 4, Screen.height / 2 - GUIData.buttonMargin - 150, Screen.width / 2, 100), Menu.settingsData.master, 0, 100);
        GUI.Label(new Rect(Screen.width / 4, Screen.height / 2 - 80, Screen.width / 2, 100), "Music volume");
        Menu.settingsData.music = GUI.HorizontalSlider(new Rect(Screen.width / 4, Screen.height / 2 - 50, Screen.width / 2, 100), Menu.settingsData.music, 0, 100);
        GUI.Label(new Rect(Screen.width / 4, Screen.height / 2 + GUIData.buttonMargin + 20, Screen.width / 2, 100), "Sounds volume");
        Menu.settingsData.sounds = GUI.HorizontalSlider(new Rect(Screen.width / 4, Screen.height / 2 + GUIData.buttonMargin + 50, Screen.width / 2, 100), Menu.settingsData.sounds, 0, 100);

        if(Application.platform == RuntimePlatform.Android)
        {
            if (Menu.settingsData.vibrations == true)
            {
                if(GUI.Button(new Rect(Screen.width / 4 + Screen.width / 8, Screen.height / 2 + GUIData.buttonMargin * 2 + 100, GUIData.buttonTextureSize * 0.75f, GUIData.buttonTextureSize * 0.75f), GUIData.checkTexture))
                {
                    Menu.settingsData.vibrations = false;
                }
            }
            else
            {
                if (GUI.Button(new Rect(Screen.width / 4 + Screen.width / 8, Screen.height / 2 + GUIData.buttonMargin * 2 + 100, GUIData.buttonTextureSize * 0.75f, GUIData.buttonTextureSize * 0.75f), GUIData.crossTexture))
                {
                    Menu.settingsData.vibrations = true;
                }
            }

            GUI.Label(new Rect(Screen.width / 4, Screen.height / 2 + GUIData.buttonMargin * 3 + 90  , Screen.width / 4, 100), "Vibrations");
        }
    }
}
