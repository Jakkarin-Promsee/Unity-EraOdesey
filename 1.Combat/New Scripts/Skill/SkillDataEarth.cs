using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Earth")]
[System.Serializable]
public class SkillDataEarth : ScriptableObject
{
    //***************************************************************************************************
    //Input Data Use to setup each object
    [Header ("Input Main Data")]
    public GameObject SkillEffect;
    public Sprite Icon;
    public int ID = -1;
    public long AmountToUpgrade = 0;
    public double Cooldown = 0;

    [Header ("Input English Detail")]
    public string English_TypeDamage = "";
    public string English_LevelName = "";
    public string English_Name = "";
    [TextArea(2,4)] public string English_Detail = "";

    [Header ("Input Thai Detail")]
    public string Thai_TypeDamage = "";
    public string Thai_LevelName = "";
    public string Thai_Name = "";
    [TextArea(2,4)] public string Thai_Detail = "";

    [Header ("Description")]
    [TextArea(2,2)] public string Description = "";
    
    //***************************************************************************************************
    //Auto Data && Data that keep with json file
    [Header ("**Do not Input** It's a Auto Data")]
    public bool Active = false;
    public double CurrentCooldown = 0;
    public long Level = 0;
    public long Amount = 0;

    //***************************************************************************************************
    //Manual Data use to display player
    public string TypeDamage = "";
    public string LevelName = "";
    public string Name = "";
    [TextArea(2,4)] public string Detail = "";

    private void Awake() {
        Description = "------------- Ending input Data -------------";
    }
}
