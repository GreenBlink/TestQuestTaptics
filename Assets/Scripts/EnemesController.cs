using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemesController : MonoBehaviour
{
    private Enemy enemy;

    public static EnemesController instance;

    public Enemy prefabEnemy;
    public Transform containerEnemes;
    public int startLevel;
    public int maxLevel;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        InitEnemy(startLevel);
        UIController.instance.InitWave(startLevel, maxLevel);

        if (startLevel == 0)
            Debug.LogWarning("Start level enemy is 0!");
    }

    public void NextEnemy(int nextLevel)
    {
        if (nextLevel <= maxLevel)
        {
            InitEnemy(nextLevel);
            UIController.instance.NextWave();
        }
        else
            GameController.instance.FinishGame(true);
    }

    private void InitEnemy(int levelEnemy)
    {
        enemy = Instantiate(prefabEnemy, containerEnemes);
        enemy.Init(levelEnemy);
    }
}
