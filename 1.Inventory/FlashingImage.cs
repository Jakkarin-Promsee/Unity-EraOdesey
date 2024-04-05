using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingImage : MonoBehaviour
{
    public Color StartColor;
    public Color EndColor;

    [Range(0,10)]
    public float Speed = 1;

    Image imgComp;

    private void Awake() {
        imgComp = GetComponent<Image>();
    }

    private void Update() {
        imgComp.color = Color.Lerp(StartColor, EndColor, Mathf.PingPong(Time.time * Speed, 1));
    }
}
