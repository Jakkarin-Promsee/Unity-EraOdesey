using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSilderController : MonoBehaviour
{
    public GameObject Controller;
    public GameObject Spawner;

    public Image FillArea;

    public int roundprogress;
    public Slider progressSlider;

    public double BossMaxHp;
    public double BossRemainHp;

    private void Update()
    {
        if (Spawner.GetComponent<IteeSpawner>().isAcitvateSpawnBoss == true)
        {
            progressSlider.maxValue = 100;
            progressSlider.value = (float)((BossRemainHp/BossMaxHp) * 100);
            FillArea.color = Color.red;
        }
        else
        {
            progressSlider.value = roundprogress;
            progressSlider.maxValue = 91;
            FillArea.color = Color.white;
        }
        //
        if (roundprogress >= 91) 
        {
            roundprogress = 0;
        }
    }
}
