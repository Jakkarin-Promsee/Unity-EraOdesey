using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListSlotSkillFire
{
    [SerializeField] public List<SkillSlotFire> listSkillSlotFires;
    public List<SkillSlotFire> ListSkillSlotFires => listSkillSlotFires;

    public void ActivateSkillAllSkill()
    {
        for(int i=0; i<listSkillSlotFires.Count; i++)
        {
            listSkillSlotFires[i].ActivateSkill();
        }
    }

    public void ClearAllSkill()
    {
        for(int i=0; i<listSkillSlotFires.Count; i++)
        {
            listSkillSlotFires[i].Clear();
        }
    }
    
    public void ResetCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotFires.Count; i++)
        {
            listSkillSlotFires[i].ResetCurrentCooldonw();
        }
    }

    public void ReCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotFires.Count; i++)
        {
            listSkillSlotFires[i].ReCurrentCooldonw();
        }
    }

    public void DecreaseCurrentCooldownAllSkill(float DecreaseTime)
    {
        for(int i=0; i<listSkillSlotFires.Count; i++)
        {
            listSkillSlotFires[i].DecreaseCurrentCooldown(DecreaseTime);
        }
    }

    public void IncreaseCurrentCooldownAllSkill(float IncreaseTime)
    {
        for(int i=0; i<listSkillSlotFires.Count; i++)
        {
            listSkillSlotFires[i].IncreaseCurrentCooldown(IncreaseTime);
        }
    }
}
