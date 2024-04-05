using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponDataKeep
{
    [SerializeField] public bool IsUse = false;
    [SerializeField] public bool EverHave = false;
    [SerializeField] public bool Activate = false;
    [SerializeField] public double NumberAmount = 0;
    [SerializeField] public long MultiplierAmount = 0;

    public void SaveNewData(InventorySlotWeapon weaponData)
    {
        IsUse = weaponData.ItemWeapon.IsUse;
        EverHave = weaponData.ItemWeapon.EverHave;
        Activate = weaponData.ItemWeapon.Activate;
        NumberAmount = weaponData.ItemWeapon.NumberAmount;
        MultiplierAmount = weaponData.ItemWeapon.MultiplierAmount;
    }

    public void NewData()
    {
        IsUse = false;
        EverHave = false;
        Activate = false;
        NumberAmount = 0;
        MultiplierAmount = 0;

    }
}
