using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int currentWave;
    private int maxWave;

    public static UIController instance;

    public CircleSlider hpEnemySlider;
    public CircleSlider timeSlider;
    public GameObject windowLoseGame;
    public WindowWinGame windowWinGame;
    public PushDamage pushDamage;
    public Transform container;
    public Text waveText;

    private void Awake()
    {
        instance = this;
    }

    public void InitHPSlider(int hp)
    {
        hpEnemySlider.Init(hp);
    }

    public void InitTimeSlider(int time)
    {
        timeSlider.Init(time);
    }

    public void InitWave(int currentWave, int maxWave)
    {
        this.currentWave = currentWave;
        this.maxWave = maxWave;

        waveText.text = string.Concat("Волна ", currentWave, " из ", maxWave);
    }

    public void NextWave()
    {
        waveText.text = string.Concat("Волна ", ++currentWave, " из ", maxWave);
    }

    public void InitPushDamage(int value)
    {
        PushDamage push = Instantiate(pushDamage, container);
        push.transform.position = Input.mousePosition;
        push.Init(value);
    }

    public void SetHPUI(int value)
    {
        hpEnemySlider.SetValue(value);
    }

    public void SetTimeUI(int value)
    {
        timeSlider.SetValue(value);
    }
}
