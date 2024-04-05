using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Item Material")]
[System.Serializable]
public class InventoryMaterialData : ScriptableObject
{
    //***************************************************************************************************
    //Input Data Use to setup each object
    [Header ("Input Main Data")]
    public int ID = -1;
    public Sprite Icon = null;


    [Header ("Input English Detail")]
    public string English_name = "";
    public string English_period = "";
    [TextArea(4,4)] public string English_Detail = "";


    [Header ("Input Thai Detail")]
    public string Thai_name = "";
    public string Thai_period = "";
    [TextArea(4,4)] public string Thai_Detail = "";

    [Header ("Description")]
    [TextArea(2,4)] public string Description = "----- Ending input Data -----";
    
    //***************************************************************************************************
    //Auto Data && Data that keep with json file
    [Header ("**Do not Input** It's a Auto Data")]
    public bool EverHave = false;
    public bool Activate = false;
    [SerializeField] public double NumberAmount = 0;
    [SerializeField] public long MultiplierAmount = 0;
    
    //***************************************************************************************************
    //Manual Data use to display player
    [Header ("**Do not Input** It's a Auto Data")]
    [SerializeField] public string Name = "";
    [SerializeField] [TextArea(6,4)] public string Detail = ""; 
    [SerializeField] public string Period = "";

    private void Awake() {
        Description = "------------- Ending input Data -------------";
    }
    
}
