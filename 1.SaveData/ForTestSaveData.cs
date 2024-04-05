using System.ComponentModel.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ForTestSaveData : MonoBehaviour, IDataPersistance
{
    public TMP_Text TimeText;

    private DateTime LogInTime;
    private DateTime LogOutTime;
    private TimeSpan TimeAFK;

    public void LoadData(GameData data)
    {
        string dateString = data.LogOutTime;
        string format = "yyyy-MM-dd HH:mm:ss";
        
        DateTime.TryParseExact(dateString, format, null, System.Globalization.DateTimeStyles.None, out LogOutTime);
    }

    public void SaveData(ref GameData data)
    {
        data.LogOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    private void Start() {
        Invoke("AfterStart",1f);
    }

    private void AfterStart()
    {
        LogInTime = DateTime.Now;
        TimeAFK = LogInTime.Subtract(LogOutTime);

        Debug.Log("Log out Time: " + LogOutTime.ToString("yyyy-MM-dd HH:mm:ss"));
        Debug.Log("Log in Time: " + LogInTime.ToString("yyyy-MM-dd HH:mm:ss"));
        Debug.Log("Afk Time: " + TimeAFK.ToString(@"hh\:mm\:ss"));

        TimeText.text = TimeAFK.ToString(@"hh\:mm\:ss");
    }
}
