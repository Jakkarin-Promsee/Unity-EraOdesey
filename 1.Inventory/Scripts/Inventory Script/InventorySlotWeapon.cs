using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlotWeapon
{
    [SerializeField] private InventoryWeaponData itemWeapon;
    //[SerializeField] [TextArea(2,4)] private string Description;
    [SerializeField] public bool IsUse = false;
    [SerializeField] public bool Activate = false;
    [SerializeField] public bool EverHave = false;
    [SerializeField] private int id = 0;
    [SerializeField] private double numberAmount = 0;
    [SerializeField] private long multiplierAmount = 0;

    public InventoryWeaponData ItemWeapon => itemWeapon;

    public void LoadData(WeaponDataKeep data)
    {
        itemWeapon.IsUse = data.IsUse;
        itemWeapon.EverHave = data.EverHave;
        itemWeapon.Activate = data.Activate;
        itemWeapon.NumberAmount = data.NumberAmount;
        itemWeapon.MultiplierAmount = data.MultiplierAmount;
    }

    public void ClearSlot()
    {
        itemWeapon.IsUse = false;
        IsUse = itemWeapon.IsUse;

        id = itemWeapon.ID;

        itemWeapon.NumberAmount = -1;
        itemWeapon.MultiplierAmount = 0;

        itemWeapon.EverHave = false;
        EverHave = itemWeapon.EverHave;

        itemWeapon.Activate = false;
        Activate = itemWeapon.Activate;

        numberAmount = itemWeapon.NumberAmount;
        multiplierAmount = itemWeapon.MultiplierAmount;

    }

    public void UpdateShowData()
    {
        Activate = itemWeapon.Activate;
        id = itemWeapon.ID;
        numberAmount = itemWeapon.NumberAmount;
        multiplierAmount = itemWeapon.MultiplierAmount;
    }

    public void AddItem(double numberAmountToAdd, long multiplierAmountToAdd)
    {
        if(!Activate)
        {
            itemWeapon.Activate = true;
            ClearSlot();
        }

        if(!EverHave) 
        {
            itemWeapon.EverHave = true;
            UpdateShowData();
        }

        SumAmountMultiplyPattern(itemWeapon.NumberAmount, itemWeapon.MultiplierAmount, numberAmountToAdd, multiplierAmountToAdd,
                                out double nnum , out long nmul);
                                
        itemWeapon.NumberAmount = nnum;
        itemWeapon.MultiplierAmount = nmul;
        UpdateShowData();
    }

    public void RemoveItem(double numberAmountToAdd, long multiplierAmountToAdd)
    {
        numberAmountToAdd *= -1;
        SumAmountMultiplyPattern(itemWeapon.NumberAmount, itemWeapon.MultiplierAmount, numberAmountToAdd, multiplierAmountToAdd,
                                out double nnum , out long nmul);

        itemWeapon.NumberAmount = nnum;
        itemWeapon.MultiplierAmount = nmul;

        UpdateShowData();
    }

    private void SumAmountMultiplyPattern(double number1, long multiplier1, double number2, long multiplier2, out double newnewnumber, out long newnewmultiplier)
    {
        bool CheckNumber = Mathf.Abs(multiplier1 - multiplier2) <=3;
        
        double newnumber = 0;
        long newmutiplier = 0;

        if(CheckNumber){
            if(multiplier1==multiplier2){
                newnumber = number1 + number2;
                newmutiplier = multiplier1;
            }

            else if(multiplier1 < multiplier2)
            {
                newnumber = number2  + number1 / Mathf.Pow(1000, Mathf.Abs(multiplier1 - multiplier2));
                newmutiplier = multiplier2;
            }

            else if(multiplier1 > multiplier2)
            {
                newnumber = number1  + number2 / Mathf.Pow(1000, Mathf.Abs(multiplier1 - multiplier2));
                newmutiplier = multiplier1;
            }
        }

        else{
            if(number1 > number2) newnumber = number1;
            else newnumber = number2;
            
            if(multiplier1 > multiplier2) newmutiplier = multiplier1;
            else newmutiplier = multiplier2;
        }

        ConvertNumberToMutiplyPattern(newnumber, newmutiplier, out newnewnumber, out newnewmultiplier);
        UpdateShowData();
    }


    public void GetDamage(out double newnewnumber, out long newnewmultiplier)
    {
        double multiplier;
        if (itemWeapon.MultiplierAmount <= 3) multiplier = 1/Mathf.Pow(1000,itemWeapon.MultiplierAmount) + itemWeapon.NumberAmount*0.2;
        else multiplier = itemWeapon.NumberAmount*0.2;

        double newnumber = itemWeapon.AmountDamage * multiplier;
        long newmutiplier = itemWeapon.MultiplierDamage + itemWeapon.MultiplierAmount;
        Debug.Log("B ---> " + newnumber + " " + newmutiplier);
        //ConvertNumberToMutiplyPattern(newnumber, newmutiplier, out newnewnumber, out newnewmultiplier);
        ConvertNumberToMutiplyPattern(newnumber, newmutiplier, out newnewnumber, out newnewmultiplier);
        Debug.Log(newnumber + " " + newmutiplier);
        UpdateShowData();

        Debug.Log("A ---> " + newnewnumber + " " + newnewmultiplier);
    }

    public void GetMaterialUse(out double Multiplier)
    {
        if (itemWeapon.MultiplierAmount <= 3) Multiplier = 1 / Mathf.Pow(1000, itemWeapon.MultiplierAmount) + (itemWeapon.NumberAmount-1) * 0.5;
        else Multiplier = itemWeapon.NumberAmount * 0.5;
    }


    public void ConvertNumberToMutiplyPattern(double number, long multiplier, out double newnumber, out long newmutiplier)
    {
        double multiplierValue = 1e3;
        if (number > multiplierValue)
        {
            double mp = 1;
            long mmp = multiplier;

            while (number / mp > multiplierValue)
            {
                mp *= multiplierValue;
                mmp++;
            }

            newnumber = number / mp;
            newmutiplier = mmp;
        }
        else if (number < 1)
        {
            double mp = 1;

            while (number * mp < 0)
            {
                mp *= multiplierValue;
            }

            newnumber = number * mp;
            newmutiplier = (long)(multiplier - mp);
        }
        else
        {
            newnumber = number;
            newmutiplier = multiplier;
        }
    }
    
    public bool ReturnAmountToLong(out long number)
    {
        if(itemWeapon.MultiplierAmount<=0)
        {
            number = (long)(itemWeapon.NumberAmount*Mathf.Pow(1000,itemWeapon.MultiplierAmount));
            return true;
        }
        else{
            number = 0;
            return false;
        }
    }

    public bool ReturnDamageToLong(out long number)
    {
        if(itemWeapon.MultiplierDamage<=0)
        {
            number = (long)(itemWeapon.AmountDamage*Mathf.Pow(1000,itemWeapon.MultiplierDamage));
            return true;
        }
        else{
            number = 0;
            return false;
        }
    }
}
