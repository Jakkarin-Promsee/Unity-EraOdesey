using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Item Weapon")]
[System.Serializable]
public class InventoryWeaponData : ScriptableObject
{
    //***************************************************************************************************
    //Input Data Use to setup each object
    [Header ("Input Main Data")]
    [SerializeField] public int ID = -1;
    public Sprite Icon = null;

    [Header ("Input English Detail")]
    public string English_name = "";
    public string English_period = "";
    [TextArea(4,4)] public string English_Detail = "";

    [Header ("Input Thai Detail")]
    public string Thai_name = "";
    public string Thai_period = "";
    [TextArea(4,4)] public string Thai_Detail = "";

    [Header ("Input Properties")]
    public bool Sword = false;
    public bool Hat = false;
    public bool Shirt  = false;
    public bool Pant  = false;
    public bool Shoe  = false;

    [Header ("Input Material Craft 1")]
    public int IDItemUsed1 = -1;
    [SerializeField] public double NumberAmountItemUsed1 = 0;
    [SerializeField] public long MultiplierAmountItemUsed1 = 0;

    [Header ("Input Material Craft 2")]
    public int IDItemUsed2 = -1;
    [SerializeField] public double NumberAmountItemUsed2 = 0;
    [SerializeField] public long MultiplierAmountItemUsed2 = 0;

    [Header ("Input Multiplier Damage")]
    [SerializeField] public double AmountDamage = 0;
    [SerializeField] public long MultiplierDamage = 0;

    [Header ("Description")]
    [TextArea(2,4)] public string Description = "----- Ending input Data -----";
    
    //***************************************************************************************************
    //Auto Data && Data that keep with json file
    [Header ("**Do not Input** It's a Auto Data")]
    public bool IsUse = false;
    public bool EverHave = false;
    public bool Activate = false;
    [SerializeField] public double NumberAmount = 0;
    [SerializeField] public long MultiplierAmount = 0;

    //***************************************************************************************************
    //Manual Data use to display player
    [Header ("**Do not Input** It's a Display Data")]
    [SerializeField] public string Name = "";
    [SerializeField] [TextArea(6,4)] public string Detail = "";
    [SerializeField] public string Period = "";

    private void Awake() {
        Description = "------------- Ending input Data -------------";
    }


}
