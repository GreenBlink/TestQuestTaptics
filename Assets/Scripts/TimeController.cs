using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private int currentTime;

    public static TimeController instance;

    public int maxTime;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        currentTime = maxTime;
        UIController.instance.InitTimeSlider(maxTime);

        StartCoroutine(TimeProcess());
    }

    private IEnumerator TimeProcess()
    {
        float time = maxTime; 

        while (currentTime > 0)
        {
            time -= Time.deltaTime;
            currentTime = (int)time;

            UIController.instance.SetTimeUI(currentTime);
            yield return null;
        }

        GameController.instance.FinishGame(false);
    }
}
