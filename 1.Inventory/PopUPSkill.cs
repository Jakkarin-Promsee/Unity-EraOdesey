using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUPSkill : MonoBehaviour
{
    public GameObject ChooseSkillPanels;
    public GameObject FlashingBackground;
    public GameObject Flashing;

    public Slider AmountSlider;
    public Image Background;
    public Image BackgroundIcon;
    public Image Icon;
    public TMP_Text LevelName;
    public TMP_Text Name;
    public Image BackgroundPercentAmount;
    public Image PercentAmount;
    public TMP_Text Level;
    public TMP_Text Amount;
    public TMP_Text Detail;
    public TMP_Text CoolDown;
    public TMP_Text TypeDamage;
    public TMP_Text UpgradeText;
    public TMP_Text EquipText;
    Image DefaultBackground;
    Image DefaultBackgroundIcon;
    Image DefaultICon;
    Image DefaultBackgroundPercentAmount;
    Image DefaultPercentAmount;

    public int ID;
    public int KeepTypeOfSkill;
    SkillSlotEarth KeepSkillDataEarth;
    SkillSlotFire KeepSkillDataFire;
    SkillSlotFrost KeepSkillDataFrost;
    SkillSlotWater KeepSkillDataWater;

    string Text_Cooldown = "";

    public void ChangeLanguageToDefault()
    {
        Text_Cooldown = "";
        UpgradeText.text = "";
        EquipText.text = "";
    }

    public void ChangeLanguageToEnglish()
    {
        Text_Cooldown = "CoolDown : ";
        UpgradeText.text = "Upgrade";
        EquipText.text = "Equip";
    }

    public void ChangeLanguageToThai()
    {
        Text_Cooldown = "คูลดาวน์ : ";
        UpgradeText.text = "อัปเกรด";
        EquipText.text = "สวมใส่";
    }

    private void Awake() {
        Invoke("SetAllPanelTrue",0f);
        Invoke("SetAllPanelFalse",0.2f);


        DefaultBackground = Background;
        DefaultBackgroundIcon = BackgroundIcon;
        DefaultICon = Icon;
        DefaultBackgroundPercentAmount = BackgroundPercentAmount;
        DefaultPercentAmount = PercentAmount;

        ClearPanel();
    }

    public void SetAllPanelTrue()
    {
        ChooseSkillPanels.SetActive(true);
        FlashingBackground.SetActive(true);
        Flashing.SetActive(true);
    }

    public void SetAllPanelFalse()
    {
        ChooseSkillPanels.SetActive(false);
        FlashingBackground.SetActive(false);
        Flashing.SetActive(false);
    }

    public void UpdateAuto()
    {
        if(KeepTypeOfSkill == 0)
        {
            UpdatePanel(0, KeepSkillDataEarth, null, null, null);
        }
        else if(KeepTypeOfSkill == 1)
        {
            UpdatePanel(1, null, KeepSkillDataFire, null, null);
        }
        else if(KeepTypeOfSkill == 2)
        {
            UpdatePanel(2, null, null, KeepSkillDataFrost, null);
        }
        else if(KeepTypeOfSkill == 3)
        {
            UpdatePanel(3, null, null, null, KeepSkillDataWater);
        }
    }

    public void UpdatePanel(int newTypeSkill,SkillSlotEarth NewSkillSlotEarth, SkillSlotFire NewSkillSlotFire, SkillSlotFrost NewSkillSlotFrost, SkillSlotWater NewSkillSlotWater)
    {
        Sprite newIcon = null;
        string newLevelName = "";
        string newName = "";
        string newLevel = "";
        string newAmount = "";
        string newDetail = "";
        string newCoolDown = "";
        string newTypeDamage = "";
        float Percentrate = 0;

        if(newTypeSkill == 0)
        {
            ID = NewSkillSlotEarth.skillDataEarth.ID;
            KeepTypeOfSkill = 0;
            KeepSkillDataEarth = NewSkillSlotEarth;

            newIcon = NewSkillSlotEarth.skillDataEarth.Icon;
            newLevelName = NewSkillSlotEarth.skillDataEarth.LevelName;
            newName = NewSkillSlotEarth.skillDataEarth.Name;
            newAmount = NewSkillSlotEarth.skillDataEarth.Amount.ToString() + " / " + NewSkillSlotEarth.skillDataEarth.AmountToUpgrade.ToString();
            newLevel = NewSkillSlotEarth.skillDataEarth.Level.ToString();
            newDetail = NewSkillSlotEarth.skillDataEarth.Detail;
            newCoolDown = NewSkillSlotEarth.skillDataEarth.Cooldown.ToString();
            newTypeDamage = NewSkillSlotEarth.skillDataEarth.TypeDamage;

            if(NewSkillSlotEarth.skillDataEarth.Amount>=NewSkillSlotEarth.skillDataEarth.AmountToUpgrade) Percentrate = 1f;
            else Percentrate = (float)NewSkillSlotEarth.skillDataEarth.Amount / NewSkillSlotEarth.skillDataEarth.AmountToUpgrade;
        }
        else if(newTypeSkill == 1)
        {
            ID = NewSkillSlotFire.skillDataFire.ID;
            KeepTypeOfSkill = 1;
            KeepSkillDataFire = NewSkillSlotFire;

            newIcon = NewSkillSlotFire.skillDataFire.Icon;
            newLevelName = NewSkillSlotFire.skillDataFire.LevelName;
            newName = NewSkillSlotFire.skillDataFire.Name;
            newAmount = NewSkillSlotFire.skillDataFire.Amount.ToString() + " / " + NewSkillSlotFire.skillDataFire.AmountToUpgrade.ToString();
            newLevel = NewSkillSlotFire.skillDataFire.Level.ToString();
            newDetail = NewSkillSlotFire.skillDataFire.Detail;
            newCoolDown = NewSkillSlotFire.skillDataFire.Cooldown.ToString();
            newTypeDamage = NewSkillSlotFire.skillDataFire.TypeDamage;

            if(NewSkillSlotFire.skillDataFire.Amount>=NewSkillSlotFire.skillDataFire.AmountToUpgrade) Percentrate = 1f;
            else Percentrate = (float)NewSkillSlotFire.skillDataFire.Amount / NewSkillSlotFire.skillDataFire.AmountToUpgrade;
        }
        else if(newTypeSkill == 2)
        {
            ID = NewSkillSlotFrost.skillDataFrost.ID;
            KeepTypeOfSkill = 2;
            KeepSkillDataFrost = NewSkillSlotFrost;

            newIcon = NewSkillSlotFrost.skillDataFrost.Icon;
            newLevelName = NewSkillSlotFrost.skillDataFrost.LevelName;
            newName = NewSkillSlotFrost.skillDataFrost.Name;
            newAmount = NewSkillSlotFrost.skillDataFrost.Amount.ToString() + " / " + NewSkillSlotFrost.skillDataFrost.AmountToUpgrade.ToString();
            newLevel = NewSkillSlotFrost.skillDataFrost.Level.ToString();
            newDetail = NewSkillSlotFrost.skillDataFrost.Detail;
            newCoolDown = NewSkillSlotFrost.skillDataFrost.Cooldown.ToString();
            newTypeDamage = NewSkillSlotFrost.skillDataFrost.TypeDamage;

            if(NewSkillSlotFrost.skillDataFrost.Amount>=NewSkillSlotFrost.skillDataFrost.AmountToUpgrade) Percentrate = 1f;
            else Percentrate = (float)NewSkillSlotFrost.skillDataFrost.Amount / NewSkillSlotFrost.skillDataFrost.AmountToUpgrade;
        }
        else if(newTypeSkill == 3)
        {
            ID = NewSkillSlotWater.skillDataWater.ID;
            KeepTypeOfSkill = 3;
            KeepSkillDataWater = NewSkillSlotWater;

            newIcon = NewSkillSlotWater.skillDataWater.Icon;
            newLevelName = NewSkillSlotWater.skillDataWater.LevelName;
            newName = NewSkillSlotWater.skillDataWater.Name;
            newAmount = NewSkillSlotWater.skillDataWater.Amount.ToString() + " / " + NewSkillSlotWater.skillDataWater.AmountToUpgrade.ToString();
            newLevel = NewSkillSlotWater.skillDataWater.Level.ToString();
            newDetail = NewSkillSlotWater.skillDataWater.Detail;
            newCoolDown = NewSkillSlotWater.skillDataWater.Cooldown.ToString();
            newTypeDamage = NewSkillSlotWater.skillDataWater.TypeDamage;

            if(NewSkillSlotWater.skillDataWater.Amount>=NewSkillSlotWater.skillDataWater.AmountToUpgrade) Percentrate = 1f;
            else Percentrate = (float)NewSkillSlotWater.skillDataWater.Amount / NewSkillSlotWater.skillDataWater.AmountToUpgrade;
        }

        
        
        AmountSlider.value = Percentrate;

        Icon.sprite = newIcon;
        Icon.color = Color.white;
        LevelName.text = "[" + newLevelName + "]";
        Name.text = newName;
        Amount.text = newAmount;
        Level.text = "lv." + newLevel;
        Detail.text = newDetail;
        CoolDown.text = Text_Cooldown + newCoolDown + "s";
        TypeDamage.text = newTypeDamage;
    }
    public void ClearPanel()
    {
        AmountSlider.value = 0f;

        Background = DefaultBackground;
        BackgroundIcon = DefaultBackgroundIcon;
        Icon = DefaultICon;
        Icon.sprite = null;
        BackgroundPercentAmount = DefaultBackgroundPercentAmount;
        PercentAmount = DefaultPercentAmount;

        LevelName.text = "";
        Name.text = "";
        Amount.text = "";
        Detail.text = "";
        CoolDown.text = "";
        TypeDamage.text = "";
    }

    public void UpSkillLevel()
    {
        if(KeepTypeOfSkill == 0)
        {
            KeepSkillDataEarth.UpLevel();
        }
        else if(KeepTypeOfSkill == 1)
        {
            KeepSkillDataFire.UpLevel();
        }
        else if(KeepTypeOfSkill == 2)
        {
            KeepSkillDataFrost.UpLevel();
        }
        else if(KeepTypeOfSkill == 3)
        {
            KeepSkillDataWater.UpLevel();
        }
        UpdateAuto();
    }
}
