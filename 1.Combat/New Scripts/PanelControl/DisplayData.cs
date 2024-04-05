using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DisplayData : MonoBehaviour
{
    public Image Background;
    public Image icon;
    public TMP_Text cooldown;
    
    public GameObject NoPanel;
    public bool IsClicked = false;
    public bool IsActivate = false,
                IsUse = false;
    public bool IsEarthSkill = false,
                IsFireSkill = false,
                IsFrostSkill = false,
                IsWaterSkill = false;
    public int NumberOfSkill = 0;

    public double currentCooldown = 0;

    public void Load(SkillPanelDataKeep data)
    {
        IsActivate = data.IsActivate;
        IsUse = data.IsUse;
        
        IsEarthSkill = data.IsEarthSkill;
        IsFireSkill = data.IsFireSkill;
        IsFrostSkill = data.IsFrostSkill;
        IsWaterSkill = data.IsWaterSkill;

        NumberOfSkill = data.NumberOfSkill;
    }

    public void IsClickedButton()
    {
        IsClicked = true;
    }

    public void ClearAllDataSkill()
    {
        IsActivate = false;
        IsUse = false;
        IsEarthSkill = false;
        IsFireSkill = false;
        IsFrostSkill = false;
        IsWaterSkill = false;
        NumberOfSkill = 0;
    }

    public void DefaultSkill()
    {
        Background.color = Color.gray;
        icon.color = Color.white;
        icon.sprite = null;
        cooldown.text = "";
    }


    public void FreeSkill()
    {
        Background.color = Color.gray;
        icon.color = Color.clear;
        icon.sprite = null;
        cooldown.text = "";
    }

    public void LockSkill()
    {
        Background.color = Color.black;
        icon.color = Color.clear;
        icon.sprite = null;
        cooldown.text = "";
    }
}
