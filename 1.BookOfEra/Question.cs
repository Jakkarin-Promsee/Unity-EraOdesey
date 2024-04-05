using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mini Game/Question")]
[System.Serializable]
public class Question : ScriptableObject
{
    public bool IsTrue = false;
    [TextArea(4,4)] public string QuestionEnglish = "";
    [TextArea(4,4)] public string QuestionThai = "";
    public float AddTime = 0;
}
