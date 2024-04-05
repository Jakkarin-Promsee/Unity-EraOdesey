using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadBook : MonoBehaviour
{
    public SelectCH selectCH;
    public TMP_Text Topic;
    public TMP_Text Detail;

    public void UpdateCH(int i)
    {
        if(selectCH.IsEng)
        {
            Topic.text = selectCH.EnglishNameCH[i];
            Detail.text = selectCH.txtFile[i].text;
        }
        else if(selectCH.IsThai)
        {
            Topic.text = selectCH.EnglishNameCH[i];
            Detail.text = selectCH.txtFile[i].text;
        }
        else{
            Topic.text = "";
            Detail.text = "";
        }
    }
}
