using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillAllSystem
{
    [SerializeField] public ListSlotSkillEarth skillEarth; 
    public ListSlotSkillEarth SkillEarth => skillEarth;

    [SerializeField] public ListSlotSkillFire skillFire;
    public ListSlotSkillFire SkillFire => skillFire;

    [SerializeField] public ListSlotSkillFrost skillFrost;
    public ListSlotSkillFrost SkillFrost => skillFrost;

    [SerializeField] public ListSlotSkillWater skillWater;
    public ListSlotSkillWater SkillWater => skillWater;

    public int LengthEarthSlot = 0,
    LengthFireSlot = 0,
    LengthFrostSlot = 0,
    LengthWaterSlot = 0;

    public void ChangeLanguageToDefault()
    {
        for(int i=0; i<skillEarth.listSkillSlotEarths.Count; i++)
        {
            skillEarth.listSkillSlotEarths[i].skillDataEarth.TypeDamage = "";
            skillEarth.listSkillSlotEarths[i].skillDataEarth.LevelName = "";
            skillEarth.listSkillSlotEarths[i].skillDataEarth.Name = "";
            skillEarth.listSkillSlotEarths[i].skillDataEarth.Detail = "";
        }

        for(int i=0; i<skillFire.listSkillSlotFires.Count; i++)
        {
            skillFire.listSkillSlotFires[i].skillDataFire.TypeDamage = "";
            skillFire.listSkillSlotFires[i].skillDataFire.LevelName = "";
            skillFire.listSkillSlotFires[i].skillDataFire.Name = "";
            skillFire.listSkillSlotFires[i].skillDataFire.Detail = "";
        }

        for(int i=0; i<skillFrost.listSkillSlotFrosts.Count; i++)
        {
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.TypeDamage = "";
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.LevelName = "";
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.Name = "";
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.Detail = "";
        }

        for(int i=0; i<skillWater.listSkillSlotWaters.Count; i++)
        {
            skillWater.ListSkillSlotWaters[i].skillDataWater.TypeDamage = "";
            skillWater.ListSkillSlotWaters[i].skillDataWater.LevelName = "";
            skillWater.ListSkillSlotWaters[i].skillDataWater.Name = "";
            skillWater.ListSkillSlotWaters[i].skillDataWater.Detail = "";
        }
    }

    public void ChangeLanguageToEnglish()
    {
        for(int i=0; i<skillEarth.listSkillSlotEarths.Count; i++)
        {
            skillEarth.listSkillSlotEarths[i].skillDataEarth.TypeDamage = skillEarth.listSkillSlotEarths[i].skillDataEarth.English_TypeDamage;
            skillEarth.listSkillSlotEarths[i].skillDataEarth.LevelName = skillEarth.listSkillSlotEarths[i].skillDataEarth.English_LevelName;
            skillEarth.listSkillSlotEarths[i].skillDataEarth.Name = skillEarth.listSkillSlotEarths[i].skillDataEarth.English_Name;
            skillEarth.listSkillSlotEarths[i].skillDataEarth.Detail = skillEarth.listSkillSlotEarths[i].skillDataEarth.English_Detail;
        }

        for(int i=0; i<skillFire.listSkillSlotFires.Count; i++)
        {
            skillFire.listSkillSlotFires[i].skillDataFire.TypeDamage = skillFire.listSkillSlotFires[i].skillDataFire.English_TypeDamage;
            skillFire.listSkillSlotFires[i].skillDataFire.LevelName = skillFire.listSkillSlotFires[i].skillDataFire.English_LevelName;
            skillFire.listSkillSlotFires[i].skillDataFire.Name = skillFire.listSkillSlotFires[i].skillDataFire.English_Name;
            skillFire.listSkillSlotFires[i].skillDataFire.Detail = skillFire.listSkillSlotFires[i].skillDataFire.English_Detail;
        }

        for(int i=0; i<skillFrost.listSkillSlotFrosts.Count; i++)
        {
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.TypeDamage = skillFrost.listSkillSlotFrosts[i].skillDataFrost.English_TypeDamage;
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.LevelName = skillFrost.listSkillSlotFrosts[i].skillDataFrost.English_LevelName;
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.Name = skillFrost.listSkillSlotFrosts[i].skillDataFrost.English_Name;
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.Detail = skillFrost.listSkillSlotFrosts[i].skillDataFrost.English_Detail;
        }

        for(int i=0; i<skillWater.listSkillSlotWaters.Count; i++)
        {
            skillWater.ListSkillSlotWaters[i].skillDataWater.TypeDamage = skillWater.ListSkillSlotWaters[i].skillDataWater.English_TypeDamage;
            skillWater.ListSkillSlotWaters[i].skillDataWater.LevelName = skillWater.ListSkillSlotWaters[i].skillDataWater.English_LevelName;
            skillWater.ListSkillSlotWaters[i].skillDataWater.Name = skillWater.ListSkillSlotWaters[i].skillDataWater.English_Name;
            skillWater.ListSkillSlotWaters[i].skillDataWater.Detail = skillWater.ListSkillSlotWaters[i].skillDataWater.English_Detail;
        }
    }

    public void ChangeLanguageToThai()
    {
        for(int i=0; i<skillEarth.listSkillSlotEarths.Count; i++)
        {
            skillEarth.listSkillSlotEarths[i].skillDataEarth.TypeDamage = skillEarth.listSkillSlotEarths[i].skillDataEarth.Thai_TypeDamage;
            skillEarth.listSkillSlotEarths[i].skillDataEarth.LevelName = skillEarth.listSkillSlotEarths[i].skillDataEarth.Thai_LevelName;
            skillEarth.listSkillSlotEarths[i].skillDataEarth.Name = skillEarth.listSkillSlotEarths[i].skillDataEarth.Thai_Name;
            skillEarth.listSkillSlotEarths[i].skillDataEarth.Detail = skillEarth.listSkillSlotEarths[i].skillDataEarth.Thai_Detail;
        }

        for(int i=0; i<skillFire.listSkillSlotFires.Count; i++)
        {
            skillFire.listSkillSlotFires[i].skillDataFire.TypeDamage = skillFire.listSkillSlotFires[i].skillDataFire.Thai_TypeDamage;
            skillFire.listSkillSlotFires[i].skillDataFire.LevelName = skillFire.listSkillSlotFires[i].skillDataFire.Thai_LevelName;
            skillFire.listSkillSlotFires[i].skillDataFire.Name = skillFire.listSkillSlotFires[i].skillDataFire.Thai_Name;
            skillFire.listSkillSlotFires[i].skillDataFire.Detail = skillFire.listSkillSlotFires[i].skillDataFire.Thai_Detail;
        }

        for(int i=0; i<skillFrost.listSkillSlotFrosts.Count; i++)
        {
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.TypeDamage = skillFrost.listSkillSlotFrosts[i].skillDataFrost.Thai_TypeDamage;
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.LevelName = skillFrost.listSkillSlotFrosts[i].skillDataFrost.Thai_LevelName;
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.Name = skillFrost.listSkillSlotFrosts[i].skillDataFrost.Thai_Name;
            skillFrost.listSkillSlotFrosts[i].skillDataFrost.Detail = skillFrost.listSkillSlotFrosts[i].skillDataFrost.Thai_Detail;
        }

        for(int i=0; i<skillWater.listSkillSlotWaters.Count; i++)
        {
            skillWater.ListSkillSlotWaters[i].skillDataWater.TypeDamage = skillWater.ListSkillSlotWaters[i].skillDataWater.Thai_TypeDamage;
            skillWater.ListSkillSlotWaters[i].skillDataWater.LevelName = skillWater.ListSkillSlotWaters[i].skillDataWater.Thai_LevelName;
            skillWater.ListSkillSlotWaters[i].skillDataWater.Name = skillWater.ListSkillSlotWaters[i].skillDataWater.Thai_Name;
            skillWater.ListSkillSlotWaters[i].skillDataWater.Detail = skillWater.ListSkillSlotWaters[i].skillDataWater.Thai_Detail;
        }
    }

    public void UpdateLengthSlot()
    {
        LengthEarthSlot = skillEarth.listSkillSlotEarths.Count;
        LengthFireSlot = skillFire.ListSkillSlotFires.Count;
        LengthFrostSlot = skillFrost.listSkillSlotFrosts.Count;
        LengthWaterSlot = skillWater.listSkillSlotWaters.Count;
    }

    public void ActivateSkillAt(int i)
    {
        skillEarth.listSkillSlotEarths[i].ActivateSkill();
        skillFire.listSkillSlotFires[i].ActivateSkill();
        skillFrost.listSkillSlotFrosts[i].ActivateSkill();
        skillWater.listSkillSlotWaters[i].ActivateSkill();
    }
    public void ClearAllSkillAllElement()
    {
        skillEarth.ClearAllSkill();
        skillFire.ClearAllSkill();
        skillFrost.ClearAllSkill();
        skillWater.ClearAllSkill();
    }

    public void ResetCurrentCooldonwAllSkillAllElement()
    {
        skillEarth.ResetCurrentCooldonwAllSkill();
        skillFire.ResetCurrentCooldonwAllSkill();
        skillFrost.ResetCurrentCooldonwAllSkill();
        skillWater.ResetCurrentCooldonwAllSkill();
    }

    public void ReCurrentCooldonwAllSkillAllElement()
    {
        skillEarth.ReCurrentCooldonwAllSkill();
        skillFire.ReCurrentCooldonwAllSkill();
        skillFrost.ReCurrentCooldonwAllSkill();
        skillWater.ReCurrentCooldonwAllSkill();
    }

    public void DecreaseCurrentCooldownAllSkillAllElement(float DecreaseTime)
    {
        skillEarth.DecreaseCurrentCooldownAllSkill(DecreaseTime);
        skillFire.DecreaseCurrentCooldownAllSkill(DecreaseTime);
        skillFrost.DecreaseCurrentCooldownAllSkill(DecreaseTime);
        skillWater.DecreaseCurrentCooldownAllSkill(DecreaseTime);
    }

    public void IncreaseCurrentCooldownAllSkillAllElement(float IncreaseTime)
    {
        skillEarth.IncreaseCurrentCooldownAllSkill(IncreaseTime);
        skillFire.IncreaseCurrentCooldownAllSkill(IncreaseTime);
        skillFrost.IncreaseCurrentCooldownAllSkill(IncreaseTime);
        skillWater.IncreaseCurrentCooldownAllSkill(IncreaseTime);
    }
}
