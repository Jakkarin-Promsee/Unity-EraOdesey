using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillSlotEarth
{
    [SerializeField] public SkillDataEarth skillDataEarth;
    [SerializeField] [TextArea(2,4)] private string Description;
    public SkillDataEarth SkillDataEarth => skillDataEarth;

    public void Load(SkillDataKeep data)
    {
        skillDataEarth.Active = data.Active;
        skillDataEarth.Level = data.Level;
        skillDataEarth.Amount = data.Amount;
        skillDataEarth.AmountToUpgrade = data.AmountToUpgrade;
    }

    public void ActivateSkill()
    {
        skillDataEarth.Active = true;
    }

    public void Clear()
    {
        skillDataEarth.Active = false;
        skillDataEarth.Level=0;
    }

    public void ResetCurrentCooldonw()
    {
        skillDataEarth.CurrentCooldown = 0;
    }

    public void ReCurrentCooldonw()
    {
        skillDataEarth.CurrentCooldown = skillDataEarth.Cooldown;
    }

    public void DecreaseCurrentCooldown(float DecreaseTime)
    {
        bool IsZero = skillDataEarth.CurrentCooldown <= 0;
        if(IsZero) skillDataEarth.CurrentCooldown = 0;
        else skillDataEarth.CurrentCooldown -= DecreaseTime;
    }

    public void IncreaseCurrentCooldown(float IncreaseTime)
    {
        skillDataEarth.CurrentCooldown += IncreaseTime;
    }

    public void UpLevel()
    {
        if(skillDataEarth.Amount >= skillDataEarth.AmountToUpgrade)
        {
            skillDataEarth.Amount -= skillDataEarth.AmountToUpgrade;
            skillDataEarth.Level += 1;
        }
    }


}
