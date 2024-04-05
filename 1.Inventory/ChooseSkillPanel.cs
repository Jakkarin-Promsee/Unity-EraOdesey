using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSkillPanel : MonoBehaviour
{
    public GameObject Ch;
    public PopUPSkill popUPSkill;
    public DisplayControl displayControl;

    public GameObject[] SlotImage;

    private void Awake() {
        Clear();
        
    }

    private void Update() {
        ActivateImage();
    }

    public void ActivateImage()
    {
        for(int i=0; i<displayControl.listDisplay.Count; i++){
            if(displayControl.listDisplay[i].IsUse && i < SlotImage.Length) 
            {
                SlotImage[i].SetActive(true);
            }
        }
    }

    public void Clear()
    {
        for(int i=0; i<SlotImage.Length; i++)
        {
            SlotImage[i].SetActive(false);
        }
    }

    public void ImageWasClecked(int i)
    {
        

        displayControl.listDisplay[i].ClearAllDataSkill();

        displayControl.listDisplay[i].IsActivate = true;
        displayControl.listDisplay[i].IsUse = true;
        displayControl.listDisplay[i].NumberOfSkill = popUPSkill.ID;
        
        if(popUPSkill.KeepTypeOfSkill == 0) displayControl.listDisplay[i].IsEarthSkill = true;
        if(popUPSkill.KeepTypeOfSkill == 1) displayControl.listDisplay[i].IsFireSkill = true;
        if(popUPSkill.KeepTypeOfSkill == 2) displayControl.listDisplay[i].IsFrostSkill = true;
        if(popUPSkill.KeepTypeOfSkill == 3) displayControl.listDisplay[i].IsWaterSkill = true;

        for(int ii=0; ii<displayControl.listDisplay.Count; ii++)
        {
            if(ii!=i && displayControl.listDisplay[ii].IsActivate)
            {
                bool IsDuplicate = displayControl.listDisplay[i].IsEarthSkill == displayControl.listDisplay[ii].IsEarthSkill &&
                                   displayControl.listDisplay[i].IsFireSkill == displayControl.listDisplay[ii].IsFireSkill &&
                                   displayControl.listDisplay[i].IsFrostSkill == displayControl.listDisplay[ii].IsFrostSkill &&
                                   displayControl.listDisplay[i].IsWaterSkill == displayControl.listDisplay[ii].IsWaterSkill &&
                                   displayControl.listDisplay[i].NumberOfSkill == displayControl.listDisplay[ii].NumberOfSkill &&
                                   displayControl.listDisplay[i].IsActivate == displayControl.listDisplay[ii].IsActivate &&
                                   displayControl.listDisplay[i].IsUse == displayControl.listDisplay[ii].IsUse;
                if(IsDuplicate)
                {
                    Debug.Log("Dulicate");
                    displayControl.listDisplay[ii].ClearAllDataSkill();

                    displayControl.listDisplay[ii].IsActivate = false;
                    displayControl.listDisplay[ii].IsUse = true;
                }
            }
        }

        Ch.SetActive(false);
        popUPSkill.Flashing.SetActive(false);
        popUPSkill.FlashingBackground.SetActive(false);
    }
}
