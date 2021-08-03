using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    public bool LoadBool(string key, bool defaultValue)
    {
        return Convert.ToBoolean(LoadInt(key, Convert.ToInt32(defaultValue)));
    }

}
