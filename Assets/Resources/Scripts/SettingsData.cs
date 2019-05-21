using System;

[Serializable]
public class SettingsData
{
    public float master;
    public bool masterMute;
    public float music;
    public bool musicMute;
    public float sounds;
    public bool soundsMute;
    public bool vibrations;

    public SettingsData()
    {
        master = 100;
        masterMute = false;
        music = 100;
        musicMute = false;
        sounds = 100;
        soundsMute = false;
        vibrations = false;
    }

    public SettingsData(SettingsData settingsData)
    {
        master = settingsData.master;
        masterMute = settingsData.masterMute;
        music = settingsData.music;
        musicMute = settingsData.musicMute;
        sounds = settingsData.sounds;
        soundsMute = settingsData.soundsMute;
        vibrations = settingsData.vibrations;
    }
}