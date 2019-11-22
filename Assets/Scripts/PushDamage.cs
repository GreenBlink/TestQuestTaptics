using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushDamage : MonoBehaviour
{
    public RectTransform rect;
    public Text valueText;
    public float speed;

    public void Init(int value)
    {
        valueText.text = value.ToString();
        StartCoroutine(PushProcess());
    }

    private IEnumerator PushProcess()
    {
        Color temp = new Color();
        float process = 1;

        while (process > 0)
        {
            process -= Time.deltaTime * 0.8f;

            temp = valueText.color;
            temp.a = process;
            valueText.color = temp;

            rect.Translate(new Vector3(0, speed));

            yield return null;
        }

        Destroy(gameObject);
    }
}
