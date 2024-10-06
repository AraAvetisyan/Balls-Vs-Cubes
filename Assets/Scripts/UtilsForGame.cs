using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public static class UtilsForGame
{
    public static void SetDateTime(string key, DateTime value)
    {
        string convertedToString = value.ToString("u", CultureInfo.InvariantCulture);
        Geekplay.Instance.PlayerData.LastSaveTime = convertedToString;
        Geekplay.Instance.Save();
    }
    public static DateTime GetDateTime(string key, DateTime value)
    {
        if(Geekplay.Instance.PlayerData.LastSaveTime != null)
        {
            string stored = Geekplay.Instance.PlayerData.LastSaveTime;
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return value;
        }
    }
}
