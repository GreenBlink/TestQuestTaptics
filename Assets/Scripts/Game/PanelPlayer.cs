using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlayer : MonoBehaviour
{
    public Text namePalyer;
    public Text valuePlayer;

    public void Init(Player player)
    {
        namePalyer.text = player.name;
        valuePlayer.text = player.best_time.ToString("0.0");
    }
}
