using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool isFinishGame;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isFinishGame = false;

        EnemesController.instance.Init();
        TimeController.instance.Init();
        Network.instance.GetPlayers();
    }

    public void FinishGame(bool isWin)
    {
        if (isWin)
        {
            UIController.instance.windowWinGame.Init(TimeController.instance.StopTimer());
        }
        else
        {
            UIController.instance.windowLoseGame.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public int SaveRecord(int bestTime)
    {
        if (PlayerPrefs.HasKey("best_time"))
        {
            float record = PlayerPrefs.GetFloat("best_time");

            if (record < bestTime)
                return (int)record;
        }

        PlayerPrefs.SetFloat("best_time", bestTime);
        return bestTime;
    }
}
