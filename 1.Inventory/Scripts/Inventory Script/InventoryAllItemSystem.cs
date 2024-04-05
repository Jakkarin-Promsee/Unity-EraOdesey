using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventoryAllItemSystem
{
    [SerializeField] public GameObject LockSkill;
    
    [Header("PlayerMainController")]
    // PlayerMainController are control about player and enemy fighting. Therefore i must co
    [SerializeField] public PlayerMainController playerMainController;
    [SerializeField] public DisplayControl displayControl;

    [Header("Combat System")]
    // For activate Ui 
    [SerializeField] public GameObject BossFightButton;

    [Header("Main Canva")]
    //For Main Canva to activate function.
    [SerializeField] public GameObject InventoryPanel;
    [SerializeField] public GameObject SkillSLot;
    [SerializeField] public GameObject InformationPanel;
    [SerializeField] public GameObject LoadingPanel;
    [SerializeField] public GameObject PeriodPanel;
    [SerializeField] public GameObject Book;

    [Header("Book Of Era")]
    [SerializeField] public GameObject BookSelectPanel;
    [SerializeField] public SelectCH BookSelectControl;
    [SerializeField] public GameObject BookReadPanel;
    [SerializeField] public ReadBook BookReadControl;
    [SerializeField] public GameObject SelectFightPanel;
    [SerializeField] public GameObject MinigamePanel;
    [SerializeField] public GameObject EndGamePanel;

    [Header("Sub Canva")]
    //For Sub Canva of Inventory Panel For activate funtion.
    [SerializeField] public GameObject EquipmentSubPanel;
    [SerializeField] public GameObject CraftSubPanel;
    [SerializeField] public GameObject InventorySubPanel;
    [SerializeField] public GameObject Skillpanel;
    [SerializeField] public PopUPSkill popUPSkill;
    [SerializeField] public GameObject SkillPopUP;
    [SerializeField] public PopUPSkill popUPInformationForSkill;

    [Header("Popup Information")]
    //For Sub Canva Of Information Panel For activate funtion.
    [SerializeField] public GameObject PopUPWeapon;
    [SerializeField] public PopUPInformationForWeapon popUPInformationForWeapon;
    [SerializeField] public GameObject PopUPMateril;
    [SerializeField] public PopUPInformationForMaterial popUPInformationForMaterial;
    [SerializeField] public GameObject PopUPCraft;
    [SerializeField] public PopUPInformationForCraft popUPInformationForCraft;
    
    //For make list to keep items
    [SerializeField] private List<InventorySlotMaterial> inventorySlotMaterials;
    public List<InventorySlotMaterial> InventorySlotMaterials => inventorySlotMaterials;

    [SerializeField] private List<InventorySlotWeapon> inventorySlotWeapons;
    public List<InventorySlotWeapon> InventorySlotWeapons => inventorySlotWeapons;

    //For Use to Update Data in display
    [SerializeField] public EquipmentSystem equipmentSystem;
    [SerializeField] private SuppostDisplayHolder[] suppostDisplayHolders;
    public SuppostDisplayHolder[] SuppostDisplayHolders => suppostDisplayHolders;

    //Update Popup ever popup in information panel from keep data in fuction.
    public void UpdateAllPopUP()
    {
        popUPInformationForMaterial.UpdateAuto();
        popUPInformationForWeapon.UpdateAuto();
        popUPInformationForCraft.UpdateAuto();
    }

    //Change setting in DisplyHolder according to InventorySystem For convenience to use.
    public void ChangeTypeSHowItemFromSuppostHoldeer_AtAllSystem()
    {
        for(int i=0; i< suppostDisplayHolders.Length; i++){
            suppostDisplayHolders[i].ChangeTypeSHowItemFromSuppostHolder();
        }
    }

    public void ChangeLanguagePopUPToDefault()
    {
        popUPInformationForSkill.ChangeLanguageToDefault();
        popUPInformationForMaterial.ChangeLanguageToDefault();
        popUPInformationForWeapon.ChangeLanguageToDefault();
        popUPInformationForCraft.ChangeLanguageToDefault();
    }

    public void ChangeLanguagePopUPToEnglish()
    {
        popUPInformationForSkill.ChangeLanguageToEnglish();
        popUPInformationForMaterial.ChangeLanguageToEnglish();
        popUPInformationForWeapon.ChangeLanguageToEnglish();
        popUPInformationForCraft.ChangeLanguageToEnglish();
    }

    public void ChangeLanguagePopUPToThai()
    {
        popUPInformationForSkill.ChangeLanguageToThai();
        popUPInformationForMaterial.ChangeLanguageToThai();
        popUPInformationForWeapon.ChangeLanguageToThai();
        popUPInformationForCraft.ChangeLanguageToThai();
    }

    public void ChangeLanguageToDefault()
    {
        for(int i=0; i<inventorySlotMaterials.Count; i++)
        {
            inventorySlotMaterials[i].ItemMaterial.Name = "Error";
            inventorySlotMaterials[i].ItemMaterial.Period = "Error";
            inventorySlotMaterials[i].ItemMaterial.Detail = "Error Error Error Error Error Error Error Error Error Error";
        }

        for(int i=0; i<inventorySlotWeapons.Count; i++)
        {
            inventorySlotWeapons[i].ItemWeapon.Name = "Error";
            inventorySlotWeapons[i].ItemWeapon.Period = "Error";
            inventorySlotWeapons[i].ItemWeapon.Detail = "Error Error Error Error Error Error Error Error Error Error";
        }
    }

    public void ChangeLanguageToThai()
    {
        for(int i=0; i<inventorySlotMaterials.Count; i++)
        {
            inventorySlotMaterials[i].ItemMaterial.Name = inventorySlotMaterials[i].ItemMaterial.Thai_name;
            inventorySlotMaterials[i].ItemMaterial.Period = inventorySlotMaterials[i].ItemMaterial.Thai_period;
            inventorySlotMaterials[i].ItemMaterial.Detail = inventorySlotMaterials[i].ItemMaterial.Thai_Detail;
        }

        for(int i=0; i<inventorySlotWeapons.Count; i++)
        {
            inventorySlotWeapons[i].ItemWeapon.Name = inventorySlotWeapons[i].ItemWeapon.Thai_name;
            inventorySlotWeapons[i].ItemWeapon.Period = inventorySlotWeapons[i].ItemWeapon.Thai_period;
            inventorySlotWeapons[i].ItemWeapon.Detail = inventorySlotWeapons[i].ItemWeapon.Thai_Detail;
        }
    }

    public void ChangeLanguageToEnglish()
    {
        for(int i=0; i<inventorySlotMaterials.Count; i++)
        {
            inventorySlotMaterials[i].ItemMaterial.Name = inventorySlotMaterials[i].ItemMaterial.English_name;
            inventorySlotMaterials[i].ItemMaterial.Period = inventorySlotMaterials[i].ItemMaterial.English_period;
            inventorySlotMaterials[i].ItemMaterial.Detail = inventorySlotMaterials[i].ItemMaterial.English_Detail;
        }

        for(int i=0; i<inventorySlotWeapons.Count; i++)
        {
            inventorySlotWeapons[i].ItemWeapon.Name = inventorySlotWeapons[i].ItemWeapon.English_name;
            inventorySlotWeapons[i].ItemWeapon.Period = inventorySlotWeapons[i].ItemWeapon.English_period;
            inventorySlotWeapons[i].ItemWeapon.Detail = inventorySlotWeapons[i].ItemWeapon.English_Detail;
        }
    }
    
    //The Main Add function. I will be used by item when object tricker.
    public bool AddToInventoryMaterial(InventoryMaterialData sourse, double numberAmountToAdd, long multiplierAmountToAdd)
    {
        inventorySlotMaterials[sourse.ID].AddItem(numberAmountToAdd, multiplierAmountToAdd);
        
        UpdateDisplaySlot();
        return true;
        
    }

    //The Main remove function. Now this function isn't use, But it may benefit to remove item.
    public bool RemoveToInventoryMaterial(InventoryMaterialData sourse, double numberAmountToAdd, long multiplierAmountToAdd)
    {
        inventorySlotMaterials[sourse.ID].RemoveItem(numberAmountToAdd, multiplierAmountToAdd);

        UpdateDisplaySlot();
        return true;
    }

    //Function to call Add item fucntion. It used to add item for weapon.
    public bool AddToInventoryWeapon(InventoryWeaponData sourse, double numberAmountToAdd, long multiplierAmountToAdd)
    {
        inventorySlotWeapons[sourse.ID].AddItem(numberAmountToAdd, multiplierAmountToAdd);

        UpdateDisplaySlot();
        return true;
    }

    //Function to call remove item fucntion. It used to remove item for weapon.
    public bool RemoveToInventoryWeapon(InventoryWeaponData sourse, double numberAmountToAdd, long multiplierAmountToAdd)
    {
        inventorySlotWeapons[sourse.ID].RemoveItem(numberAmountToAdd, multiplierAmountToAdd);

        UpdateDisplaySlot();
        return true;
    }

    public void GetCraftWeapon(InventorySlotWeapon inventorySlotWeapon, out double Material1Number, out long Material1Multiplier, out double Material2Number, out long Material2Multiplier)
    {
        double multiplier;
        inventorySlotWeapon.GetMaterialUse(out multiplier);

        double Number1 = inventorySlotWeapon.ItemWeapon.NumberAmountItemUsed1 * multiplier;
        long Multiplier1 = inventorySlotWeapon.ItemWeapon.MultiplierAmountItemUsed1;

        double Number2 = inventorySlotWeapon.ItemWeapon.NumberAmountItemUsed2 * multiplier;
        long Multiplier2 = inventorySlotWeapon.ItemWeapon.MultiplierAmountItemUsed2;


        inventorySlotWeapon.ConvertNumberToMutiplyPattern(Number1, Multiplier1, out Material1Number, out Material1Multiplier);
        inventorySlotWeapon.ConvertNumberToMutiplyPattern(Number2, Multiplier2, out Material2Number, out Material2Multiplier);

        Material1Number = (long)Material1Number;
        Material2Number = (long)Material2Number;
    }

    //Fuction to creaft weapon by use add and remove function.
    public bool CraftWeapon(InventorySlotWeapon MainSourse)
    {
        InventoryWeaponData Sourse = MainSourse.ItemWeapon;
        InventorySlotWeapon MainItem = InventorySlotWeapons[Sourse.ID];
        InventorySlotMaterial MaterialItemUsed1 = InventorySlotMaterials[Sourse.IDItemUsed1];
        InventorySlotMaterial MaterialItemUsed2 = InventorySlotMaterials[Sourse.IDItemUsed2];

        double AmountItemHave1Number = MaterialItemUsed1.ItemMaterial.NumberAmount;
        long AmountItemHave1Multiplier = MaterialItemUsed1.ItemMaterial.MultiplierAmount;

        double AmountItemHave2Number = MaterialItemUsed2.ItemMaterial.NumberAmount;
        long AmountItemHave2Multiplier = MaterialItemUsed2.ItemMaterial.MultiplierAmount;

        double AmountItemUsed1Number;
        long AmountItemUsed1Multuplier;

        double AmountItemUsed2Number;
        long AmountItemUsed2Multuplier;

        GetCraftWeapon(MainSourse, out AmountItemUsed1Number, out AmountItemUsed1Multuplier, out AmountItemUsed2Number, out AmountItemUsed2Multuplier);

        bool ItemUsed1IsEnough = (AmountItemHave1Number>=AmountItemUsed1Number) || (AmountItemHave1Multiplier>AmountItemUsed1Multuplier);
        bool ItemUsed2IsEnough = (AmountItemHave2Number>=AmountItemUsed2Number) || (AmountItemHave2Multiplier>AmountItemUsed2Multuplier);

        if(ItemUsed1IsEnough && ItemUsed2IsEnough)
        {
            MainItem.AddItem(1, 0);
            MaterialItemUsed1.RemoveItem(AmountItemUsed1Number ,AmountItemUsed1Multuplier);
            MaterialItemUsed2.RemoveItem(AmountItemUsed2Number ,AmountItemUsed2Multuplier);

            UpdateDisplaySlot();
            return true;
        }

        UpdateDisplaySlot();
        return false;
    }

    //fuction to convert number for improve number in display.
    public void ConvertNumberToMutiplyPattern(double number, long multiplier, out double newnumber, out long newmutiplier)
    {
        long multiplierValue = 1000;
        if(number>multiplierValue)
        { 
            long DifferentMultiply = (long)(number/multiplierValue);
            newnumber = number/DifferentMultiply;
            newmutiplier = multiplier+DifferentMultiply;
        }
        else if(number<1)
        {
            long mp = 1;
            
            while(number*mp<0)
            {
                mp*=multiplierValue;
            }

            newnumber = number*mp;
            newmutiplier = multiplier-mp;
        }
        else{
            newnumber = number;
            newmutiplier = multiplier;
        }
    }

    /*
    public bool ConvertNumberToLongPattern(double number, long multiplier, out long amount)
    {
        
    }
    */

    //Clear every slot for delete some slot that have old data
    public void ClearAllSlot()
    {
        for(int i=0; i<inventorySlotMaterials.Count; i++)
        {
            inventorySlotMaterials[i].ClearSlot();
        }
        for(int i=0; i<inventorySlotWeapons.Count; i++)
        {
            inventorySlotWeapons[i].ClearSlot();
        }
    }

    //Update all Display slot it will called funtion in staticDisplay.
    public void UpdateDisplaySlot()
    {
        for(int i=0; i<suppostDisplayHolders.Length; i++)
        {
            suppostDisplayHolders[i].staticDisplayHolder.staticDisplay.UpdateSlot();
        }
    }

    //fuction to Activate weapon. When weapon was activated, This weapon will show in inventory slot.
    public void ActivateWeapon(int min, int max)
    {
        for(int i=min; i<max; i++)
        {
            inventorySlotWeapons[i].ItemWeapon.Activate = true;
            inventorySlotWeapons[i].UpdateShowData();
        }
    }

    public void EverHaveWeapon(int min, int max)
    {
        for(int i=min; i<max; i++)
        {
            inventorySlotWeapons[i].ItemWeapon.EverHave = true;
            inventorySlotWeapons[i].UpdateShowData();
        }
    }

    public void GetWeapon(int min, int max, double number, long multiplier)
    {
        for(int i=min; i<max; i++)
        {
            inventorySlotWeapons[i].AddItem(number, multiplier);
        }
    }

    //fuction to Activate Material. When weapon was activated, This Material will show in inventory slot.
    public void ActivateMaterial(int min, int max)
    {
        for(int i=min; i<max; i++)
        {
            inventorySlotMaterials[i].ItemMaterial.Activate = true;
            inventorySlotMaterials[i].UpdateShowData();
        }
    }

    public void EverHaveMaterial(int min, int max)
    {
        for(int i=min; i<max; i++)
        {
            inventorySlotMaterials[i].ItemMaterial.EverHave = true;
            inventorySlotMaterials[i].UpdateShowData();
        }
    }

    public void GetMaterial(int min, int max, double number, long multiplier)
    {
        for(int i=min; i<max; i++)
        {
            inventorySlotMaterials[i].AddItem(number, multiplier);
        }
    }

}
