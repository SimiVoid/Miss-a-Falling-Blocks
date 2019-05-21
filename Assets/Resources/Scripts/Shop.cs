using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    ShopItemCollection shopItemCollection;

    void Start()
    {
        LoadShopData();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadSave.Save();
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
            LoadSave.Save();
            SceneManager.LoadScene(0);
        }

        GUIPrefabs.Coins();

        foreach (ShopItem item in shopItemCollection.shopItems)
        {
            GUIPrefabs.ShopItemRecord(item);
        }
    }

    void LoadShopData()
    {
        TextAsset jsonText = Resources.Load("Shop") as TextAsset;

        if (jsonText != null)
        {
            shopItemCollection = JsonUtility.FromJson<ShopItemCollection>(jsonText.text);
        }
    }
}
