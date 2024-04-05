using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListSlotSkillEarth
{
    [SerializeField] public List<SkillSlotEarth> listSkillSlotEarths;
    public List<SkillSlotEarth> ListSkillSlotEarths => listSkillSlotEarths;

    public void ActivateSkillAllSkill()
    {
        for(int i=0; i<listSkillSlotEarths.Count; i++)
        {
            listSkillSlotEarths[i].ActivateSkill();
        }
    }

    public void ClearAllSkill()
    {
        for(int i=0; i<listSkillSlotEarths.Count; i++)
        {
            listSkillSlotEarths[i].Clear();
        }
    }

    public void ResetCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotEarths.Count; i++)
        {
            listSkillSlotEarths[i].ResetCurrentCooldonw();
        }
    }

    public void ReCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotEarths.Count; i++)
        {
            listSkillSlotEarths[i].ReCurrentCooldonw();
        }
    }

    public void DecreaseCurrentCooldownAllSkill(float DecreaseTime)
    {
        for(int i=0; i<listSkillSlotEarths.Count; i++)
        {
            listSkillSlotEarths[i].DecreaseCurrentCooldown(DecreaseTime);
        }
    }

    public void IncreaseCurrentCooldownAllSkill(float IncreaseTime)
    {
        for(int i=0; i<listSkillSlotEarths.Count; i++)
        {
            listSkillSlotEarths[i].IncreaseCurrentCooldown(IncreaseTime);
        }
    }

}
