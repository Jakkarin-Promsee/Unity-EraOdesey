using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillSlotWater
{
    [SerializeField] public SkillDataWater skillDataWater;
    [SerializeField] [TextArea(2,4)] private string Description;
    public SkillDataWater SkillDataWater => skillDataWater;

    public void Load(SkillDataKeep data)
    {
        skillDataWater.Active = data.Active;
        skillDataWater.Level = data.Level;
        skillDataWater.Amount = data.Amount;
        skillDataWater.AmountToUpgrade = data.AmountToUpgrade;
    }

    public void ActivateSkill()
    {
        skillDataWater.Active = true;
    }

    public void Clear()
    {
        skillDataWater.Active = false;
        skillDataWater.Level=0;
    }

    public void ResetCurrentCooldonw()
    {
        skillDataWater.CurrentCooldown = 0;
    }

    public void ReCurrentCooldonw()
    {
        skillDataWater.CurrentCooldown = skillDataWater.Cooldown;
    }

    public void DecreaseCurrentCooldown(float DecreaseTime)
    {
        bool IsZero = skillDataWater.CurrentCooldown <= 0;
        if(IsZero) skillDataWater.CurrentCooldown = 0;
        else skillDataWater.CurrentCooldown -= DecreaseTime;
    }

    public void IncreaseCurrentCooldown(float IncreaseTime)
    {
        skillDataWater.CurrentCooldown += IncreaseTime;
    }

    public void UpLevel()
    {
        if(skillDataWater.Amount >= skillDataWater.AmountToUpgrade)
        {
            skillDataWater.Amount -= skillDataWater.AmountToUpgrade;
            skillDataWater.Level += 1;
        }
    }
}
