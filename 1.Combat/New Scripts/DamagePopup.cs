using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    private TextMeshPro _textMesh;
    private float DisappearTimer;
    private Color textcolor;

    private void Awake()
    {
        _textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void ConvertNumberToMutiplyPattern(double number, long multiplier, out double newnumber, out long newmutiplier)
    {
        double multiplierValue = 1e3;
        if (number > multiplierValue)
        {
            double mp = 1;
            long mmp = multiplier;

            while (number / mp > multiplierValue)
            {
                mp *= multiplierValue;
                mmp++;
            }

            newnumber = number / mp;
            newmutiplier = mmp;
        }
        else if (number < 1)
        {
            double mp = 1;

            while (number * mp < 0)
            {
                mp *= multiplierValue;
            }

            newnumber = number * mp;
            newmutiplier = (long)(multiplier - mp);
        }
        else
        {
            newnumber = number;
            newmutiplier = multiplier;
        }
    }

    public void Setup(double damageAmont) 
    {
        double newDamageNumber;
        long newDamageMultiplier;
        ConvertNumberToMutiplyPattern(damageAmont, 0, out newDamageNumber, out newDamageMultiplier);

        Debug.Log(":::::::::::: " + newDamageMultiplier.ToString());

        if(newDamageMultiplier == 0 || newDamageMultiplier<0) _textMesh.SetText(damageAmont.ToString("F0"));
        else _textMesh.SetText(newDamageNumber.ToString("F2") + multiple[newDamageMultiplier]);
        textcolor = _textMesh.color;
        DisappearTimer = 0.25f;
        
    }

    private void Update()
    {
        float moveYspeed = 2;
        transform.position += new Vector3(0, moveYspeed) * Time.deltaTime;
        DisappearTimer -= Time.deltaTime;

        if (DisappearTimer < 0)
        {
            float disappearSpeed = 4f;
            textcolor.a -= disappearSpeed* Time.deltaTime;
            _textMesh.color = textcolor;
            if (textcolor.a < 0) 
            {
                Destroy(gameObject);
            }
        }
    }
}
