using System;

public class ShopActions
{
    public static bool AddHealth()
    {
        if (Menu.data.maxHealth < StaticVariables.maxHealth)
        {
            Menu.data.maxHealth++;

            return true;
        }
        else return false;
    }

    public static bool AddSpeed()
    {
        if (Menu.data.speed < StaticVariables.maxSpeed)
        {
            Menu.data.speed++;

            return true;
        }
        else return false;
    }

    public static bool AddBlock(ShopItem shopItem)
    {
        if (shopItem.id == 0 && Menu.data.protectionUnlock == false)
        {
            Menu.data.protectionUnlock = true;

            return true;
        }
        else if (shopItem.id == 3 && Menu.data.wraithBlockUnlock == false)
        {
            Menu.data.wraithBlockUnlock = true;

            return true;
        }
            
        return false;
    }
}