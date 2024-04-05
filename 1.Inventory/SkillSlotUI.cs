using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlotUI : MonoBehaviour
{
    private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    public Slider AmountSlide;
    public Image Background;
    public Image ImageSkill;
    public Image BackgroundPercentAmount;
    public Image PercentAmount;
    public TMP_Text Level;
    public TMP_Text Amount;
    public Button Button;

    public bool IsClick = false;
    public int ID  = -1;
    public int TypeSkill = -1;

    Color OldColorPercent;

    private void Start() {
        OldColorPercent = PercentAmount.color;
    }

    public void ButtomWasClicked()
    {
        IsClick = true;
    }

    public void ClearSlot()
    {
        AmountSlide.value = 0f;
        ImageSkill.color = Color.clear;
        BackgroundPercentAmount.color = Background.color;

        Level.text = "";
        Amount.text = "";

        ID = -1;
        TypeSkill = -1;
    }

    public void UpdateSlot(int newID, int newTypeSkill, Sprite newImageSkill, long newLevel, long newAmount ,long AmountToUpgrade)
    {
        if(newAmount >= AmountToUpgrade) AmountSlide.value = 1;
        else AmountSlide.value = (float)newAmount / AmountToUpgrade;

        Background.color = Color.white;
        ImageSkill.color = Color.white;
        ImageSkill.sprite = newImageSkill;
        BackgroundPercentAmount.color = Color.white;
        PercentAmount.color = OldColorPercent;

        Level.text = "lv."+newLevel.ToString();
        Amount.text = newAmount.ToString() + " / " + AmountToUpgrade.ToString();

        ID = newID;
        TypeSkill = newTypeSkill;
    }
}
