using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StaticDisplayHolder : MonoBehaviour
{
    [SerializeField] public StaticDisplay staticDisplay;

    public StaticDisplay StaticDisplay => staticDisplay;


    private void Start() {
        StaticDisplay.ClearSlot();
    }

    float CountTime = 0.25f;
    float MaxCountTime = 0.25f;
    private void Update() {
        if(CountTime < MaxCountTime) CountTime+=Time.deltaTime;
        else{
            //Debug.Log(CountTime);
            CountTime = 0;
            staticDisplay.CheckInventorySlotUIOnClick();
        }
    }

/*

    private void Update() {
        staticDisplay.UpdateSlot();
    }
*/
}
