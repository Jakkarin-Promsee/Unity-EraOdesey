using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour
{
    public PlayerMainController Player;
    public Slider progressSlider;

    void Update()
    {
        progressSlider.maxValue = (float)Player.MaxHp;
        progressSlider.value = (float)Player.currentHp;
    }
}
