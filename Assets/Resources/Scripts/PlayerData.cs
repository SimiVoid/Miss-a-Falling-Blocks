using System;

[Serializable]
public class PlayerData
{
    public int heightStore;
    public int coins;
    public int maxHealth;

    public float speed;

    public bool wraithBlockUnlock;
    public bool protectionUnlock;

    public PlayerData()
    {
        coins = 0;
        heightStore = 0;
        maxHealth = 3;
        speed = 8;

        wraithBlockUnlock = false;
        protectionUnlock = false;
    }

    public PlayerData(int heightStore, int coins, int maxHealth, float speed, bool protectionUnlock, bool wraithBlockUnlock)
    {
        this.heightStore = heightStore;
        this.coins = coins;
        this.speed = speed;
        this.maxHealth = maxHealth;
        this.protectionUnlock = protectionUnlock;
        this.wraithBlockUnlock = wraithBlockUnlock;
    }

    public PlayerData(PlayerData playerData)
    {
        coins = playerData.coins;
        heightStore = playerData.heightStore;
        maxHealth = playerData.maxHealth;
        speed = playerData.speed;
        wraithBlockUnlock = playerData.wraithBlockUnlock;
        protectionUnlock = playerData.protectionUnlock;
    }
}