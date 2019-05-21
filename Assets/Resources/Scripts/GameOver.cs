using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        GUI.skin = GUIData.skin;
        GUI.skin.label.fontSize = 70;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        if (GUI.Button(new Rect(Screen.width / 2 - GUIData.buttonWidth - GUIData.buttonMargin, Screen.height / 2 + GUIData.buttonHeight / 2 + GUIData.buttonMargin, GUIData.buttonWidth, GUIData.buttonHeight), "Menu"))
            SceneManager.LoadScene(0);
        if (GUI.Button(new Rect(Screen.width / 2 + GUIData.buttonMargin , Screen.height / 2 + GUIData.buttonHeight / 2 + GUIData.buttonMargin, GUIData.buttonWidth, GUIData.buttonHeight), "New Game"))
            SceneManager.LoadScene(1);

        string text = "Points: " + Player.points.ToString();

        GUI.Label(new Rect(Screen.width / 2 - GUIData.buttonWidth / 2, Screen.height / 2 - GUIData.buttonHeight / 2, GUIData.buttonWidth, GUIData.buttonHeight), text);

        GUIPrefabs.Coins();
    }
}
