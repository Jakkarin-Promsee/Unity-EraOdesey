using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialDataKeep
{
    [SerializeField] public bool EverHave = false;
    [SerializeField] public bool Activate = false;
    [SerializeField] public double NumberAmount = 0;
    [SerializeField] public long MultiplierAmount = 0;

    public void SaveNewData(InventorySlotMaterial materialData)
    {
        EverHave = materialData.ItemMaterial.EverHave;
        Activate = materialData.ItemMaterial.Activate;
        NumberAmount = materialData.ItemMaterial.NumberAmount;
        MultiplierAmount = materialData.ItemMaterial.MultiplierAmount;
    }

    public void NewData()
    {
        EverHave = false;
        Activate = false;
        NumberAmount = 0;
        MultiplierAmount = 0;

    }
}
