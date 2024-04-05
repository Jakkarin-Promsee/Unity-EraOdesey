using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MiniGame : MonoBehaviour
{
    public GameObject MainPlayPanel;
    public GameObject EndGamePanel;

    public Slider TimeBar;

    public TMP_Text MainQuestion;

    public TMP_Text RatioScore;
    public TMP_Text Score;
    public TMP_Text TrueAns;

    public Question ReadyQuestion;
    public Question[] St1, St2, St3, St4, St5, St6, St7, St8, St9, St10, St11;

    public Question[] NowQuestion;
    public int NumberOfQuestion;
    public int PlayerPoint;

    public bool IsPlay;

    public float UnTime = 45;
    public float CountTime = 0;
    public int[] CountQuestion;

    int KeepReplay=0;

    private void Update()
    {
        if (IsPlay)
        {
            CountTime += Time.deltaTime;
            TimeBar.value = CountTime / UnTime;
            if (CountTime >= UnTime) EndQuestion();
        }
        else CountTime = 0;
    }

    public void BeginPlayQuestionGame(int NumberOfGame)
    {
        KeepReplay = NumberOfGame;
        switch(NumberOfGame){
            case 0:
               NowQuestion = St1;
               break;
            case 1:
               NowQuestion = St2;
               break;
            case 2:
               NowQuestion = St3;
               break;
            case 3:
               NowQuestion = St4;
               break;
            case 4:
               NowQuestion = St5;
               break;
            case 5:
               NowQuestion = St6;
               break;
            case 6:
               NowQuestion = St7;
               break;
            case 7:
               NowQuestion = St8;
               break;
            case 8:
               NowQuestion = St9;
               break;
            case 9:
               NowQuestion = St10;
               break;
            case 10:
               NowQuestion = St11;
               break;
        }

        IsPlay = true;
        PlayerPoint = 0;
        NumberOfQuestion = -1;
        CountQuestion = new int[NowQuestion.Length];
        for(int i=0; i<NowQuestion.Length; i++)
        {
            CountQuestion[i] = 0;
        }
        PlayQuestionGame();
    }

    public void RandomQuestion()
    {
        bool IsGet = true;
        while (IsGet)
        {
            int i = Random.Range(1, NowQuestion.Length);
            if(CountQuestion[i]<=2)
            {
                CountQuestion[i]++;
                NumberOfQuestion = i;
                IsGet = false;
            }
            else{
                IsGet = false;
                for(int j=0; j<NowQuestion.Length; j++)
                {
                    if(CountQuestion[j]<2) IsGet =  true;
                }
            }
        }
    }

    public void PlayQuestionGame()
    {
        MainPlayPanel.SetActive(true);
        EndGamePanel.SetActive(false);

        MainQuestion.text = "Q: " + ReadyQuestion.QuestionEnglish;
    }

    public void NextQuestion()
    {
        CountTime = 0;
        if (PlayerPoint >= NowQuestion.Length*2 || NowQuestion.Length ==0 ) EndQuestion();
        else
        {
            RandomQuestion();
            MainQuestion.text = "Q: " + NowQuestion[NumberOfQuestion].QuestionEnglish;
        }

        
    }

    public void EndQuestion()
    {
        IsPlay = false;
        MainPlayPanel.SetActive(false);
        EndGamePanel.SetActive(true);

        RatioScore.text = PlayerPoint.ToString() + " / " + NowQuestion.Length.ToString();
        Score.text = "Your Score : " + PlayerPoint.ToString(); //+ "\nBest Score : "
        string It = "";

        if (NumberOfQuestion > 0)
        {
            if (NowQuestion[NumberOfQuestion].IsTrue) It = "True";
            else It = "False";
        }
        else
        {
            if (ReadyQuestion.IsTrue) It = "True";
            else It = "False";
        }

        if(NumberOfQuestion<0) TrueAns.text = ReadyQuestion.QuestionEnglish + " The answer is " + It + ".";
        else TrueAns.text = NowQuestion[NumberOfQuestion].QuestionEnglish + " The answer is " + It + ".";
    }

    public void GuessQuestion(bool AnsIsTrue)
    {
        if(NumberOfQuestion<0){
            if(ReadyQuestion.IsTrue == AnsIsTrue)
            {
                PlayerPoint += 1;
                NextQuestion();
            }
            else 
            {
                EndQuestion();
            }
        }
        else{
            if(NowQuestion[NumberOfQuestion].IsTrue == AnsIsTrue)
            {
                PlayerPoint += 1;
                NextQuestion();
            }
            else 
            {
                EndQuestion();
            }
        }
    }

    public void Replay()
    {
        BeginPlayQuestionGame(KeepReplay);
    }
}
