using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CH : MonoBehaviour
{
    public TMP_Text Name;
    public SelectCH selectCH;
    public int NumberCH;
    public bool IsFight;

    public void SendDataToPopUP()
    {
        if (IsFight) selectCH.SendDataToFight(NumberCH);
        else selectCH.SendDataToRead(NumberCH);
    }
}
