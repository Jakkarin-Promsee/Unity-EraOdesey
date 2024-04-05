using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class StaticDisplay
{
    
    [SerializeField] [TextArea(2,4)] public string Description;
    [SerializeField] protected InventoryAllHolder inventoryAllHolder;
    [SerializeField] private InventorySlotUI[] inventorySlotUI;

    
    public InventoryAllHolder InventoryAllHolder => inventoryAllHolder;
    
    InventoryAllItemSystem InventoryAllItemSystem => InventoryAllHolder.InventoryAllItemSystem;

    public List<InventorySlotMaterial> SlotMaterial => InventoryAllItemSystem.InventorySlotMaterials;
    public List<InventorySlotWeapon> SlotWeapon => InventoryAllItemSystem.InventorySlotWeapons;

    public bool ShowCountNumberLong;
    public bool CountFromMoreToLess;

    public bool IsMaterial, IsWeapon;
    public bool 
    IsSword = false,
     IsHat = false,
      IsShirt = false ,
       IsPant = false,
        IsShoe = false;

    string TypeWeapon = "Weapon";
    string TypeMaterial = "Material";

    public int SlotRun_position = 0;

    int nowi;

    public void CheckInventorySlotUIOnClick()
    {
        for(int i=0; i<inventorySlotUI.Length; i++)
        {
            if(inventorySlotUI[i].IsClick) 
            {
                inventorySlotUI[i].IsClick = false;
                OpenPopUpInformation(i);
                nowi = i;
            }
        }
    }

    public void UpdateWeaponPopUP()
    {
        inventoryAllHolder.InventoryAllItemSystem.popUPInformationForWeapon.UpdatePanel(SlotWeapon[inventorySlotUI[nowi].ID]);
        inventoryAllHolder.InventoryAllItemSystem.popUPInformationForCraft.UpdatePanel(SlotWeapon[inventorySlotUI[nowi].ID], SlotMaterial[SlotWeapon[inventorySlotUI[nowi].ID].ItemWeapon.IDItemUsed1], SlotMaterial[SlotWeapon[inventorySlotUI[nowi].ID].ItemWeapon.IDItemUsed2]);
    }

    private void OpenPopUpInformation(int i)
    {
        if(inventorySlotUI[i].TypeInventory == TypeWeapon && SlotWeapon.Count > inventorySlotUI[i].ID)
        {
            inventoryAllHolder.InventoryAllItemSystem.InformationPanel.SetActive(true);
            inventoryAllHolder.InventoryAllItemSystem.PopUPWeapon.SetActive(true);
            inventoryAllHolder.InventoryAllItemSystem.PopUPMateril.SetActive(false);
            inventoryAllHolder.InventoryAllItemSystem.PopUPCraft.SetActive(false);
            inventoryAllHolder.InventoryAllItemSystem.popUPInformationForWeapon.UpdatePanel(SlotWeapon[inventorySlotUI[i].ID]);
            inventoryAllHolder.InventoryAllItemSystem.popUPInformationForCraft.UpdatePanel(SlotWeapon[inventorySlotUI[i].ID], SlotMaterial[SlotWeapon[inventorySlotUI[i].ID].ItemWeapon.IDItemUsed1], SlotMaterial[SlotWeapon[inventorySlotUI[i].ID].ItemWeapon.IDItemUsed2]);
        }

        if(inventorySlotUI[i].TypeInventory == TypeMaterial && SlotMaterial.Count > inventorySlotUI[i].ID)
        {
            inventoryAllHolder.InventoryAllItemSystem.InformationPanel.SetActive(true);
            inventoryAllHolder.InventoryAllItemSystem.PopUPWeapon.SetActive(false);
            inventoryAllHolder.InventoryAllItemSystem.PopUPMateril.SetActive(true);
            inventoryAllHolder.InventoryAllItemSystem.PopUPCraft.SetActive(false);
            inventoryAllHolder.InventoryAllItemSystem.popUPInformationForMaterial.UpdatePanel(SlotMaterial[inventorySlotUI[i].ID]);
        }
        
    }

    public void ChangeTypeShowItem(bool showCountNumberLong, bool countFromMoreToLess, bool isMaterial, bool isWeapon, bool isSword, bool isHat, bool isShirt, bool isPant, bool isShoe)
    {
        ShowCountNumberLong = showCountNumberLong;
        CountFromMoreToLess = countFromMoreToLess;
        IsMaterial = isMaterial;
        IsWeapon = isWeapon;
        IsSword = isSword;
        IsHat = isHat;
        IsShirt = isShirt;
        IsPant = isPant;
        IsShoe = isShoe;
    }


    public void ClearSlot() {
        for(int i=0; i<inventorySlotUI.Length; i++)
        {
            inventorySlotUI[i].ClearSlot();
            //inventorySlotUI[i].UpdateSlot(null, 0);
        }
    }


    public void UpdateSlot() {
        if(CountFromMoreToLess) 
        {
            SlotRun_position = 0;
            for(int i=SlotMaterial.Count-1; i>=0 ; i--) UpdateSlotMaterialAt(i);
            for(int i=SlotWeapon.Count-1; i>=0 ; i--) UpdateSlotWeaponAt(i);
        }
        else 
        {
            SlotRun_position = 0;
            for(int i=0; i<inventorySlotUI.Length && i<SlotMaterial.Count; i++) UpdateSlotMaterialAt(i);
            for(int i=0; i<inventorySlotUI.Length && i<SlotWeapon.Count; i++) UpdateSlotWeaponAt(i);
        }
    }

    private void UpdateSlotWeaponAt(int i)
    {
        
        if(IsWeapon)
        {
            if(SlotWeapon[i].Activate)
            {
                if(SlotWeapon[i].ItemWeapon.Sword && IsSword)
                {
                    Sprite icon = SlotWeapon[i].ItemWeapon.Icon;
                    double numberAmount = SlotWeapon[i].ItemWeapon.NumberAmount;
                    long multiplierAmount = SlotWeapon[i].ItemWeapon.MultiplierAmount;
                    int id = SlotWeapon[i].ItemWeapon.ID;
                    bool EverHave = SlotWeapon[i].ItemWeapon.EverHave;

                    inventorySlotUI[SlotRun_position].UpdateSlot(EverHave, id, TypeWeapon, icon, numberAmount, multiplierAmount, ShowCountNumberLong);
                    SlotRun_position++;
                }
                else if(SlotWeapon[i].ItemWeapon.Hat && IsHat)
                {
                    Sprite icon = SlotWeapon[i].ItemWeapon.Icon;
                    double numberAmount = SlotWeapon[i].ItemWeapon.NumberAmount;
                    long multiplierAmount = SlotWeapon[i].ItemWeapon.MultiplierAmount;
                    int id = SlotWeapon[i].ItemWeapon.ID;
                    bool EverHave = SlotWeapon[i].ItemWeapon.EverHave;

                    inventorySlotUI[SlotRun_position].UpdateSlot(EverHave, id, TypeWeapon, icon, numberAmount, multiplierAmount, ShowCountNumberLong);
                    SlotRun_position++;
                }
                else if(SlotWeapon[i].ItemWeapon.Shirt && IsShirt)
                {
                    Sprite icon = SlotWeapon[i].ItemWeapon.Icon;
                    double numberAmount = SlotWeapon[i].ItemWeapon.NumberAmount;
                    long multiplierAmount = SlotWeapon[i].ItemWeapon.MultiplierAmount;
                    int id = SlotWeapon[i].ItemWeapon.ID;
                    bool EverHave = SlotWeapon[i].ItemWeapon.EverHave;

                    inventorySlotUI[SlotRun_position].UpdateSlot(EverHave, id, TypeWeapon, icon, numberAmount, multiplierAmount, ShowCountNumberLong);
                    SlotRun_position++;
                }
                else if(SlotWeapon[i].ItemWeapon.Pant && IsPant)
                {
                    Sprite icon = SlotWeapon[i].ItemWeapon.Icon;
                    double numberAmount = SlotWeapon[i].ItemWeapon.NumberAmount;
                    long multiplierAmount = SlotWeapon[i].ItemWeapon.MultiplierAmount;
                    int id = SlotWeapon[i].ItemWeapon.ID;
                    bool EverHave = SlotWeapon[i].ItemWeapon.EverHave;

                    inventorySlotUI[SlotRun_position].UpdateSlot(EverHave, id, TypeWeapon, icon, numberAmount, multiplierAmount, ShowCountNumberLong);
                    SlotRun_position++;
                }
                else if(SlotWeapon[i].ItemWeapon.Shoe && IsShoe)
                {
                    Sprite icon = SlotWeapon[i].ItemWeapon.Icon;
                    double numberAmount = SlotWeapon[i].ItemWeapon.NumberAmount;
                    long multiplierAmount = SlotWeapon[i].ItemWeapon.MultiplierAmount;
                    int id = SlotWeapon[i].ItemWeapon.ID;
                    bool EverHave = SlotWeapon[i].ItemWeapon.EverHave;

                    inventorySlotUI[SlotRun_position].UpdateSlot(EverHave, id, TypeWeapon, icon, numberAmount, multiplierAmount, ShowCountNumberLong);
                    SlotRun_position++;
                }
            }
        }
    }

    private void UpdateSlotMaterialAt(int i)
    {
        if(IsMaterial)
        {
            if(SlotMaterial[i].Activate)
            {
                    
                Sprite icon = SlotMaterial[i].ItemMaterial.Icon;
                double numberAmount = SlotMaterial[i].ItemMaterial.NumberAmount;
                long multiplierAmount = SlotMaterial[i].ItemMaterial.MultiplierAmount;
                int id = SlotMaterial[i].ItemMaterial.ID;
                bool EverHave = SlotMaterial[i].ItemMaterial.EverHave;

                inventorySlotUI[SlotRun_position].UpdateSlot(EverHave, id, TypeMaterial, icon, numberAmount, multiplierAmount, ShowCountNumberLong);
                SlotRun_position++;
            }
        }
        
    }

}
