using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float health;
    public static int coins;
    public static int points;

    public static bool protectionEnable;
    private int tick;

    private Vector3 resetPosition = new Vector3(0, -4.34f);

    void Start()
    {
        health = Menu.data.maxHealth;
        coins = 0;
        points = 0;
        protectionEnable = false;
        tick = 0;
    }

    void Update ()
    {
		if(Game.onPlay)
        {
            Move();
        }
	}

    void FixedUpdate()
    {
        Vector3 playerPos = GetComponent<Transform>().position;

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        GameObject[] coinsObj = GameObject.FindGameObjectsWithTag("Coin");
        GameObject[] protections = GameObject.FindGameObjectsWithTag("Protection");

        foreach (GameObject block in blocks)
        {
            Vector3 pos = block.GetComponent<Transform>().position;

            if (pos.y - 0.5f <= playerPos.y + 1.314286f / 2
                && pos.x + 0.5f >= playerPos.x - 0.9428571f / 2
                && pos.x - 0.5f <= playerPos.x + 0.9428571f / 2)
            {
                if (protectionEnable)
                {
                    Destroy(block);
                }
                else
                {
                    health--;

                    if (Application.platform == RuntimePlatform.Android && Menu.settingsData.vibrations)
                    {
                        Handheld.Vibrate();
                    }

                    if (health == 0)
                    {
                        Menu.data.coins += coins;

                        if (Menu.data.heightStore < points)
                            Menu.data.heightStore = points;

                        LoadSave.Save();

                        SceneManager.LoadScene(2);
                    }
                    else
                    {
                        ResetPlayer();

                        foreach (GameObject blockToDestroy in blocks)
                        {
                            Destroy(blockToDestroy);
                        }

                        foreach (GameObject coin in coinsObj)
                        {
                            Destroy(coin);
                        }

                        foreach (GameObject protection in protections)
                        {
                            Destroy(protection);
                        }
                    }
                }
            }
        }

        foreach (GameObject coin in coinsObj)
        {
            Vector3 pos = coin.GetComponent<Transform>().position;

            if (pos.y - 0.5f <= playerPos.y + 1.314286f / 2
                && pos.x + 0.5f >= playerPos.x - 0.9428571f / 2
                && pos.x - 0.5f <= playerPos.x + 0.9428571f / 2)
            {
                coins++;

                Destroy(coin);
            }
        }

        foreach (GameObject protection in protections)
        {
            Vector3 pos = protection.GetComponent<Transform>().position;

            if (pos.y - 0.5f <= playerPos.y + 1.314286f / 2
                && pos.x + 0.5f >= playerPos.x - 0.9428571f / 2
                && pos.x - 0.5f <= playerPos.x + 0.9428571f / 2)
            {
                protectionEnable = true;

                Destroy(protection);
            }
        }

        if (protectionEnable)
        {
            tick++;

            if (tick == 10000)
            {
                tick = 0;

                protectionEnable = false;
            }
        }
    }

    void Move()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor
                || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (Input.GetKey(KeyCode.A))
                MoveLeft();
            if (Input.GetKey(KeyCode.D))
                MoveRight();
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
                MoveLeft();

            if (touch.position.x > Screen.width / 2)
                MoveRight();
        }
    }

    void ResetPlayer()
    {
        GetComponent<Transform>().position = resetPosition;
    }

    void MoveLeft()
    {
        if(GetComponent<Transform>().position.x >= -Game.size.x / 2 + 0.5f)
            GetComponent<Transform>().position += new Vector3(-Menu.data.speed / 100, 0);
    }

    void MoveRight()
    {
        if (GetComponent<Transform>().position.x <= Game.size.x / 2 - 0.5f)
            GetComponent<Transform>().position += new Vector3(Menu.data.speed / 100, 0);
    }
}
