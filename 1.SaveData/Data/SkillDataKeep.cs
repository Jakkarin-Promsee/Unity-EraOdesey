using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillDataKeep
{
    [SerializeField] public bool Active = false;
    [SerializeField] public long Level = 0;
    [SerializeField] public long Amount = 0;
    [SerializeField] public long AmountToUpgrade = 0;

    public void SaveNewData(SkillSlotEarth skillData)
    {
        Active = skillData.skillDataEarth.Active;
        Level = skillData.skillDataEarth.Level;
        Amount = skillData.skillDataEarth.Amount;
        AmountToUpgrade = skillData.skillDataEarth.AmountToUpgrade;
    }
    public void SaveNewData(SkillSlotFire skillData)
    {
        Active = skillData.skillDataFire.Active;
        Level = skillData.skillDataFire.Level;
        Amount = skillData.skillDataFire.Amount;
        AmountToUpgrade = skillData.skillDataFire.AmountToUpgrade;
    }

    public void SaveNewData(SkillSlotFrost skillData)
    {
        Active = skillData.skillDataFrost.Active;
        Level = skillData.skillDataFrost.Level;
        Amount = skillData.skillDataFrost.Amount;
        AmountToUpgrade = skillData.skillDataFrost.AmountToUpgrade;
    }

    public void SaveNewData(SkillSlotWater skillData)
    {
        Active = skillData.skillDataWater.Active;
        Level = skillData.skillDataWater.Level;
        Amount = skillData.skillDataWater.Amount;
        AmountToUpgrade = skillData.skillDataWater.AmountToUpgrade;
    }

    public void NewData()
    {
        Active = false;
        Level = 0;
        Amount = 0;
        AmountToUpgrade = 0;

    }

}
