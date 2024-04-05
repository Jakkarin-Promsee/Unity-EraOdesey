using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlotMaterial
{
    [SerializeField] private InventoryMaterialData itemMaterial;
    //[SerializeField] [TextArea(2,4)] private string Description;
    [SerializeField] public bool IsShow = false;
    [SerializeField] public bool EverHave = false;
    [SerializeField] public bool Activate = false;
    [SerializeField] private int id = -1;
    [SerializeField] public double numberAmount = 0;
    [SerializeField] public long multiplierAmount = 0;

    public InventoryMaterialData ItemMaterial => itemMaterial; //make varialbe that can call from other script
    
    public void LoadData(MaterialDataKeep data)
    {
        itemMaterial.EverHave = data.EverHave;
        itemMaterial.Activate = data.Activate;
        itemMaterial.NumberAmount = data.NumberAmount;
        itemMaterial.MultiplierAmount = data.MultiplierAmount;
    }

    public void ClearSlot()
    {
        id = itemMaterial.ID;

        itemMaterial.NumberAmount = 0f;
        itemMaterial.MultiplierAmount = 0;

        numberAmount = itemMaterial.NumberAmount;
        multiplierAmount = itemMaterial.MultiplierAmount;

        itemMaterial.EverHave = false;
        EverHave = itemMaterial.EverHave;

        itemMaterial.Activate = false;
        Activate = itemMaterial.Activate;
    
    }

    public void UpdateShowData()
    {
        Activate = itemMaterial.Activate;
        id = itemMaterial.ID;
        numberAmount = itemMaterial.NumberAmount;
        multiplierAmount = itemMaterial.MultiplierAmount;
    }

    public void AddItem(double numberAmountToAdd, long multiplierAmountToAdd)
    {
        if(!Activate)
        {
            itemMaterial.Activate = true;
            ClearSlot();
        }

        if(!EverHave) 
        {
            itemMaterial.EverHave = true;
            UpdateShowData();
        }
   
        SumAmountMultiplyPattern(itemMaterial.NumberAmount, itemMaterial.MultiplierAmount, numberAmountToAdd, multiplierAmountToAdd,
                                out double nnum , out long nmul);
                                
        itemMaterial.NumberAmount = nnum;
        itemMaterial.MultiplierAmount = nmul;
        UpdateShowData();
        
    }

    public void RemoveItem(double numberAmountToAdd, long multiplierAmountToAdd)
    {
        numberAmountToAdd *= -1;
        SumAmountMultiplyPattern(itemMaterial.NumberAmount, itemMaterial.MultiplierAmount, numberAmountToAdd, multiplierAmountToAdd,
                                out double nnum , out long nmul);

        itemMaterial.NumberAmount = nnum;
        itemMaterial.MultiplierAmount = nmul;

        numberAmount = itemMaterial.NumberAmount;
        multiplierAmount = itemMaterial.MultiplierAmount;
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
    }

    public void ConvertNumberToMutiplyPattern(double number, long multiplier, out double newnumber, out long newmutiplier)
    {
        long multiplierValue = 1000;

        if(number>=multiplierValue)
        { 
            long DifferentMultiply = (long)(number/multiplierValue);
            newnumber = number/multiplierValue;
            newmutiplier = multiplier+DifferentMultiply;
        }
        else if(number<1)
        {
            long mp = 1;
            
            while(number*Mathf.Pow(1000, mp)<0)
            {
                mp++;
            }

            newnumber = number*Mathf.Pow(1000, mp);
            newmutiplier = multiplier-mp;
        }
        else{
            newnumber = number;
            newmutiplier = multiplier;
        }
        UpdateShowData();
    }

    public bool ReturnAmountToLong(out long number)
    {
        if(itemMaterial.MultiplierAmount<=0)
        {
            number = (long)(itemMaterial.NumberAmount*Mathf.Pow(1000,itemMaterial.MultiplierAmount));
            return true;
        }
        else{
            number = 0;
            return false;
        }
    }
}
