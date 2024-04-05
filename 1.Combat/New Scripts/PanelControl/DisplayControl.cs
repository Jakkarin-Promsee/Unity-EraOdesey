using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DisplayControl : MonoBehaviour, IDataPersistance
{
    public TMP_Text IsAuto;
    [SerializeField] public List<DisplayData> listDisplay;
    public PlayerMainController player;
    public List<DisplayData> ListDisplay => listDisplay;

    public bool IsAutoSkill = false;
    public bool IsAutoSkillTricker = false;
    public bool IsAutoSKillSum = false;


    double timeDelay = 10;
    double MaxtimeDelay = 10;
    double NormalAttacktimeDelay = 0.75;
    double NormalAttackMaxtimeDelay = 0.75;

    public void ChangeAutoSkill()
    {
        if(IsAutoSkill)
        {
            IsAutoSkill = false;
            IsAuto.text = "Off";
            IsAuto.color = Color.red;
        }
        else
        {
            IsAutoSkill = true;
            IsAuto.text = "On";
            IsAuto.color = Color.green;
        }
    }
    

    public void LoadData(GameData data)
    {
        for(int i=0; i<listDisplay.Count; i++)
        {
            listDisplay[i].Load(data.skillPanel[i]);
        }

        IsAutoSkill = data.IsAutoSkill;
        IsAutoSkillTricker = data.IsAutoSkillTricker;
        IsAutoSKillSum = data.IsAutoSKillSum;
    }

    public void SaveData(ref GameData data)
    {
        for(int i=0; i<listDisplay.Count; i++)
        {
            data.skillPanel[i].SaveNewData(listDisplay[i]);
        }

        data.IsAutoSkill = IsAutoSkill;
        data.IsAutoSkillTricker = IsAutoSkillTricker;
        data.IsAutoSKillSum = IsAutoSKillSum;
    }

    private void Start()
    {
        //clear all display
        //DisplayClear();
        player.skillAllSystem.ResetCurrentCooldonwAllSkillAllElement();
        player.skillAllSystem.UpdateLengthSlot();

        /*
        listDisplay[0].IsActivate = true;
        listDisplay[0].IsUse = true;
        listDisplay[0].IsFireSkill = true;
        listDisplay[0].NumberOfSkill = 0;

        listDisplay[1].IsActivate = true;
        listDisplay[1].IsUse = true;
        listDisplay[1].IsWaterSkill = true;
        listDisplay[1].NumberOfSkill = 0;
        
        listDisplay[2].IsActivate = true;
        listDisplay[2].IsUse = true;
        listDisplay[2].IsFrostSkill = true;
        listDisplay[2].NumberOfSkill = 0;

        listDisplay[3].IsActivate = true;
        listDisplay[3].IsUse = true;
        listDisplay[3].IsEarthSkill = true;
        listDisplay[3].NumberOfSkill = 0;
        */
    }

    public void SetActivate(int min, int max)
    {
        for(int i=min; i<max; i++)
        {
            //listDisplay[i].IsActivate = false;
            listDisplay[i].IsUse = true;
        }
    }

    float countTime = 0;
    private void Update() {
        
        countTime+=Time.deltaTime;

        if(countTime >= 0.25) {

            IsAutoSkillTricker = player.IsAutoSkillTrickerFromPlayer;
            IsAutoSKillSum = (IsAutoSkill && IsAutoSkillTricker);

            player.skillAllSystem.DecreaseCurrentCooldownAllSkillAllElement(countTime);

            if (timeDelay < MaxtimeDelay) timeDelay += countTime;
            else timeDelay = MaxtimeDelay;
           
            countTime = 0;
        }

        if (NormalAttacktimeDelay < NormalAttackMaxtimeDelay) NormalAttacktimeDelay += Time.deltaTime * player.TotalAttackSpeed;
        else NormalAttacktimeDelay = NormalAttackMaxtimeDelay;

        NormalAttackUse();
        DisplayUpdate();

        UpdateSlot();
    }

    public void UpdateSlot()
    {
        if (IsAutoSKillSum) AutoSkill();
        else CheckButtom();
    }
    



    public void DisplayUpdate()
    {
        for(int i=0; i<listDisplay.Count; i++){
            if(listDisplay[i].IsActivate && listDisplay[i].IsUse)
            {
                listDisplay[i].DefaultSkill();
                if(listDisplay[i].IsFireSkill)
                {
                    int NumberOfSkill = listDisplay[i].NumberOfSkill;
                    FireDisplayUpdate(i, NumberOfSkill);
                }

                if(listDisplay[i].IsEarthSkill)
                {
                    int NumberOfSkill = listDisplay[i].NumberOfSkill;
                    EarthDisplayUpdate(i, NumberOfSkill);
                }

                if(listDisplay[i].IsFrostSkill)
                {
                    int NumberOfSkill = listDisplay[i].NumberOfSkill;
                    FrostDisplayUpdate(i, NumberOfSkill);
                }

                if(listDisplay[i].IsWaterSkill)
                {
                    int NumberOfSkill = listDisplay[i].NumberOfSkill;
                    WaterDisplayUpdate(i, NumberOfSkill);
                }
            }
            else if(listDisplay[i].IsUse) listDisplay[i].FreeSkill();
            else listDisplay[i].LockSkill();
            
        }
    }

    public void DisplayClear()
    {
        for(int i=0; i<listDisplay.Count; i++){
            listDisplay[i].ClearAllDataSkill();
        }
    }

    private void CheckButtom()
    {
        for(int i=0; i<listDisplay.Count; i++)
        {

            if(listDisplay[i].IsClicked)
            {
                if(listDisplay[i].IsActivate && listDisplay[i].IsUse)
                {
                    if(listDisplay[i].NumberOfSkill == 0){
                        if(listDisplay[i].IsEarthSkill) EarthSkill_1();
                        if(listDisplay[i].IsFireSkill) FireSkill_1();
                        if(listDisplay[i].IsFrostSkill) FrostSkill_1();
                        if(listDisplay[i].IsWaterSkill) WaterSkill_1();
                    }

                    if(listDisplay[i].NumberOfSkill == 1){
                        if(listDisplay[i].IsEarthSkill) EarthSkill_2();
                        if(listDisplay[i].IsFireSkill) FireSkill_2();
                        if(listDisplay[i].IsFrostSkill) FrostSkill_2();
                        if(listDisplay[i].IsWaterSkill) WaterSkill_2();
                    }

                    if(listDisplay[i].NumberOfSkill == 2){
                        if(listDisplay[i].IsEarthSkill) EarthSkill_3();
                        if(listDisplay[i].IsFireSkill) FireSkill_3();
                        if(listDisplay[i].IsFrostSkill) FrostSkill_3();
                        if(listDisplay[i].IsWaterSkill) WaterSkill_3();
                    }

                    if(listDisplay[i].NumberOfSkill == 3){
                        if(listDisplay[i].IsEarthSkill) EarthSkill_4();
                        if(listDisplay[i].IsFireSkill) FireSkill_4();
                        if(listDisplay[i].IsFrostSkill) FrostSkill_4();
                        if(listDisplay[i].IsWaterSkill) WaterSkill_4();
                    }

                    if (listDisplay[i].NumberOfSkill == 4)
                   {
                        if(listDisplay[i].IsEarthSkill) EarthSkill_5();
                        if(listDisplay[i].IsFireSkill) FireSkill_5();
                        if(listDisplay[i].IsFrostSkill) FrostSkill_5();
                        if(listDisplay[i].IsWaterSkill) WaterSkill_5();
                    }
                    
                }
                listDisplay[i].IsClicked = false;
            }
        }
    }

    private void ReTimeDelay(){
        Debug.Log("re");
        timeDelay = 0;
    }
    
    public void AutoSkill()
    {
        for(int i=0; i<listDisplay.Count; i++)
        {
            if(listDisplay[i].IsActivate && listDisplay[i].IsUse)
            {
                int numberOfSkill = listDisplay[i].NumberOfSkill;

                if(numberOfSkill == 0)
                {
                    if(listDisplay[i].IsEarthSkill && listDisplay[i].currentCooldown == 0 ) EarthSkill_1();
                    if(listDisplay[i].IsFireSkill  && listDisplay[i].currentCooldown == 0) FireSkill_1();
                    if(listDisplay[i].IsFrostSkill  && listDisplay[i].currentCooldown == 0) FrostSkill_1();
                    if(listDisplay[i].IsWaterSkill  && listDisplay[i].currentCooldown == 0) WaterSkill_1();
                }

                if(numberOfSkill == 1)
                {
                    if(listDisplay[i].IsEarthSkill && listDisplay[i].currentCooldown == 0) EarthSkill_2();
                    if(listDisplay[i].IsFireSkill  && listDisplay[i].currentCooldown == 0) FireSkill_2();
                    if(listDisplay[i].IsFrostSkill  && listDisplay[i].currentCooldown == 0) FrostSkill_2();
                    if(listDisplay[i].IsWaterSkill  && listDisplay[i].currentCooldown == 0) WaterSkill_2();
                }

                if(numberOfSkill == 2)
                {
                    if(listDisplay[i].IsEarthSkill && listDisplay[i].currentCooldown == 0) EarthSkill_3();
                    if(listDisplay[i].IsFireSkill  && listDisplay[i].currentCooldown == 0) FireSkill_3();
                    if(listDisplay[i].IsFrostSkill  && listDisplay[i].currentCooldown == 0) FrostSkill_3();
                    if(listDisplay[i].IsWaterSkill  && listDisplay[i].currentCooldown == 0) WaterSkill_3();
                }

                if(numberOfSkill == 3)
                {
                    if(listDisplay[i].IsEarthSkill && listDisplay[i].currentCooldown == 0) EarthSkill_4();
                    if(listDisplay[i].IsFireSkill  && listDisplay[i].currentCooldown == 0) FireSkill_4();
                    if(listDisplay[i].IsFrostSkill  && listDisplay[i].currentCooldown == 0) FrostSkill_4();
                    if(listDisplay[i].IsWaterSkill  && listDisplay[i].currentCooldown == 0) WaterSkill_4();
                }
                if (numberOfSkill == 4)
                {
                    if (listDisplay[i].IsEarthSkill && listDisplay[i].currentCooldown == 0) EarthSkill_5();
                    if (listDisplay[i].IsFireSkill && listDisplay[i].currentCooldown == 0) FireSkill_5();
                    if (listDisplay[i].IsFrostSkill && listDisplay[i].currentCooldown == 0) FrostSkill_5();
                    if (listDisplay[i].IsWaterSkill && listDisplay[i].currentCooldown == 0) WaterSkill_5();
                }
            }
        }
    }

    public void FireDisplayUpdate(int numberOfDisplay, int numberOfSkill)
    {
        double currentCooldown = player.AllSkillFire[numberOfSkill].skillDataFire.CurrentCooldown;
        bool IsShowCooldownText = currentCooldown > 0;

        listDisplay[numberOfDisplay].icon.sprite = player.AllSkillFire[numberOfSkill].skillDataFire.Icon;
        listDisplay[numberOfDisplay].currentCooldown = currentCooldown;
        
        if (IsShowCooldownText)
            {
                listDisplay[numberOfDisplay].Background.color = Color.gray;
                listDisplay[numberOfDisplay].NoPanel.SetActive(true);
                listDisplay[numberOfDisplay].cooldown.text = currentCooldown.ToString("F0");
            }
            else
            {
                listDisplay[numberOfDisplay].Background.color = Color.white;
                listDisplay[numberOfDisplay].NoPanel.SetActive(false);
                listDisplay[numberOfDisplay].cooldown.text = "";
            }

            if (IsShowCooldownText) listDisplay[numberOfDisplay].icon.color = Color.gray;
    }

    public void EarthDisplayUpdate(int numberOfDisplay, int numberOfSkill)
    {
        double currentCooldown = player.AllSkillEarths[numberOfSkill].skillDataEarth.CurrentCooldown;
        bool IsShowCooldownText = currentCooldown > 0;

        listDisplay[numberOfDisplay].icon.sprite = player.AllSkillEarths[numberOfSkill].skillDataEarth.Icon;
        listDisplay[numberOfDisplay].currentCooldown = currentCooldown;

        if (IsShowCooldownText)
            {
                listDisplay[numberOfDisplay].Background.color = Color.gray;
                listDisplay[numberOfDisplay].NoPanel.SetActive(true);
                listDisplay[numberOfDisplay].cooldown.text = currentCooldown.ToString("F0");
            }
            else
            {
                listDisplay[numberOfDisplay].Background.color = Color.white;
                listDisplay[numberOfDisplay].NoPanel.SetActive(false);
                listDisplay[numberOfDisplay].cooldown.text = "";
            }

            if (IsShowCooldownText) listDisplay[numberOfDisplay].icon.color = Color.gray;
    }

    public void FrostDisplayUpdate(int numberOfDisplay, int numberOfSkill)
    {
        double currentCooldown = player.AllSkillFrost[numberOfSkill].skillDataFrost.CurrentCooldown;
        bool IsShowCooldownText = currentCooldown > 0;

        listDisplay[numberOfDisplay].icon.sprite = player.AllSkillFrost[numberOfSkill].skillDataFrost.Icon;
        listDisplay[numberOfDisplay].currentCooldown = currentCooldown;
        
        if (IsShowCooldownText)
            {
                listDisplay[numberOfDisplay].Background.color = Color.gray;
                listDisplay[numberOfDisplay].NoPanel.SetActive(true);
                listDisplay[numberOfDisplay].cooldown.text = currentCooldown.ToString("F0");
            }
            else
            {
                listDisplay[numberOfDisplay].Background.color = Color.white;
                listDisplay[numberOfDisplay].NoPanel.SetActive(false);
                listDisplay[numberOfDisplay].cooldown.text = "";
            }

            if (IsShowCooldownText) listDisplay[numberOfDisplay].icon.color = Color.gray;
    }

    public void WaterDisplayUpdate(int numberOfDisplay, int numberOfSkill)
    {
        double currentCooldown = player.AllSkillWater[numberOfSkill].skillDataWater.CurrentCooldown;
        bool IsShowCooldownText = currentCooldown > 0;

        listDisplay[numberOfDisplay].icon.sprite = player.AllSkillWater[numberOfSkill].skillDataWater.Icon;
        listDisplay[numberOfDisplay].currentCooldown = currentCooldown;
        
        if (IsShowCooldownText)
            {
                listDisplay[numberOfDisplay].Background.color = Color.gray;
                listDisplay[numberOfDisplay].NoPanel.SetActive(true);
                listDisplay[numberOfDisplay].cooldown.text = currentCooldown.ToString("F2");
            }
            else
            {
                listDisplay[numberOfDisplay].Background.color = Color.white;
                listDisplay[numberOfDisplay].NoPanel.SetActive(false);
                listDisplay[numberOfDisplay].cooldown.text = "";
            }

            if (IsShowCooldownText) listDisplay[numberOfDisplay].icon.color = Color.gray;
    }

    public void NormalAttackUse()
    {
        if (NormalAttacktimeDelay == NormalAttackMaxtimeDelay &&  timeDelay == MaxtimeDelay)
        {
            player.NormalAttack(out bool AttackComplete);
            if(AttackComplete) NormalAttacktimeDelay = 0;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void EarthSkill_1()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.EarthSkill1();
            Debug.Log("use Earth");
            timeDelay = MaxtimeDelay - 1f;
        }

    }

    public void EarthSkill_2()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.EarthSkill2();
            Debug.Log("use Earth");
            timeDelay = MaxtimeDelay -0.25f;
        }
    }

    public void EarthSkill_3()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.EarthSkill3();
            Debug.Log("use Earth");
            timeDelay = MaxtimeDelay - 3f;
        }
    }

    public void EarthSkill_4()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.EarthSkill4();
            Debug.Log("use Earth");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }
    public void EarthSkill_5()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.EarthSkill5();
            Debug.Log("use Earth");
            timeDelay = MaxtimeDelay - 6f;


        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FireSkill_1()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use fire");
            player.FireSkill1();
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void FireSkill_2()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use fire");
            player.FireSkill2();
            timeDelay = MaxtimeDelay - 1f;
        }
    }

    public void FireSkill_3()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use fire");
            player.FireSkill3();
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void FireSkill_4()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use fire");
            player.FireSkill4();
            timeDelay = MaxtimeDelay - 1f;
        }
    }
    public void FireSkill_5()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use fire");
            player.FireSkill5();
            timeDelay = MaxtimeDelay - 1f;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FrostSkill_1()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.FrostSkill1();
            Debug.Log("use frost");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void FrostSkill_2()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.FrostSkill2();
            Debug.Log("use frost");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void FrostSkill_3()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.FrostSkill3();
            Debug.Log("use frost");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void FrostSkill_4()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.FrostSkill4();
            Debug.Log("use frost");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }
    public void FrostSkill_5()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.FrostSkill5();
            Debug.Log("use frost");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void WaterSkill_1()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.WaterSkill1();
            Debug.Log("use Water");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void WaterSkill_2()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use Water");
            player.WaterSkill2();
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void WaterSkill_3()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use Water");
            player.WaterSkill3();
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }

    public void WaterSkill_4()
    {
        if (timeDelay == MaxtimeDelay)
        {
            Debug.Log("use Water");
            player.WaterSkill4();
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }
    public void WaterSkill_5()
    {
        if (timeDelay == MaxtimeDelay)
        {
            player.WaterSkill5();
            Debug.Log("use Water");
            timeDelay = MaxtimeDelay - 0.25f;
        }
    }
}
