using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillPanelDataKeep
{
    public bool IsActivate = false,
                IsUse = false;
    public bool IsEarthSkill = false,
                IsFireSkill = false,
                IsFrostSkill = false,
                IsWaterSkill = false;
    public int NumberOfSkill = -1;

    public void SaveNewData(DisplayData display)
    {
        IsActivate = display.IsActivate;
        IsUse = display.IsUse;
        
        IsEarthSkill = display.IsEarthSkill;
        IsFireSkill = display.IsFireSkill;
        IsFrostSkill = display.IsFrostSkill;
        IsWaterSkill = display.IsWaterSkill;

        NumberOfSkill = display.NumberOfSkill;
    }

    public void NewData()
    {
        IsActivate = false;
        IsUse = false;
        
        IsEarthSkill = false;
        IsFireSkill = false;
        IsFrostSkill =false;
        IsWaterSkill = false;

        NumberOfSkill = -1;
    }
}
