using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] protected InventoryAllHolder inventoryAllHolder;

    public InventorySlotUI[] inventorySlotUI;
    //Sword1 : 0
    //Sword2 : 1
    //Hat    : 2
    //Shirt  : 3
    //Pant   : 4
    //Shoe   : 5

    public InventoryAllHolder InventoryAllHolder => inventoryAllHolder;
    InventoryAllItemSystem InventoryAllItemSystem => InventoryAllHolder.InventoryAllItemSystem;
    public List<InventorySlotMaterial> SlotMaterial => InventoryAllItemSystem.InventorySlotMaterials;
    public List<InventorySlotWeapon> SlotWeapon => InventoryAllItemSystem.InventorySlotWeapons;

    public int[] KeepIDWeapon;

    private void Start() {
        KeepIDWeapon = new int[6];
        /*
        for(int i=0; i<inventorySlotUI.Length; i++)
        {
            inventorySlotUI[i].ID = -1;
        }

        for(int i=0; i<KeepIDWeapon.Length; i++)
        {
            KeepIDWeapon[i] = -1;
        }
        */


        Debug.Log(KeepIDWeapon[1]);
        //KeepIDWeapon[0] = -1;
        //KeepIDWeapon[1] = -1;
        //KeepIDWeapon[2] = -1;
        //KeepIDWeapon[3] = -1;
        //KeepIDWeapon[4] = -1;
        //KeepIDWeapon[5] = -1;

        //Use for clear all data in slot
        //ClearSlot();

        Invoke("UpdateSlot",1f);
    }

    float CountTime = 0.25f;
    float MaxCountTime = 0.25f;
    private void Update() {
        if(CountTime < MaxCountTime) CountTime+=Time.deltaTime;
        else{
            CountTime = 0;
            CheckInventorySlotUIOnClick();
        }
    }

    public void CheckInventorySlotUIOnClick()
    {
        for(int i=0; i<inventorySlotUI.Length; i++)
        {
            if(inventorySlotUI[i].IsClick) 
            {
                inventorySlotUI[i].IsClick = false;
                if(inventorySlotUI[i].ID>=0){
                if(SlotWeapon.Count > inventorySlotUI[i].ID && SlotWeapon[inventorySlotUI[i].ID].ItemWeapon.EverHave)
                {
                    inventoryAllHolder.InventoryAllItemSystem.InformationPanel.SetActive(true);
                    inventoryAllHolder.InventoryAllItemSystem.PopUPWeapon.SetActive(true);
                    inventoryAllHolder.InventoryAllItemSystem.PopUPMateril.SetActive(false);
                    inventoryAllHolder.InventoryAllItemSystem.PopUPCraft.SetActive(false);
                    inventoryAllHolder.InventoryAllItemSystem.popUPInformationForWeapon.UpdatePanel(SlotWeapon[inventorySlotUI[i].ID]);
                    inventoryAllHolder.InventoryAllItemSystem.popUPInformationForCraft.UpdatePanel(SlotWeapon[inventorySlotUI[i].ID], SlotMaterial[SlotWeapon[inventorySlotUI[i].ID].ItemWeapon.IDItemUsed1], SlotMaterial[SlotWeapon[inventorySlotUI[i].ID].ItemWeapon.IDItemUsed2]);
                }
                }
            }
        }
    }

    

    

    public void UpdateSlotFronUseButton(int IDWeapon ,int TypeWeapon)
    {
        if(KeepIDWeapon[TypeWeapon]>=0) SlotWeapon[KeepIDWeapon[TypeWeapon]].ItemWeapon.IsUse = false;
        if(KeepIDWeapon[TypeWeapon] == IDWeapon) 
        {
            SlotWeapon[IDWeapon].ItemWeapon.IsUse = false;
            KeepIDWeapon[TypeWeapon] = -1;
        }
        else 
        {
            SlotWeapon[IDWeapon].ItemWeapon.IsUse = true;
            KeepIDWeapon[TypeWeapon] = IDWeapon;
        }
        

        Sprite icon = SlotWeapon[IDWeapon].ItemWeapon.Icon;
        double numberAmount = SlotWeapon[IDWeapon].ItemWeapon.NumberAmount;
        long multiplierAmount = SlotWeapon[IDWeapon].ItemWeapon.MultiplierAmount;
        int id = SlotWeapon[IDWeapon].ItemWeapon.ID;
        bool EverHave = SlotWeapon[IDWeapon].ItemWeapon.EverHave;

        if(SlotWeapon[IDWeapon].ItemWeapon.IsUse)
        {
            if(TypeWeapon == 0) inventorySlotUI[TypeWeapon].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
            if(TypeWeapon == 1) inventorySlotUI[TypeWeapon].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
            if(TypeWeapon == 2) inventorySlotUI[TypeWeapon].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
            if(TypeWeapon == 3) inventorySlotUI[TypeWeapon].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
            if(TypeWeapon == 4) inventorySlotUI[TypeWeapon].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
            if(TypeWeapon == 5) inventorySlotUI[TypeWeapon].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
        }
        else{
            if(TypeWeapon == 0) inventorySlotUI[TypeWeapon].ClearSlot();
            if(TypeWeapon == 1) inventorySlotUI[TypeWeapon].ClearSlot();
            if(TypeWeapon == 2) inventorySlotUI[TypeWeapon].ClearSlot();
            if(TypeWeapon == 3) inventorySlotUI[TypeWeapon].ClearSlot();
            if(TypeWeapon == 4) inventorySlotUI[TypeWeapon].ClearSlot();
            if(TypeWeapon == 5) inventorySlotUI[TypeWeapon].ClearSlot();
        }
    }

    public void UpdateSlot()
    {
        for(int i=0; i<inventorySlotUI.Length; i++)
        {
            int IDWeapon = inventorySlotUI[i].ID;

            if(IDWeapon>=0)
            {
                Sprite icon = SlotWeapon[IDWeapon].ItemWeapon.Icon;
                double numberAmount = SlotWeapon[IDWeapon].ItemWeapon.NumberAmount;
                long multiplierAmount = SlotWeapon[IDWeapon].ItemWeapon.MultiplierAmount;
                int id = SlotWeapon[IDWeapon].ItemWeapon.ID;
                bool EverHave = SlotWeapon[IDWeapon].ItemWeapon.EverHave;

                inventorySlotUI[i].UpdateSlot(EverHave, id, "Weapon", icon, numberAmount, multiplierAmount, false);
            }
            else{
                inventorySlotUI[i].ClearSlot();
            }
        }
    }

    

    public void ClearSlot() {
        for(int i=0; i<inventorySlotUI.Length; i++)
        {
            inventorySlotUI[i].ClearSlot();
            //inventorySlotUI[i].UpdateSlot(null, 0);
        }
    }
}
