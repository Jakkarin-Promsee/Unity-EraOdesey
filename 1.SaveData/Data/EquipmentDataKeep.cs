using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class EquipmentDataKeep
{
    [SerializeField] public int ID = -1;
    [SerializeField] public string TypeInventory = "";

    public void SaveNewData(InventorySlotUI ui)
    {
        ID = ui.ID;
        TypeInventory = ui.TypeInventory;
    }

    public void NewData()
    {
        ID = -1;
        TypeInventory = "";

    }
}
