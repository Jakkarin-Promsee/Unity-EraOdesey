using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListSlotSkillWater
{
    [SerializeField] public List<SkillSlotWater> listSkillSlotWaters;
    public List<SkillSlotWater> ListSkillSlotWaters => listSkillSlotWaters;

    public void ActivateSkillAllSkill()
    {
        for(int i=0; i<listSkillSlotWaters.Count; i++)
        {
            listSkillSlotWaters[i].ActivateSkill();
        }
    }

    public void ClearAllSkill()
    {
        for(int i=0; i<listSkillSlotWaters.Count; i++)
        {
            listSkillSlotWaters[i].Clear();
        }
    }

    public void ResetCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotWaters.Count; i++)
        {
            listSkillSlotWaters[i].ResetCurrentCooldonw();
        }
    }

    public void ReCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotWaters.Count; i++)
        {
            listSkillSlotWaters[i].ReCurrentCooldonw();
        }
    }

    public void DecreaseCurrentCooldownAllSkill(float DecreaseTime)
    {
        for(int i=0; i<listSkillSlotWaters.Count; i++)
        {
            listSkillSlotWaters[i].DecreaseCurrentCooldown(DecreaseTime);
        }
    }

    public void IncreaseCurrentCooldownAllSkill(float IncreaseTime)
    {
        for(int i=0; i<listSkillSlotWaters.Count; i++)
        {
            listSkillSlotWaters[i].IncreaseCurrentCooldown(IncreaseTime);
        }
    }
}
