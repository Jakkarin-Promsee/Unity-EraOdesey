using UnityEngine;
using UnityEngine.UI;

public class ExpBarScript : MonoBehaviour
{
    public GameController controller;
    public Slider progressSlider;

    private void Start()
    {
        
    }
    void Update()
    {
        progressSlider.maxValue = (float)(controller.exprequirement);
        float i = (float)(controller.expNow);
        progressSlider.value = i;
    }
}
