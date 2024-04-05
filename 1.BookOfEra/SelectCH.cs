using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SelectCH : MonoBehaviour
{
    public GameObject readBookOb;
    public ReadBook readBook;
    public MiniGame miniGame;
    public bool IsEng, IsThai;
    public TextAsset[] txtFile;
    public CH[] cHs;
    public CH[] cHsForFight;
    [TextArea(1,4)] public string[] EnglishNameCH;
    [TextArea(1,4)] public string[] ThaiNameCH;

    private void Start() {
        for(int i=0; i<cHs.Length; i++)
        {
            cHs[i].selectCH = this;
            cHs[i].NumberCH = i;
            cHs[i].IsFight = false;
        }

        for(int i = 0; i < cHsForFight.Length; i++)
        {
            cHsForFight[i].selectCH = this;
            cHsForFight[i].NumberCH = i;
            cHsForFight[i].IsFight = true;
        }
    }

    public void ChangeLanguageToDefault()
    {
        for(int i=0; i<cHs.Length; i++)
        {
            cHs[i].Name.text = "";
            cHsForFight[i].Name.text = "";
        }

        IsEng = false;
        IsThai = false;
    }

    public void ChangeLanguageToEnglish()
    {
        for(int i=0; i<cHs.Length; i++)
        {
            cHs[i].Name.text = EnglishNameCH[i];
            cHsForFight[i].Name.text = EnglishNameCH[i];
        }

        IsEng = true;
        IsThai = false;
    }

    public void ChangeLanguageToThai()
    {
        for(int i=0; i<cHs.Length; i++)
        {
            cHs[i].Name.text = ThaiNameCH[i];
            cHsForFight[i].Name.text = ThaiNameCH[i];
        }

        IsEng = false;
        IsThai = true;
    }

    public void SendDataToRead(int CH)
    {
        readBook.UpdateCH(CH);
        readBookOb.SetActive(true);
    }

    public void SendDataToFight(int CH)
    {
        miniGame.BeginPlayQuestionGame(CH);
    }
}
