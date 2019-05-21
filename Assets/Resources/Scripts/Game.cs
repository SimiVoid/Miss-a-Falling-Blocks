using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    float lastPosX = 0.0f;
    
    System.Random random;

    int level = 1;
    int tick = 0;
    public static bool onPlay;
    
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject box1;
    public GameObject box2;
    public GameObject brickWall;
    public GameObject coin;
    public GameObject protection;
    public GameObject empty;

    public float fallingSpeed;

    public static Camera camera;

    public static Vector2 size;

    Rect[] coinData;

    void Awake()
    {
        camera = Camera.main;
        size = new Vector2(camera.orthographicSize * camera.aspect * 2, camera.orthographicSize * 2);

        coinData = new Rect[]
        {
            new Rect(Screen.width - GUIData.margin * 2 - GUIData.coinSize - GUIData.numWidth, GUIData.margin * 2.5f + GUIData.textureHeight, GUIData.numWidth, GUIData.numHeight),
            new Rect(Screen.width - GUIData.margin * 2 - GUIData.coinSize - GUIData.numWidth * 2, GUIData.margin * 2.5f + GUIData.textureHeight, GUIData.numWidth, GUIData.numHeight)
        };

        random = new System.Random();

        onPlay = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPlay) onPlay = false;
            else onPlay = true;
        }
    }

    void FixedUpdate()
    {
        if(onPlay)
        {
            if (tick % 250 == 0)
                CreateBlock();

            if (tick == 1000000) tick = 0;

            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

            GameObject[] protections = GameObject.FindGameObjectsWithTag("Protection");

            foreach (GameObject block in blocks)
            {
                if (block.GetComponent<Transform>().position.y < -(size.y / 2 + 0.5f))
                {
                    Destroy(block);

                    Player.points++;
                }
                else
                {
                    block.GetComponent<Transform>().position = new Vector3(block.GetComponent<Transform>().position.x, block.GetComponent<Transform>().position.y - fallingSpeed / 1000);
                }
            }

            foreach (GameObject coin in coins)
            {
                if (coin.GetComponent<Transform>().position.y < -(size.y / 2 + 0.5f))
                {
                    Destroy(coin);
                }
                else
                {
                    coin.GetComponent<Transform>().position = new Vector3(coin.GetComponent<Transform>().position.x, coin.GetComponent<Transform>().position.y - fallingSpeed / 1000);
                }
            }

            foreach (GameObject protection in protections)
            {
                if (protection.GetComponent<Transform>().position.y < -(size.y / 2 + 0.5f))
                {
                    Destroy(protection);
                }
                else
                {
                    protection.GetComponent<Transform>().position = new Vector3(protection.GetComponent<Transform>().position.x, protection.GetComponent<Transform>().position.y - fallingSpeed / 1000);
                }
            }

            if (Player.points == level * 50)
            {
                fallingSpeed++;
                level++;
            }

            tick++;
        }
    }

    void OnGUI()
    {
        GUI.skin = GUIData.skin;

        GUIPrefabs.DrawHealths();

        ShowCoins();
        ShowPoints();

        if(Player.protectionEnable)
        {
            GUI.Label(new Rect(0, 0, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.protectionTexture);
        }

        if (onPlay)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                if(GUI.Button(new Rect(0, 0, GUIData.buttonTextureSize, GUIData.buttonTextureSize), GUIData.pauseTexture))
                {
                    onPlay = false;
                }

            }
        }
        else PauseMenu();
    }

    void ShowCoins()
    {
        GUI.DrawTexture(new Rect(Screen.width - GUIData.margin - GUIData.coinSize, GUIData.margin * 2 + GUIData.textureHeight, GUIData.coinSize, GUIData.coinSize), GUIData.coinGUI);

        if (Player.coins % 10 == 0)
            GUI.DrawTexture(coinData[0], GUIData.num0);
        else if (Player.coins % 10 == 1)
            GUI.DrawTexture(coinData[0], GUIData.num1);
        else if (Player.coins % 10 == 2)
            GUI.DrawTexture(coinData[0], GUIData.num2);
        else if (Player.coins % 10 == 3)
            GUI.DrawTexture(coinData[0], GUIData.num3);
        else if (Player.coins % 10 == 4)
            GUI.DrawTexture(coinData[0], GUIData.num4);
        else if (Player.coins % 10 == 5)
            GUI.DrawTexture(coinData[0], GUIData.num5);
        else if (Player.coins % 10 == 6)
            GUI.DrawTexture(coinData[0], GUIData.num6);
        else if (Player.coins % 10 == 7)
            GUI.DrawTexture(coinData[0], GUIData.num7);
        else if (Player.coins % 10 == 8)
            GUI.DrawTexture(coinData[0], GUIData.num8);
        else if (Player.coins % 10 == 9)
            GUI.DrawTexture(coinData[0], GUIData.num9);

        if ((Player.coins - Player.coins % 10) / 10 == 0)
            GUI.DrawTexture(coinData[1], GUIData.num0);
        else if ((Player.coins - Player.coins % 10) / 10 == 1)
            GUI.DrawTexture(coinData[1], GUIData.num1);
        else if ((Player.coins - Player.coins % 10) / 10 == 2)
            GUI.DrawTexture(coinData[1], GUIData.num2);
        else if ((Player.coins - Player.coins % 10) / 10 == 3)
            GUI.DrawTexture(coinData[1], GUIData.num3);
        else if ((Player.coins - Player.coins % 10) / 10 == 4)
            GUI.DrawTexture(coinData[1], GUIData.num4);
        else if ((Player.coins - Player.coins % 10) / 10 == 5)
            GUI.DrawTexture(coinData[1], GUIData.num5);
        else if ((Player.coins - Player.coins % 10) / 10 == 6)
            GUI.DrawTexture(coinData[1], GUIData.num6);
        else if ((Player.coins - Player.coins % 10) / 10 == 7)
            GUI.DrawTexture(coinData[1], GUIData.num7);
        else if ((Player.coins - Player.coins % 10) / 10 == 8)
            GUI.DrawTexture(coinData[1], GUIData.num8);
        else if ((Player.coins - Player.coins % 10) / 10 == 9)
            GUI.DrawTexture(coinData[1], GUIData.num9);
    }

    void ShowPoints()
    {
        if (Player.points % 10 == 0)
            GUI.DrawTexture(GUIData.point[0], GUIData.num0);
        else if (Player.points % 10 == 1)
            GUI.DrawTexture(GUIData.point[0], GUIData.num1);
        else if (Player.points % 10 == 2)
            GUI.DrawTexture(GUIData.point[0], GUIData.num2);
        else if (Player.points % 10 == 3)
            GUI.DrawTexture(GUIData.point[0], GUIData.num3);
        else if (Player.points % 10 == 4)
            GUI.DrawTexture(GUIData.point[0], GUIData.num4);
        else if (Player.points % 10 == 5)
            GUI.DrawTexture(GUIData.point[0], GUIData.num5);
        else if (Player.points % 10 == 6)
            GUI.DrawTexture(GUIData.point[0], GUIData.num6);
        else if (Player.points % 10 == 7)
            GUI.DrawTexture(GUIData.point[0], GUIData.num7);
        else if (Player.points % 10 == 8)
            GUI.DrawTexture(GUIData.point[0], GUIData.num8);
        else if (Player.points % 10 == 9)
            GUI.DrawTexture(GUIData.point[0], GUIData.num9);

        if ((Player.points % 100 - Player.points % 10) / 10 == 0)
            GUI.DrawTexture(GUIData.point[1], GUIData.num0);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 1)
            GUI.DrawTexture(GUIData.point[1], GUIData.num1);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 2)
            GUI.DrawTexture(GUIData.point[1], GUIData.num2);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 3)
            GUI.DrawTexture(GUIData.point[1], GUIData.num3);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 4)
            GUI.DrawTexture(GUIData.point[1], GUIData.num4);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 5)
            GUI.DrawTexture(GUIData.point[1], GUIData.num5);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 6)
            GUI.DrawTexture(GUIData.point[1], GUIData.num6);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 7)
            GUI.DrawTexture(GUIData.point[1], GUIData.num7);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 8)
            GUI.DrawTexture(GUIData.point[1], GUIData.num8);
        else if ((Player.points % 100 - Player.points % 10) / 10 == 9)
            GUI.DrawTexture(GUIData.point[1], GUIData.num9);

        if ((Player.points - Player.points % 10) / 100 == 0)
            GUI.DrawTexture(GUIData.point[2], GUIData.num0);
        else if ((Player.points - Player.points % 10) / 100 == 1)
            GUI.DrawTexture(GUIData.point[2], GUIData.num1);
        else if ((Player.points - Player.points % 10) / 100 == 2)
            GUI.DrawTexture(GUIData.point[2], GUIData.num2);
        else if ((Player.points - Player.points % 10) / 100 == 3)
            GUI.DrawTexture(GUIData.point[2], GUIData.num3);
        else if ((Player.points - Player.points % 10) / 100 == 4)
            GUI.DrawTexture(GUIData.point[2], GUIData.num4);
        else if ((Player.points - Player.points % 10) / 100 == 5)
            GUI.DrawTexture(GUIData.point[2], GUIData.num5);
        else if ((Player.points - Player.points % 10) / 100 == 6)
            GUI.DrawTexture(GUIData.point[2], GUIData.num6);
        else if ((Player.points - Player.points % 10) / 100 == 7)
            GUI.DrawTexture(GUIData.point[2], GUIData.num7);
        else if ((Player.points - Player.points % 10) / 100 == 8)
            GUI.DrawTexture(GUIData.point[2], GUIData.num8);
        else if ((Player.points - Player.points % 10) / 100 == 9)
            GUI.DrawTexture(GUIData.point[2], GUIData.num9);
    }

    void PauseMenu()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - GUIData.buttonWidth / 2, Screen.height / 2 - GUIData.buttonHeight - GUIData.buttonMargin / 2, GUIData.buttonWidth, GUIData.buttonHeight), "Resume"))
            onPlay = true;
        if (GUI.Button(new Rect(Screen.width / 2 - GUIData.buttonWidth / 2, Screen.height / 2 + GUIData.buttonMargin / 2, GUIData.buttonWidth, GUIData.buttonHeight), "Menu"))
            SceneManager.LoadScene(0);
    }

    void CreateBlock()
    {
        int maxValue = 65;

        if (Menu.data.wraithBlockUnlock)
            maxValue += 10;

        if (Menu.data.protectionUnlock)
            maxValue += 1;

        int n = random.Next(maxValue);

        float posX = (float)random.Next(-(int)(size.x * 50 - GUIData.textureWidth), (int)(size.x * 50 - GUIData.textureWidth)) / 100;

        if (posX == lastPosX)
            posX = (float)random.Next(-(int)(size.x * 50 - GUIData.textureWidth), (int)(size.x * 50 - GUIData.textureWidth)) / 100;
        else lastPosX = posX;

        if(!Menu.data.wraithBlockUnlock && !Menu.data.protectionUnlock)
        {
            if (n < 10)
                Instantiate(block1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 20 && n >= 10)
                Instantiate(block2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 30 && n >= 20)
                Instantiate(block3, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 40 && n >= 30)
                Instantiate(box1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 50 && n >= 40)
                Instantiate(box2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 60 && n >= 50)
                Instantiate(brickWall, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 65 && n >= 60)
                Instantiate(coin, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
        }
        else if(!Menu.data.wraithBlockUnlock && Menu.data.protectionUnlock)
        {
            if (n < 10)
                Instantiate(block1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 20 && n >= 10)
                Instantiate(block2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 30 && n >= 20)
                Instantiate(block3, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 40 && n >= 30)
                Instantiate(box1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 50 && n >= 40)
                Instantiate(box2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 60 && n >= 50)
                Instantiate(brickWall, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 65 && n >= 60)
                Instantiate(coin, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 66 && n >= 65)
                Instantiate(protection, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
        }
        else if (Menu.data.wraithBlockUnlock && !Menu.data.protectionUnlock)
        {
            if (n < 10)
                Instantiate(block1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 20 && n >= 10)
                Instantiate(block2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 30 && n >= 20)
                Instantiate(block3, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 40 && n >= 30)
                Instantiate(box1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 50 && n >= 40)
                Instantiate(box2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 60 && n >= 50)
                Instantiate(brickWall, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 65 && n >= 60)
                Instantiate(coin, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 75 && n >= 65)
                Instantiate(empty, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
        }
        else if (Menu.data.wraithBlockUnlock && Menu.data.protectionUnlock)
        {
            if (n < 10)
                Instantiate(block1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 20 && n >= 10)
                Instantiate(block2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 30 && n >= 20)
                Instantiate(block3, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 40 && n >= 30)
                Instantiate(box1, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 50 && n >= 40)
                Instantiate(box2, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 60 && n >= 50)
                Instantiate(brickWall, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 65 && n >= 60)
                Instantiate(coin, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 75 && n >= 65)
                Instantiate(empty, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
            else if (n < 76 && n >= 75)
                Instantiate(protection, new Vector3(posX, size.y / 2 + 0.5f), Quaternion.identity);
        }
    }
}
