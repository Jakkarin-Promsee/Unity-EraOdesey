using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryAllHolder : MonoBehaviour, IDataPersistance
{
    [SerializeField] protected InventoryAllItemSystem inventoryAllItemSystem;

    public InventoryAllItemSystem InventoryAllItemSystem => inventoryAllItemSystem;

    public void LoadData(GameData data)
    {
        for(int i=0; i<inventoryAllItemSystem.InventorySlotMaterials.Count; i++)
        {
            inventoryAllItemSystem.InventorySlotMaterials[i].LoadData(data.materials[i]);
        }

        for(int i=0; i<inventoryAllItemSystem.InventorySlotWeapons.Count; i++)
        {
            inventoryAllItemSystem.InventorySlotWeapons[i].LoadData(data.weapons[i]);
        }



        for(int i=0; i<inventoryAllItemSystem.equipmentSystem.inventorySlotUI.Length; i++)
        {
            inventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].ID = data.equipment[i].ID;
            inventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].TypeInventory = data.equipment[i].TypeInventory;
            Debug.LogWarning(inventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].ID);
        
        }

        for(int i=0; i<inventoryAllItemSystem.equipmentSystem.KeepIDWeapon.Length && i < data.KeepIDWeapon.Length; i++)
        {
            inventoryAllItemSystem.equipmentSystem.KeepIDWeapon[i] = data.KeepIDWeapon[i];
        } 
    }

    public void SaveData(ref GameData data)
    {
        for(int i=0; i<inventoryAllItemSystem.InventorySlotMaterials.Count; i++)
        {
            data.materials[i].SaveNewData(inventoryAllItemSystem.InventorySlotMaterials[i]);
        }

        for(int i=0; i<inventoryAllItemSystem.InventorySlotWeapons.Count; i++)
        {
            data.weapons[i].SaveNewData(inventoryAllItemSystem.InventorySlotWeapons[i]);
        }



        for(int i=0; i<inventoryAllItemSystem.equipmentSystem.inventorySlotUI.Length; i++)
        {
            data.equipment[i].SaveNewData(inventoryAllItemSystem.equipmentSystem.inventorySlotUI[i]);
        }

        for(int i=0; i<inventoryAllItemSystem.equipmentSystem.KeepIDWeapon.Length && i < data.KeepIDWeapon.Length ; i++)
        {
            data.KeepIDWeapon[i] = inventoryAllItemSystem.equipmentSystem.KeepIDWeapon[i];
        }
    }

    public void Unknown()
    {
        GodCommand_ActivateMaterial();
        //GodCommand_ActivateWeapon();
        GodCommand_GetMaterial();
        //GodCommand_GetWeapon();
    }

    private void Start() 
    {
        Invoke("UpdateItem",0.4f);
        inventoryAllItemSystem.ChangeTypeSHowItemFromSuppostHoldeer_AtAllSystem();

        //Reset all data about inventory because it reset prefab to zero
        //inventoryAllItemSystem.ClearAllSlot();

        UpdateDisplaySlotFromHolder();

        inventoryAllItemSystem.LoadingPanel.SetActive(true);
        Invoke("SetTrueAllActivePanel",0.1f);
        Invoke("SetFalseAllActivePanel",0.35f);
        Invoke("SetDefultAllActivePanel",0.6f);
    }

    void GodCommand_ActivateMaterial()
    {
        inventoryAllItemSystem.ActivateMaterial(0,inventoryAllItemSystem.InventorySlotMaterials.Count);
        inventoryAllItemSystem.EverHaveMaterial(0,inventoryAllItemSystem.InventorySlotMaterials.Count);
    }

    void GodCommand_ActivateWeapon()
    {
        inventoryAllItemSystem.ActivateWeapon(0,inventoryAllItemSystem.InventorySlotWeapons.Count);
        inventoryAllItemSystem.EverHaveWeapon(0,inventoryAllItemSystem.InventorySlotWeapons.Count);
    }

    void GodCommand_GetMaterial()
    {
        inventoryAllItemSystem.GetMaterial(0,inventoryAllItemSystem.InventorySlotMaterials.Count,1,1);
    }

    void GodCommand_GetWeapon()
    {
        inventoryAllItemSystem.GetWeapon(0,inventoryAllItemSystem.InventorySlotWeapons.Count,1,0);
    }


    void UpdateItem()
    {
        
        //GodCommand_ActivateMaterial();
        //GodCommand_ActivateWeapon();
        //GodCommand_GetMaterial();
        //GodCommand_GetWeapon();
        
        ChangeAllLanguageToEnglish();
        
        inventoryAllItemSystem.ActivateMaterial(0,12);
        inventoryAllItemSystem.ActivateWeapon(0,24);
        

        inventoryAllItemSystem.playerMainController.skillAllSystem.ActivateSkillAt(0);
        inventoryAllItemSystem.playerMainController.skillAllSystem.ActivateSkillAt(1);
        inventoryAllItemSystem.playerMainController.skillAllSystem.ActivateSkillAt(2);
        inventoryAllItemSystem.playerMainController.skillAllSystem.ActivateSkillAt(3);
        inventoryAllItemSystem.playerMainController.skillAllSystem.ActivateSkillAt(4);

        inventoryAllItemSystem.displayControl.SetActivate(0,8);
    }

    void SetTrueAllActivePanel()
    {
        inventoryAllItemSystem.LockSkill.SetActive(true);

        inventoryAllItemSystem.BossFightButton.SetActive(true);

        inventoryAllItemSystem.InformationPanel.SetActive(true);
        inventoryAllItemSystem.SkillSLot.SetActive(true);
        inventoryAllItemSystem.InventoryPanel.SetActive(true);
        inventoryAllItemSystem.LoadingPanel.SetActive(true);
        inventoryAllItemSystem.PeriodPanel.SetActive(true);
        inventoryAllItemSystem.Book.SetActive(true);

        inventoryAllItemSystem.BookSelectPanel.SetActive(true);
        inventoryAllItemSystem.BookReadPanel.SetActive(true);
        inventoryAllItemSystem.SelectFightPanel.SetActive(true);
        inventoryAllItemSystem.MinigamePanel.SetActive(true);
        inventoryAllItemSystem.EndGamePanel.SetActive(true);

        inventoryAllItemSystem.EquipmentSubPanel.SetActive(true);
        inventoryAllItemSystem.CraftSubPanel.SetActive(true);
        inventoryAllItemSystem.InventorySubPanel.SetActive(true);
        inventoryAllItemSystem.Skillpanel.SetActive(true);
        inventoryAllItemSystem.SkillPopUP.SetActive(true);

        inventoryAllItemSystem.PopUPMateril.SetActive(true);
        inventoryAllItemSystem.PopUPWeapon.SetActive(true);
        inventoryAllItemSystem.PopUPCraft.SetActive(true);
    }
    void SetFalseAllActivePanel()
    {
        inventoryAllItemSystem.LockSkill.SetActive(false);

        inventoryAllItemSystem.BossFightButton.SetActive(false);

        inventoryAllItemSystem.InformationPanel.SetActive(false);
        inventoryAllItemSystem.SkillSLot.SetActive(false);
        inventoryAllItemSystem.InventoryPanel.SetActive(false);
        inventoryAllItemSystem.LoadingPanel.SetActive(true);
        inventoryAllItemSystem.PeriodPanel.SetActive(false);
        inventoryAllItemSystem.Book.SetActive(false);

        inventoryAllItemSystem.BookSelectPanel.SetActive(false);
        inventoryAllItemSystem.BookReadPanel.SetActive(false);
        inventoryAllItemSystem.SelectFightPanel.SetActive(false);
        inventoryAllItemSystem.MinigamePanel.SetActive(false);
        inventoryAllItemSystem.EndGamePanel.SetActive(false);

        inventoryAllItemSystem.EquipmentSubPanel.SetActive(false);
        inventoryAllItemSystem.CraftSubPanel.SetActive(false);
        inventoryAllItemSystem.InventorySubPanel.SetActive(false);
        inventoryAllItemSystem.Skillpanel.SetActive(false);
        inventoryAllItemSystem.SkillPopUP.SetActive(false);

        inventoryAllItemSystem.PopUPMateril.SetActive(false);
        inventoryAllItemSystem.PopUPWeapon.SetActive(false);
        inventoryAllItemSystem.PopUPCraft.SetActive(false);
    }

    void SetDefultAllActivePanel()
    {
        inventoryAllItemSystem.LockSkill.SetActive(true);

        inventoryAllItemSystem.BossFightButton.SetActive(true);

        inventoryAllItemSystem.LoadingPanel.SetActive(false);
        inventoryAllItemSystem.SkillSLot.SetActive(true);
        inventoryAllItemSystem.InformationPanel.SetActive(false);
        inventoryAllItemSystem.InventoryPanel.SetActive(true);
        inventoryAllItemSystem.PeriodPanel.SetActive(true);
        inventoryAllItemSystem.Book.SetActive(false);

        inventoryAllItemSystem.BookSelectPanel.SetActive(true);
        inventoryAllItemSystem.BookReadPanel.SetActive(false);
        inventoryAllItemSystem.SelectFightPanel.SetActive(false);
        inventoryAllItemSystem.MinigamePanel.SetActive(false);
        inventoryAllItemSystem.EndGamePanel.SetActive(false);

        inventoryAllItemSystem.EquipmentSubPanel.SetActive(false);
        inventoryAllItemSystem.CraftSubPanel.SetActive(false);
        inventoryAllItemSystem.InventorySubPanel.SetActive(true);
        inventoryAllItemSystem.Skillpanel.SetActive(false);
        inventoryAllItemSystem.SkillPopUP.SetActive(false);

        inventoryAllItemSystem.PopUPMateril.SetActive(false);
        inventoryAllItemSystem.PopUPWeapon.SetActive(false);
        inventoryAllItemSystem.PopUPCraft.SetActive(false);
    }

    
    public void UpdateDisplaySlotFromHolder()
    {
        Invoke("UD",0.7f);
    }

    private void UD()
    {
        inventoryAllItemSystem.UpdateDisplaySlot();
    }

    
    public void ChangeAllLanguageToDefault()
    {
        inventoryAllItemSystem.ChangeLanguageToDefault();
        inventoryAllItemSystem.ChangeLanguagePopUPToDefault();
        inventoryAllItemSystem.playerMainController.skillAllSystem.ChangeLanguageToDefault();
        inventoryAllItemSystem.BookSelectControl.ChangeLanguageToDefault();
    }

    public void ChangeAllLanguageToEnglish()
    {
        inventoryAllItemSystem.ChangeLanguageToEnglish();
        inventoryAllItemSystem.ChangeLanguagePopUPToEnglish();
        inventoryAllItemSystem.playerMainController.skillAllSystem.ChangeLanguageToEnglish();
        inventoryAllItemSystem.BookSelectControl.ChangeLanguageToEnglish();
    }

    public void ChangeAllLanguageToThai()
    {
        inventoryAllItemSystem.ChangeLanguageToThai();
        inventoryAllItemSystem.ChangeLanguagePopUPToThai();
        inventoryAllItemSystem.playerMainController.skillAllSystem.ChangeLanguageToThai();
        inventoryAllItemSystem.BookSelectControl.ChangeLanguageToThai();
    }
    
}
