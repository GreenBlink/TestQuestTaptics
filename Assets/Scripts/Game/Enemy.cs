using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int currentLevel;
    private int hp;

    public Animator animator;
    public int stepHP;
    public int damage;

    public void Init(int levelEnemy)
    {
        hp = levelEnemy * stepHP;
        currentLevel = levelEnemy;

        UIController.instance.InitHPSlider(hp);
    }

    public void Damage()
    {
        hp = hp < damage ? 0 : hp - damage;

        UIController.instance.SetHPUI(hp);
        UIController.instance.InitPushDamage(-damage);
        animator.SetTrigger("Attack");

        if (hp == 0)
        {
            StartCoroutine(DieProcess());
        }
    }

    private void OnMouseDown()
    {
        if (hp > 0 && !GameController.instance.isFinishGame)
            Damage();
    }

    private IEnumerator DieProcess()
    {
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        EnemesController.instance.NextEnemy(++currentLevel);
    }
}
