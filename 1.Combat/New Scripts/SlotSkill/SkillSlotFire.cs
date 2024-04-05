using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillSlotFire
{
    [SerializeField] public SkillDataFire skillDataFire;
    [SerializeField] [TextArea(2,4)] private string Description;
    public SkillDataFire SkillDataFire => skillDataFire;

    public void Load(SkillDataKeep data)
    {
        skillDataFire.Active = data.Active;
        skillDataFire.Level = data.Level;
        skillDataFire.Amount = data.Amount;
        skillDataFire.AmountToUpgrade = data.AmountToUpgrade;
    }

    public void ActivateSkill()
    {
        skillDataFire.Active = true;
    }

    public void Clear()
    {
        skillDataFire.Active = false;
        skillDataFire.Level=0;
    }

    public void ResetCurrentCooldonw()
    {
        skillDataFire.CurrentCooldown = 0;
    }

    public void ReCurrentCooldonw()
    {
        skillDataFire.CurrentCooldown = skillDataFire.Cooldown;
    }

    public void DecreaseCurrentCooldown(float DecreaseTime)
    {
        bool IsZero = skillDataFire.CurrentCooldown <= 0;
        if(IsZero) skillDataFire.CurrentCooldown = 0;
        else skillDataFire.CurrentCooldown -= DecreaseTime;
    }

    public void IncreaseCurrentCooldown(float IncreaseTime)
    {
        skillDataFire.CurrentCooldown += IncreaseTime;
    }

    public void UpLevel()
    {
        if(skillDataFire.Amount >= skillDataFire.AmountToUpgrade)
        {
            skillDataFire.Amount -= skillDataFire.AmountToUpgrade;
            skillDataFire.Level += 1;
        }
    }
}
