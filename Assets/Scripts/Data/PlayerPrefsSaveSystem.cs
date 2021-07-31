using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveSystem
{
    public int LoadInt(string key, int defaultValue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else
        {
            SaveInt(key, defaultValue);
            return LoadInt(key, defaultValue);
        }
    }

    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
