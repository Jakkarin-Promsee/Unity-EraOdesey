using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    
    public int NumberDisplay = 0;
    public string TypeInventory = "";
    public bool IsClick = false;
    public int ID;

    [SerializeField] private Image itemSprite;
    [SerializeField] private TMP_Text itemCount;
    [SerializeField] private TMP_Text itemUpgrade;
    
    [SerializeField] private InventorySlotMaterial assignedInventorySlotMaterial;
    [SerializeField] private InventorySlotWeapon assignedInventorySlotWeapon;

    public InventorySlotMaterial AssignedInventorySlotMaterial => assignedInventorySlotMaterial;
    public InventorySlotWeapon AssignedInventorySlotWeapon => assignedInventorySlotWeapon;
    public InventoryAllItemSystem DataInventoryAllItemSystem;

    public Button button;

    public void Load(EquipmentDataKeep data)
    {
        ID = data.ID;
        TypeInventory = data.TypeInventory;
    }

    public void ClearSlot()
     {
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
        itemUpgrade.text = "";

        ID = -1;
    }

    public void ButtomWasClicked()
    {
        IsClick = true;
    }

    public void UpdateSlot(bool EverHave, int NewID, string NewTypeInventory, Sprite NewItemSprite, double numberAmount, long multiplierAmount ,bool ShowCountNumberLong)
    {
        ID = NewID;
        TypeInventory = NewTypeInventory;
        if(EverHave)
        {
            itemSprite.color = Color.white;
            itemSprite.sprite = NewItemSprite;  
            
            
            string stringItemCount = "";

            long longNumber;

            if(ShowCountNumberLong && ConvertNewPatternTolong(numberAmount, multiplierAmount ,out longNumber))
            {
                stringItemCount = longNumber.ToString("");
            }
            else 
            {
                if(multiplierAmount > 0) stringItemCount = numberAmount.ToString("F2") + multiple[multiplierAmount];
                else 
                {
                    if(TypeInventory == "Weapon" && numberAmount == 0) stringItemCount = "";
                    else stringItemCount = numberAmount.ToString("F0");
                }
                
            }
            
            if(TypeInventory == "Weapon") 
            {
                itemCount.text = "";
                if(stringItemCount == "") itemUpgrade.text = stringItemCount;
                else itemUpgrade.text = "+" + stringItemCount;
            }
            else 
            {
                itemCount.text = stringItemCount;
                itemUpgrade.text = "";
            }
        }
        else{
            itemSprite.color = Color.black;
            itemSprite.sprite = NewItemSprite;  
            itemCount.text = "";
        }

        

    }

    public bool ConvertNewPatternTolong(double number, long mutiplier, out long count)
    {
        if(mutiplier<=3)
        {
            count = (long)(number*Mathf.Pow(1000, mutiplier));
            return true;
        }
        else
        {
            count = -1;
            return false;
        }
    }
}
