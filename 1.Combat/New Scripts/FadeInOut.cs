using System.Collections;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private bool _fadein = false;
    private bool _fadeout = false;
    public float fadespeed;
    public GameObject Button;
    public GameObject BossButton;

    private void Start()
    {
        FadeOut();
    }

    private void Update()
    {
        if (_fadein)
        {
            Button.SetActive(false);
            BossButton.SetActive(false);
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadespeed * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    _fadein = false;
                    StartCoroutine(WaitAndFadeOut());
                }
            }
        }
        if (_fadeout)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= fadespeed * Time.deltaTime;
                if (canvasGroup.alpha <= 0)
                {
                    _fadeout = false;
                    BossButton?.SetActive(true);
                    Button.SetActive(true);
                }
            }
        }
    }

    public void FadeIn()
    {
        _fadein = true;
    }

    private IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(0.5f); 
        FadeOut();
    }

    public void FadeOut()
    {
        _fadeout = true;
    }
}