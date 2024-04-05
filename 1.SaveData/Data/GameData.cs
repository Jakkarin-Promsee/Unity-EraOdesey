using System;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool IsFirstReset = false;
    public int UnlockLevel = 0;
    public float MusicVolume = 0;
    public float EffectVolume = 0;
    public int level;

    [SerializeField] public string LogOutTime = "";

    //Array for keep inventory data
    [SerializeField] public MaterialDataKeep[] materials = new MaterialDataKeep[0];
    [SerializeField] public WeaponDataKeep[] weapons = new WeaponDataKeep[0];

    //Array for keep skill data
    [SerializeField] public SkillDataKeep[] skillEarth = new SkillDataKeep[0];
    [SerializeField] public SkillDataKeep[] skillFire = new SkillDataKeep[0];
    [SerializeField] public SkillDataKeep[] skillFrost = new SkillDataKeep[0];
    [SerializeField] public SkillDataKeep[] skillWater = new SkillDataKeep[0];

    [SerializeField] public EquipmentDataKeep[] equipment = new EquipmentDataKeep[0];
    [SerializeField] public int[] KeepIDWeapon = new int[0];

    [SerializeField] public SkillPanelDataKeep[] skillPanel = new SkillPanelDataKeep[0];
    public bool IsAutoSkill = false;
    public bool IsAutoSkillTricker = false;
    public bool IsAutoSKillSum = false;

    public GameData(InventoryAllHolder inventoryAllHolder, 
                    PlayerMainController playerMainController,
                    EquipmentSystem equipmentSystem,
                    DisplayControl displayControl
                    )
    {
        this.LogOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        UnlockLevel = 11;
        MusicVolume = 0.5f;
        EffectVolume = 0.5f;

        //***************************** Create Inventory Array *****************************
        //Read size of inventory list
        int SizeOfMaterialList = inventoryAllHolder.InventoryAllItemSystem.InventorySlotMaterials.Count;
        int SizeOfWeaponList = inventoryAllHolder.InventoryAllItemSystem.InventorySlotWeapons.Count;
        
        //Create material array
        materials = new MaterialDataKeep[SizeOfMaterialList];
        for(int i=0; i<SizeOfMaterialList; i++)
        {
            materials[i] = new MaterialDataKeep();
            materials[i].NewData();
        }

        //Create Weapon array
        weapons = new WeaponDataKeep[SizeOfWeaponList];
        for(int i=0; i<SizeOfWeaponList; i++)
        {
            weapons[i] = new WeaponDataKeep();
            weapons[i].NewData();
        }

        //***************************** Create Inventory Array *****************************
        //Read size of skill list
        int SizeOfSkillEarth = playerMainController.skillAllSystem.skillEarth.listSkillSlotEarths.Count;
        int SizeOFSkillFire = playerMainController.skillAllSystem.skillFire.listSkillSlotFires.Count;
        int SizeOfSkillFrost = playerMainController.skillAllSystem.skillFrost.listSkillSlotFrosts.Count;
        int SizeOfSkillWater = playerMainController.skillAllSystem.skillWater.listSkillSlotWaters.Count;

        //Create skill earth array
        skillEarth = new SkillDataKeep[SizeOfSkillEarth];
        for(int i=0; i<SizeOfSkillEarth; i++)
        {
            skillEarth[i] = new SkillDataKeep();
            skillEarth[i].NewData();
        }

        //Create skill fire array
        skillFire = new SkillDataKeep[SizeOFSkillFire];
        for(int i=0; i<SizeOFSkillFire; i++)
        {
            skillFire[i] = new SkillDataKeep();
            skillFire[i].NewData();
        }

        //Create skill frost array
        skillFrost = new SkillDataKeep[SizeOfSkillFrost];
        for(int i=0; i<SizeOfSkillFrost; i++)
        {
            skillFrost[i] = new SkillDataKeep();
            skillFrost[i].NewData();

        }

        //Create skill water array
        skillWater = new SkillDataKeep[SizeOfSkillWater];
        for(int i=0; i<SizeOfSkillWater; i++)
        {
            skillWater[i] = new SkillDataKeep();
            skillWater[i].NewData();
        }

        //***************************** Create Equipment Array *****************************
        //Read size of Equipment array
        int sizeOfEquipment = equipmentSystem.inventorySlotUI.Length;
        int sizeOfKeepIdWeapon = equipmentSystem.KeepIDWeapon.Length;

        equipment = new EquipmentDataKeep[sizeOfEquipment];
        for(int i=0; i<sizeOfEquipment; i++)
        {
            equipment[i] = new EquipmentDataKeep();
            equipment[i].NewData();
        }

        KeepIDWeapon = new int[sizeOfKeepIdWeapon];
        for(int i=0; i<sizeOfKeepIdWeapon; i++)
        {
            KeepIDWeapon[i] = -1;
        }

        //***************************** Create Skill Panel Array *****************************
        //Read size of Skill Panel list
        int sizeOfSkillPanel = displayControl.listDisplay.Count;

        skillPanel = new SkillPanelDataKeep[sizeOfSkillPanel];
        for(int i=0; i<sizeOfSkillPanel; i++)
        {
            skillPanel[i] = new SkillPanelDataKeep();
            skillPanel[i].NewData();
        }
        IsAutoSkill = false;
        IsAutoSkillTricker = false;
        IsAutoSKillSum = false;
    }
}
