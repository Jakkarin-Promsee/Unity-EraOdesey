using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUPInformationForMaterial : MonoBehaviour
{
    private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    public Image LowerBackGround;
    public Image BackGround;
    public Image BackGroundIcon;
    public Image Icon;

    public TMP_Text MainName;
    public TMP_Text Period;
    public TMP_Text Amount;
    public TMP_Text Detail;

    Image DefultLowerBackGround;
    Image DefultBackGround;
    Image DefultBackGroundIcon;
    Image DefultIcon;

    public InventorySlotMaterial NowMaterial;

    public int id;

    string Text_Amount;

    public void ChangeLanguageToDefault()
    {
        Text_Amount = "";
    }

    public void ChangeLanguageToEnglish()
    {
        Text_Amount = "Amount : ";
    }

    public void ChangeLanguageToThai()
    {
        Text_Amount = "จำนวน : ";
    }
    
    private void Start() 
    {
        NowMaterial = null;
        DefultLowerBackGround = LowerBackGround;
        DefultBackGround = BackGround;
        DefultBackGroundIcon = BackGroundIcon;
        DefultIcon = Icon;

        ClearPanel();
    }

    public void ClearPanel()
    {
        MainName.text = "Error 154";

        LowerBackGround = DefultBackGround;
        BackGround = DefultBackGround;
        DefultBackGroundIcon = BackGroundIcon;
        Icon = DefultIcon;
        Icon.color = Color.white;
        Icon.sprite = null;
        BackGroundIcon.sprite = null;

        Amount.text = "Amount : 99";
        Detail.text = "   I don't know";
    }
    public void UpdateAuto()
    {
        if(NowMaterial != null) UpdatePanel(NowMaterial);
    }

    public void UpdatePanel(InventorySlotMaterial InventorySlotMaterial)
    {
        NowMaterial = InventorySlotMaterial;
        ClearPanel();

        if(InventorySlotMaterial.ItemMaterial.EverHave) 
        {
            Icon.color = Color.white;
            
            id = InventorySlotMaterial.ItemMaterial.ID;

            int NewID = InventorySlotMaterial.ItemMaterial.ID;
            Sprite NewIcon = InventorySlotMaterial.ItemMaterial.Icon;
            string NewMainName = InventorySlotMaterial.ItemMaterial.Name;
            string NewPeriod = InventorySlotMaterial.ItemMaterial.Period;
            string NewDetail = InventorySlotMaterial.ItemMaterial.Detail;

            string NewAmount = "";

            if(InventorySlotMaterial.ReturnAmountToLong(out long amountNumberUpgrade))
            {
                NewAmount = amountNumberUpgrade.ToString();
            }
            else{
                NewAmount = InventorySlotMaterial.ItemMaterial.NumberAmount.ToString("F2")  + multiple[InventorySlotMaterial.ItemMaterial.MultiplierAmount];
            }

            MainName.text = NewMainName;
            Period.text = NewPeriod;
            Icon.sprite = NewIcon;
            Amount.text = Text_Amount + NewAmount;
            Detail.text = "   " + NewDetail;
        }
        
        else 
        {
            Icon.color = Color.black;

            MainName.text = "???????";
            Period.text = "?? ???";
            Icon.sprite = InventorySlotMaterial.ItemMaterial.Icon;
            Amount.text = Text_Amount + "@#*&^$";
            Detail.text = "   " + "?????????????????????????????????????????????????????????????????????????";
        }
        
        

    }
}