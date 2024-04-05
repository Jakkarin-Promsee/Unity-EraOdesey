using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillSlotFrost
{
    [SerializeField] public SkillDataFrost skillDataFrost;
    [SerializeField] [TextArea(2,4)] private string Description;
    public SkillDataFrost SkillDataFrost => skillDataFrost;

    public void Load(SkillDataKeep data)
    {
        skillDataFrost.Active = data.Active;
        skillDataFrost.Level = data.Level;
        skillDataFrost.Amount = data.Amount;
        skillDataFrost.AmountToUpgrade = data.AmountToUpgrade;
    }

    public void ActivateSkill()
    {
        skillDataFrost.Active = true;
    }

    public void Clear()
    {
        skillDataFrost.Active = false;
        skillDataFrost.Level=0;
    }

    public void ResetCurrentCooldonw()
    {
        skillDataFrost.CurrentCooldown = 0;
    }

    public void ReCurrentCooldonw()
    {
        skillDataFrost.CurrentCooldown = skillDataFrost.Cooldown;
    }

    public void DecreaseCurrentCooldown(float DecreaseTime)
    {
        bool IsZero = skillDataFrost.CurrentCooldown <= 0;
        if(IsZero) skillDataFrost.CurrentCooldown = 0;
        else skillDataFrost.CurrentCooldown -= DecreaseTime;
    }

    public void IncreaseCurrentCooldown(float IncreaseTime)
    {
        skillDataFrost.CurrentCooldown += IncreaseTime;
    }

    public void UpLevel()
    {
        if(skillDataFrost.Amount >= skillDataFrost.AmountToUpgrade)
        {
            skillDataFrost.Amount -= skillDataFrost.AmountToUpgrade;
            skillDataFrost.Level += 1;
        }
    }
}
