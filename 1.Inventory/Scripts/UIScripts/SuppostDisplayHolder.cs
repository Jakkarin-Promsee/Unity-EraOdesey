using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SuppostDisplayHolder
{
    [SerializeField] public StaticDisplayHolder staticDisplayHolder;
    public StaticDisplayHolder StaticDisplayHolder => staticDisplayHolder;
    [SerializeField] [TextArea(2,4)] private string Description;

    
    public bool ShowCountNumberLong = false,
    CountFromMoreToLess = false,
     IsMaterial = false,
      IsWeapon = false,
       IsSword = false,
        IsHat = false,
         IsShirt = false ,
          IsPant = false,
           IsShoe = false;
    
    public void ChangeTypeSHowItemFromSuppostHolder()
    {
        staticDisplayHolder.staticDisplay.ChangeTypeShowItem(ShowCountNumberLong, CountFromMoreToLess ,IsMaterial, IsWeapon, IsSword, IsHat, IsShirt, IsPant, IsShoe);
    }
}
