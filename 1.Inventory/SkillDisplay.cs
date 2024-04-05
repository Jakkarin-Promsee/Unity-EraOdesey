using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillDisplay : MonoBehaviour
{
    public InventoryAllHolder inventoryAllHolder;
    public PlayerMainController playerMainController;
    public SkillSlotUI[] SlotUI;

    private void Start() {
        for(int i=0; i<SlotUI.Length; i++)
        {
            SlotUI[i].ClearSlot();
        }
    }

    float CountTime = 0.25f;
    float MaxCountTime = 0.25f;

    private void Update() {
        if(CountTime < MaxCountTime) CountTime+=Time.deltaTime;
        else{
            CountTime = 0;
            CheckSkilSlotUIOnClick();
            UpdateSlot();
        }
    }

    public void CheckSkilSlotUIOnClick()
    {
        for(int i=0; i<SlotUI.Length; i++)
        {
            if(SlotUI[i].IsClick)
            {
                if(SlotUI[i].TypeSkill == 0)
                {
                    SkillSlotEarth skillSlotEarth = playerMainController.skillAllSystem.skillEarth.listSkillSlotEarths[SlotUI[i].ID];
                    inventoryAllHolder.InventoryAllItemSystem.popUPSkill.UpdatePanel(0, skillSlotEarth, null, null, null);
                }
                else if(SlotUI[i].TypeSkill == 1)
                {
                    SkillSlotFire skillSlotFire = playerMainController.skillAllSystem.skillFire.ListSkillSlotFires[SlotUI[i].ID];
                    inventoryAllHolder.InventoryAllItemSystem.popUPSkill.UpdatePanel(1, null, skillSlotFire, null, null);
                }
                else if(SlotUI[i].TypeSkill == 2)
                {
                    SkillSlotFrost skillSlotFrost = playerMainController.skillAllSystem.skillFrost.ListSkillSlotFrosts[SlotUI[i].ID];
                    inventoryAllHolder.InventoryAllItemSystem.popUPSkill.UpdatePanel(2, null, null, skillSlotFrost, null);
                }
                else if(SlotUI[i].TypeSkill == 3)
                {
                    SkillSlotWater skillSlotWater = playerMainController.skillAllSystem.skillWater.ListSkillSlotWaters[SlotUI[i].ID];
                    inventoryAllHolder.InventoryAllItemSystem.popUPSkill.UpdatePanel(3, null, null, null, skillSlotWater);
                }
                SlotUI[i].IsClick = false;
                inventoryAllHolder.InventoryAllItemSystem.SkillPopUP.SetActive(true);
            }
            
        }
    }

    public void UpdateSlot()
    {
        for(int i=0; i<SlotUI.Length; i++)
        {
            int Tp = i%4;
            int ID = (int)(i/4);
            if(Tp==3)
            {
                SkillSlotEarth skillSlotEarth = playerMainController.skillAllSystem.skillEarth.listSkillSlotEarths[ID];
                if(skillSlotEarth.skillDataEarth.Active)
                {
                    int newID = skillSlotEarth.skillDataEarth.ID;
                    int newTypeSkill = 0;
                    Sprite newImageSkill = skillSlotEarth.skillDataEarth.Icon; 
                    long newLevel = skillSlotEarth.skillDataEarth.Level;
                    long newAmount = skillSlotEarth.skillDataEarth.Amount;
                    long newAmountToUpgrade = skillSlotEarth.skillDataEarth.AmountToUpgrade;

                    SlotUI[i].UpdateSlot(newID, newTypeSkill, newImageSkill, newLevel, newAmount, newAmountToUpgrade);
                }
            }

            else if(Tp==0)
            {
                SkillSlotFire skillSlotFire = playerMainController.skillAllSystem.skillFire.listSkillSlotFires[ID];
                if(skillSlotFire.skillDataFire.Active)
                {
                    int newID = skillSlotFire.skillDataFire.ID;
                    int newTypeSkill = 1;
                    Sprite newImageSkill = skillSlotFire.skillDataFire.Icon; 
                    long newLevel = skillSlotFire.skillDataFire.Level;
                    long newAmount = skillSlotFire.skillDataFire.Amount;
                    long newAmountToUpgrade = skillSlotFire.skillDataFire.AmountToUpgrade;

                    SlotUI[i].UpdateSlot(newID, newTypeSkill, newImageSkill, newLevel, newAmount, newAmountToUpgrade);
                }
            }
            else if(Tp==2)
            {
                SkillSlotFrost skillSlotFrost = playerMainController.skillAllSystem.skillFrost.listSkillSlotFrosts[ID];
                if(skillSlotFrost.skillDataFrost.Active)
                {
                    int newID = skillSlotFrost.skillDataFrost.ID;
                    int newTypeSkill = 2;
                    Sprite newImageSkill = skillSlotFrost.skillDataFrost.Icon; 
                    long newLevel = skillSlotFrost.skillDataFrost.Level;
                    long newAmount = skillSlotFrost.skillDataFrost.Amount;
                    long newAmountToUpgrade = skillSlotFrost.skillDataFrost.AmountToUpgrade;

                    SlotUI[i].UpdateSlot(newID, newTypeSkill, newImageSkill, newLevel, newAmount, newAmountToUpgrade);
                }
            }
            else if(Tp==1)
            {
                SkillSlotWater skillSlotWater = playerMainController.skillAllSystem.skillWater.listSkillSlotWaters[ID];
                if(skillSlotWater.skillDataWater.Active)
                {
                    int newID = skillSlotWater.skillDataWater.ID;
                    int newTypeSkill =3;
                    Sprite newImageSkill = skillSlotWater.skillDataWater.Icon; 
                    long newLevel = skillSlotWater.skillDataWater.Level;
                    long newAmount = skillSlotWater.skillDataWater.Amount;
                    long newAmountToUpgrade = skillSlotWater.skillDataWater.AmountToUpgrade;

                    SlotUI[i].UpdateSlot(newID, newTypeSkill, newImageSkill, newLevel, newAmount, newAmountToUpgrade);
                }
            }
        }
    }
}
