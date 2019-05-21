using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadSave
{
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/saves/data.bin"))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream file = File.Open(Application.persistentDataPath + "/saves/data.bin", FileMode.Open);
                Menu.data = (PlayerData)formatter.Deserialize(file);
                file.Close();
            }
            catch
            {

            }
        }

        if (File.Exists(Application.persistentDataPath + "/saves/settings.bin"))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream file = File.Open(Application.persistentDataPath + "/saves/settings.bin", FileMode.Open);
                Menu.settingsData = (SettingsData)formatter.Deserialize(file);
                file.Close();
            }
            catch
            {

            }
        }
    }

    public static void Save()
    {
        try
        {
            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream file = File.Create(Application.persistentDataPath + "/saves/data.bin");
            formatter.Serialize(file, new PlayerData(Menu.data));
            file.Close();
        }
        catch
        {

        }
    }

    public static void SaveSettings()
    {
        try
        {
            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream file = File.Create(Application.persistentDataPath + "/saves/settings.bin");
            formatter.Serialize(file, new SettingsData(Menu.settingsData));
            file.Close();
        }
        catch
        {

        }
    }
}