using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMainSystem : MonoBehaviour
{
    public Unit player;
    public Unit enemy;
    public GameObject ResultPanel;

    bool IsPlayerTurn;
    bool IsGameOver;

    float second = 0f;

    // Start is called before the first frame update
    void Start()
    {
        IsPlayerTurn = true;
        IsGameOver = false;
        ResultPanel.SetActive(false);
    }

    // Update is called once per frame

    void ViewResult()
    {
        ResultPanel.SetActive(true);
    }

    void Update()
    {
        if (player.hp == 0 || enemy.hp == 0)
        {
            IsGameOver = true;
        }
        if (IsGameOver)
        {
            ViewResult();
            return;
        }
        if (!IsPlayerTurn)
        {
            second += Time.deltaTime;
            if(second >= 1f)
            {
                second = 0f;
                IsPlayerTurn = true;
                player.OnDamage(enemy.at);
            }
        }
        
    }

    public void PushAttackButton()
    {
        if (IsPlayerTurn)
        {
            enemy.OnDamage(player.at);
            IsPlayerTurn = false;
        }
    }
}
