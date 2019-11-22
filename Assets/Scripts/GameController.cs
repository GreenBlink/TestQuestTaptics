﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EnemesController.instance.Init();
        TimeController.instance.Init();
    }

    public void FinishGame(bool isWin)
    {

    }
}
