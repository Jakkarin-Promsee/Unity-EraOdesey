using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForUpgradeButtom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PopUPInformationForCraft popUPInformationForCraft;
    float TimeCount;
    float MaxTimeCount;
    public bool real = false;
    public bool isButtonHeld = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonHeld = false;
    }

    

    private void Update() {
        if(isButtonHeld==false)
        {
            TimeCount = 0.35f;
            MaxTimeCount = 0.35f;
        }
        else
        {
            if(TimeCount<MaxTimeCount) TimeCount+=Time.deltaTime;
            else 
            {
                TimeCount = 0f;
                if(MaxTimeCount>0.01) MaxTimeCount-=0.005f;
                if(MaxTimeCount<0) MaxTimeCount = 0.001f;

                if(MaxTimeCount==0.001) {
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                }
                if(MaxTimeCount<0.01) {
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                }
                if(MaxTimeCount<0.1) {
                    popUPInformationForCraft.CraftItem();
                    popUPInformationForCraft.CraftItem();
                }
                else popUPInformationForCraft.CraftItem();
            }
        }
        
    }
}
