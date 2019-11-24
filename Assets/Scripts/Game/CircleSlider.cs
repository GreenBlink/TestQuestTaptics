using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    private int currnetValue;
    private int maxValue;

    public Image fill;
    public Text valueText;

    public void Init(int maxValue)
    {
        currnetValue = maxValue;
        this.maxValue = maxValue;
        fill.fillAmount = 1;
        valueText.text = currnetValue.ToString();
    }

    public void SetValue(int value)
    {
        currnetValue = value;
        fill.fillAmount = float.Parse(currnetValue.ToString()) / float.Parse(maxValue.ToString());
        valueText.text = currnetValue.ToString();
    }
}
