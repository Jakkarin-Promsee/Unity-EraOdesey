using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSpite = null;
    public TextMeshProUGUI ItemCount = null;

    private void Awake() {
        ItemSpite.color = Color.clear;
        ItemCount.text = "";
    }

}
