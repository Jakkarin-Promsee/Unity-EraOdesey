using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    public bool FirstReset = false;
    public bool ResetData = false;
    [Header ("Referent Data")]
    public InventoryAllHolder inventoryAllHolder;
    public PlayerMainController playerMainController;
    public EquipmentSystem equipmentSystem;
    public DisplayControl displayControl;

    [Header ("File Storage Conflig")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;    
    private FileDataHandler dataHandler;

    public static DataPersistanceManager instance { get; private set;}


    private void Awake() {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene");
        }
        instance = this;
    }

    private void Start() {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObject();
        LoadGame();
    }

    public void NewGame()
    {
        inventoryAllHolder.InventoryAllItemSystem.ClearAllSlot();
        playerMainController.skillAllSystem.ClearAllSkillAllElement();
        equipmentSystem.ClearSlot();
        displayControl.DisplayClear();

        this.gameData = new GameData(inventoryAllHolder, playerMainController, equipmentSystem, displayControl);
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defualts.");
            NewGame();
        }

        if(ResetData)
        {
            Debug.Log("Reset Data From variable reset data in DataPersistanceManager script");
            NewGame();
        }

        if(this.gameData.IsFirstReset == false && FirstReset == true){
            Debug.Log("Reset Data From variable reset data in DataPersistanceManager script");
            FirstReset = true;
            NewGame();
        }
        
        

        if(this.gameData.materials.Length != inventoryAllHolder.InventoryAllItemSystem.InventorySlotMaterials.Count
        || this.gameData.weapons.Length != inventoryAllHolder.InventoryAllItemSystem.InventorySlotWeapons.Count
        || this.gameData.skillEarth.Length != playerMainController.skillAllSystem.SkillEarth.listSkillSlotEarths.Count
        || this.gameData.skillFire.Length != playerMainController.skillAllSystem.skillFire.listSkillSlotFires.Count
        || this.gameData.skillFrost.Length != playerMainController.skillAllSystem.skillFrost.listSkillSlotFrosts.Count
        || this.gameData.skillWater.Length != playerMainController.skillAllSystem.skillWater.listSkillSlotWaters.Count
        || this.gameData.equipment.Length != equipmentSystem.inventorySlotUI.Length
        || this.gameData.KeepIDWeapon.Length != equipmentSystem.KeepIDWeapon.Length)
        {
            Debug.Log("Data out of length. Reset data again");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObject(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }


}
