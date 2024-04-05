using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUPInformationForCraft : MonoBehaviour
{
    public InventoryAllHolder inventoryAllHolder;
    private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    public Image LowerBackGround;
    public Image BackGround;
    public Image BackGroundIcon;
    public Image IconWeapon;
    public Image IconMaterial1;
    public Image IconMaterial2;

    public TMP_Text MainName;
    public TMP_Text Period;
    public TMP_Text Damage;
    public TMP_Text Upgrade;

    public TMP_Text NameMaterial1;
    public TMP_Text NameMaterial2;
    public TMP_Text Amount1;
    public TMP_Text Amount2;

    public Button ButtonUpgrade;
    public TMP_Text ButtonText;

    Image DefultLowerBackGround;
    Image DefultBackGround;
    Image DefultBackGroundIcon;
    Image DefultIconWeapon;
    Image DefultIconMaterial1;
    Image DefultIconMaterial2;


    InventorySlotWeapon NowWeapon;

    private void Start() {
        DefultLowerBackGround = LowerBackGround;
        DefultBackGround = BackGround;
        DefultBackGroundIcon = BackGroundIcon;
        DefultIconWeapon = IconWeapon;
        DefultIconMaterial1 = IconMaterial1;
        DefultIconMaterial2 = IconMaterial2;
        ClearPanel();
    }

    InventorySlotWeapon KinventorySlotWeapon = null;
    InventorySlotMaterial KinventorySlotMaterial1 = null;
    InventorySlotMaterial KinventorySlotMaterial2 = null;

    string Text_Damage;
    string Text_Strength;
    string Text_Upgrade;
    string Text_Craft;
    string Text_Equip;
    string Text_UnEquip;

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

    public void UpdateAuto()
    {
        if(KinventorySlotWeapon != null && KinventorySlotMaterial1 != null && KinventorySlotMaterial2 != null)
        UpdatePanel(KinventorySlotWeapon, KinventorySlotMaterial1, KinventorySlotMaterial2);
    }

    public void UpdatePanel(InventorySlotWeapon inventorySlotWeapon, InventorySlotMaterial inventorySlotMaterial1, InventorySlotMaterial inventorySlotMaterial2)
    {
        KinventorySlotMaterial1 = inventorySlotMaterial1;
        KinventorySlotMaterial2 = inventorySlotMaterial2;

        double N1, N2;
        long M1, M2;

        inventoryAllHolder.InventoryAllItemSystem.GetCraftWeapon(inventorySlotWeapon, out N1, out M1, out N2, out M2);
        
        NowWeapon = inventorySlotWeapon;
        KinventorySlotWeapon = NowWeapon;
        ClearPanel();

        int NewID = NowWeapon.ItemWeapon.ID;

        Sprite NewIconWeapon = NowWeapon.ItemWeapon.Icon;
        Sprite NewIconMaterial1 = inventorySlotMaterial1.ItemMaterial.Icon;
        Sprite NewIconMaterial2 = inventorySlotMaterial2.ItemMaterial.Icon;

        string NewMainName = NowWeapon.ItemWeapon.Name;
        string NewPeriod = NowWeapon.ItemWeapon.Period;
        string NewDetail = NowWeapon.ItemWeapon.Detail;

        string NewDamageNumber = "";
        string NewUpgradeNumber = "";
    
        MainName.text = NewMainName;
        Period.text = NewPeriod;

        IconWeapon.sprite = NewIconWeapon;
        IconMaterial1.sprite = NewIconMaterial1;
        IconMaterial2.sprite = NewIconMaterial2;

        inventorySlotWeapon.GetDamage(out double NDamage, out long MDamage);

        string NewNameMaterial1 = inventorySlotMaterial1.ItemMaterial.Name;
        string NewNameMaterial2 = inventorySlotMaterial2.ItemMaterial.Name;

        if (MDamage == 0)
        {
            NewDamageNumber = NDamage.ToString("F0");
        }
        else
        {
            if (NDamage < 10) NewDamageNumber = (NDamage * Mathf.Pow(1000, 1)).ToString("F0") + multiple[MDamage-1];
            else NewDamageNumber = NDamage.ToString("F2") + multiple[MDamage];
        }

        if (NowWeapon.ReturnAmountToLong(out long amountNumberUpgrade))
            {
                NewUpgradeNumber = amountNumberUpgrade.ToString();
            }
            else{
                NewUpgradeNumber = NowWeapon.ItemWeapon.NumberAmount.ToString("F2") + multiple[NowWeapon.ItemWeapon.MultiplierAmount];
            }

            string NewAmount1 = "";

            if(inventorySlotMaterial1.ReturnAmountToLong(out long amountNumber1))
            {
                NewAmount1 = amountNumber1.ToString();
            }
            else{
                NewAmount1 = inventorySlotMaterial1.ItemMaterial.NumberAmount.ToString("F2")  +  multiple[inventorySlotMaterial1.ItemMaterial.MultiplierAmount];
            }

            string NewAmount2 = "";

            if(inventorySlotMaterial2.ReturnAmountToLong(out long amountNumber2))
            {
                NewAmount2 = amountNumber2.ToString();
            }
            else{
                NewAmount2 = inventorySlotMaterial2.ItemMaterial.NumberAmount.ToString("F2")  +  multiple[inventorySlotMaterial2.ItemMaterial.MultiplierAmount];
            }

        if(NowWeapon.ItemWeapon.EverHave) 
        {
            MainName.text = NewMainName;
            Period.text = NewPeriod;
            IconWeapon.color = Color.white;
            if(NowWeapon.ItemWeapon.Sword) Damage.text = Text_Damage + NewDamageNumber;
            else Damage.text = Text_Strength + NewDamageNumber;
            Upgrade.text = "+" + NewUpgradeNumber;
            ButtonText.text = Text_Upgrade;
        }
        else 
        {
            MainName.text = "???????";
            Period.text = "?? ???";
            IconWeapon.color = Color.black;
            if(NowWeapon.ItemWeapon.Sword) Damage.text = Text_Damage + "#*&$^*";
            else Damage.text = Text_Craft + "#*&$^*";
            Upgrade.text = "";
            ButtonText.text = Text_Craft;
        }

        if(inventorySlotMaterial1.ItemMaterial.EverHave) 
        {
            IconMaterial1.color = Color.white;
            NameMaterial1.text = NewNameMaterial1;
            Amount1.text = NewAmount1;
        }
        else 
        {
            IconMaterial1.color = Color.black;
            NameMaterial1.text = "???";
            Amount1.text = "0";
        }

        if(inventorySlotMaterial2.ItemMaterial.EverHave) 
        {
            IconMaterial2.color = Color.white;
            NameMaterial2.text = NewNameMaterial2;
            Amount2.text = NewAmount2;
        }
        else 
        {
            IconMaterial2.color = Color.black;
            NameMaterial2.text = "???";
            Amount2.text = "0";
        }

        Amount1.text = NewAmount1 + " / " + N1.ToString() + multiple[M1];
        Amount2.text  = NewAmount2 + " / " + N2.ToString() + multiple[M2];

    }

    public void ClearPanel()
    {
        MainName.text = "Error 154";

        LowerBackGround = DefultBackGround;
        BackGround = DefultBackGround;
        DefultBackGroundIcon = BackGroundIcon;

        IconWeapon = DefultIconWeapon;
        IconWeapon.color = Color.white;
        IconWeapon.sprite = null;

        IconMaterial1 = DefultIconMaterial1;
        IconMaterial1.color = Color.white;
        IconMaterial1.sprite = null;

        IconMaterial2 = DefultIconMaterial2;
        IconMaterial2.color = Color.white;
        IconMaterial2.sprite = null;

        BackGroundIcon.sprite = null;

        Damage.text = "!#$*@ : 99";
        Upgrade.text = "+99";

        Amount1.text = "99/0";
        Amount2.text = "99/0";
    }

    public void CraftItem()
    {
        inventoryAllHolder.InventoryAllItemSystem.CraftWeapon(NowWeapon);
        inventoryAllHolder.InventoryAllItemSystem.equipmentSystem.UpdateSlot();
        UpdateAuto();
    }

    public void OpenMaterial1()
    {
        inventoryAllHolder.InventoryAllItemSystem.PopUPMateril.SetActive(true);
        inventoryAllHolder.InventoryAllItemSystem.popUPInformationForMaterial.UpdatePanel(KinventorySlotMaterial1);
    }

    public void OpenMaterial2()
    {
        inventoryAllHolder.InventoryAllItemSystem.PopUPMateril.SetActive(true);
        inventoryAllHolder.InventoryAllItemSystem.popUPInformationForMaterial.UpdatePanel(KinventorySlotMaterial2);
    }


}
