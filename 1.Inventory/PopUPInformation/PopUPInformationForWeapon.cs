using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopUPInformationForWeapon : MonoBehaviour
{
    private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    public GameObject ButtonUsee;
    public GameObject ButtonMainS;
    public GameObject ButtonSubS;

    public PopUPInformationForCraft popUPInformationForCraft;
    public EquipmentSystem equipmentSystem;
    public EquipmentUsingSystem equipmentUsingSystem;
    public Image LowerBackGround;
    public Image BackGround;
    public Image BackGroundIcon;
    public Image Icon;

    public TMP_Text MainName;
    public TMP_Text Period;
    public TMP_Text Damage;
    public TMP_Text Upgrade;
    public TMP_Text Detail;

    public TMP_Text ButtonCraft;
    public TMP_Text ButtonUse;

    Image DefultLowerBackGround;
    Image DefultBackGround;
    Image DefultBackGroundIcon;
    Image DefultIcon;

    InventorySlotWeapon NowWeapon = null;
    public int id;

    string Text_Damage;
    string Text_Strength;
    string Text_Upgrade;
    string Text_Craft;
    string Text_Equip;
    string Text_UnEquip;

    bool IsFirst = false;

    public void ChangeLanguageToDefault()
    {
        Text_Damage = "";
        Text_Strength = "";
        Text_Upgrade = "";
        Text_Craft = "";
        Text_Equip = "";
        Text_UnEquip = "";
    }

    public void ChangeLanguageToEnglish()
    {
        Text_Damage = "Damage : ";
        Text_Strength = "Strength : ";
        Text_Upgrade = "Upgrade";
        Text_Craft = "Craft";
        Text_Equip = "Equip";
        Text_UnEquip = "UnEquip";
    }

    public void ChangeLanguageToThai()
    {
        Text_Damage = "ดาเมจ : ";
        Text_Strength = "ความเเข็งเเกร่ง : ";
        Text_Upgrade = "อัปเกรด";
        Text_Craft = "สร้าง";
        Text_Equip = "สวมใส่";
        Text_UnEquip = "ถอด";
    }

    private void Start() 
    {
        DefultLowerBackGround = LowerBackGround;
        DefultBackGround = BackGround;
        DefultBackGroundIcon = BackGroundIcon;
        DefultIcon = Icon;

        ClearPanel();
    }

    public void ClearPanel()
    {
        MainName.text = "Error 154";

        LowerBackGround = DefultBackGround;
        BackGround = DefultBackGround;
        DefultBackGroundIcon = BackGroundIcon;
        Icon = DefultIcon;
        Icon.color = Color.white;
        Icon.sprite = null;
        BackGroundIcon.sprite = null;

        Damage.text = "!#$*@ : 99";
        Upgrade.text = "+99";
        Detail.text = "   I don't know";
    }

    public void UpdateAuto()
    {
        if(NowWeapon != null) UpdatePanel(NowWeapon);
    }

    public void UpdatePanel(InventorySlotWeapon inventorySlotWeapon)
    {
        ClearPanel();
        NowWeapon = inventorySlotWeapon;

        if(inventorySlotWeapon.ItemWeapon.EverHave) 
        {
            
            id = inventorySlotWeapon.ItemWeapon.ID;

            int NewID = inventorySlotWeapon.ItemWeapon.ID;
            Sprite NewIcon = inventorySlotWeapon.ItemWeapon.Icon;
            string NewMainName = inventorySlotWeapon.ItemWeapon.Name;
            string NewPeriod = inventorySlotWeapon.ItemWeapon.Period;
            string NewDetail = inventorySlotWeapon.ItemWeapon.Detail;

            inventorySlotWeapon.GetDamage(out double NDamage, out long MDamage);

            string NewDamageNumber = "";
            string NewUpgradeNumber = "";


            if (MDamage == 0)
            {
                NewDamageNumber = NDamage.ToString("F0");
            }
            else
            {
                if (NDamage < 10) NewDamageNumber = (NDamage * Mathf.Pow(1000, 1)).ToString("F0") + multiple[MDamage - 1];
                else NewDamageNumber = NDamage.ToString("F2") + multiple[MDamage];
            }

            if (inventorySlotWeapon.ReturnAmountToLong(out long amountNumberUpgrade))
            {
                NewUpgradeNumber = amountNumberUpgrade.ToString();
            }
            else{
                NewUpgradeNumber = inventorySlotWeapon.ItemWeapon.NumberAmount.ToString("F2") + multiple[inventorySlotWeapon.ItemWeapon.MultiplierAmount];
            }

            if(inventorySlotWeapon.ItemWeapon.EverHave) Icon.color = Color.white;
            else Icon.color = Color.black;
            
            MainName.text = NewMainName;
            Period.text = NewPeriod;
            Icon.sprite = NewIcon;
            if(NowWeapon.ItemWeapon.Sword) Damage.text = Text_Damage + NewDamageNumber;
            else Damage.text = Text_Strength + NewDamageNumber;
            Upgrade.text = "+" + NewUpgradeNumber;
            Detail.text = "   " + NewDetail;

            if(NowWeapon.ItemWeapon.NumberAmount >= 0)
            {
                ButtonCraft.text = Text_Upgrade;
            }
            else{
                ButtonCraft.text = Text_Craft;
            }

            if(NowWeapon.ItemWeapon.IsUse)
            {
                ButtonUse.text = Text_UnEquip;
            }
            else{
                ButtonUse.text = Text_Equip;
            }

        }

        else 
        {
            Icon.color = Color.black;

            MainName.text = "???????";
            Period.text = "?? ???";
            Icon.sprite = inventorySlotWeapon.ItemWeapon.Icon;
            if(NowWeapon.ItemWeapon.Sword) Damage.text = "Damage : #*&$^*";
            else Damage.text = "Strength : #*&$^*";
            Upgrade.text = "-99";
            Detail.text = "   " + "??????????????????????????????????????????????????????????????????????????????";

            ButtonCraft.text = "Craft";
            ButtonUse.text = "---";
            
        }
    }

    public void SendVariableToEquipmentSystem()
    {
        if(NowWeapon.ItemWeapon.EverHave)
        {
            if(NowWeapon.ItemWeapon.Sword)
            {
                if (NowWeapon.ItemWeapon.IsUse)
                {
                    if (equipmentSystem.KeepIDWeapon[0] == NowWeapon.ItemWeapon.ID) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 0);
                    else if(equipmentSystem.KeepIDWeapon[1] == NowWeapon.ItemWeapon.ID) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 1);
                }
                else
                {
                    ButtonMainS.SetActive(true);
                    ButtonSubS.SetActive(true);
                    ButtonUsee.SetActive(false);
                }
            }
            else if(NowWeapon.ItemWeapon.Hat) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 2);
            else if(NowWeapon.ItemWeapon.Shirt) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 3);
            else if(NowWeapon.ItemWeapon.Pant) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 4);
            else if(NowWeapon.ItemWeapon.Shoe) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 5);

            UpdateAuto();
        }
    }

    public void SendVariableToEquipmentSystem_Sword(bool IsMain)
    {
        if (NowWeapon.ItemWeapon.EverHave)
        {

            

            if (IsMain) equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 0);
            else equipmentSystem.UpdateSlotFronUseButton(NowWeapon.ItemWeapon.ID, 1);


            

            UpdateAuto();
        }
        ButtonMainS.SetActive(false);
        ButtonSubS.SetActive(false);
        ButtonUsee.SetActive(true);
    }


}
