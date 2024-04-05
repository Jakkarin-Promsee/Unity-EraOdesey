using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListSlotSkillFrost
{
    [SerializeField] public List<SkillSlotFrost> listSkillSlotFrosts;
    public List<SkillSlotFrost> ListSkillSlotFrosts => listSkillSlotFrosts;

    public void ActivateSkillAllSkill()
    {
        for(int i=0; i<listSkillSlotFrosts.Count; i++)
        {
            listSkillSlotFrosts[i].ActivateSkill();
        }
    }

    public void ClearAllSkill()
    {
        for(int i=0; i<listSkillSlotFrosts.Count; i++)
        {
            listSkillSlotFrosts[i].Clear();
        }
    }

    public void ResetCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotFrosts.Count; i++)
        {
            listSkillSlotFrosts[i].ResetCurrentCooldonw();
        }
    }

    public void ReCurrentCooldonwAllSkill()
    {
        for(int i=0; i<listSkillSlotFrosts.Count; i++)
        {
            listSkillSlotFrosts[i].ReCurrentCooldonw();
        }
    }

    public void DecreaseCurrentCooldownAllSkill(float DecreaseTime)
    {
        for(int i=0; i<listSkillSlotFrosts.Count; i++)
        {
            listSkillSlotFrosts[i].DecreaseCurrentCooldown(DecreaseTime);
        }
    }

    public void IncreaseCurrentCooldownAllSkill(float IncreaseTime)
    {
        for(int i=0; i<listSkillSlotFrosts.Count; i++)
        {
            listSkillSlotFrosts[i].IncreaseCurrentCooldown(IncreaseTime);
        }
    }
}
