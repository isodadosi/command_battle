using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMainSystem : MonoBehaviour
{
    public Unit player;
    public Unit enemy;
    public GameObject ResultPanel;
    public GameObject PlayerPanel;
    public GameObject PlayerChimeraPanel;

    private GameState currentState;

    bool IsPlayerTurn;
    bool IsGameOver;
    bool CommandSelect;

    float second = 0f;

    private enum GameState
    {
        PlayerSelect, //#プレイヤーのコマンド入力
        PlayerChimeraSelect, //#プレイヤーのキメラのコマンド入力
        PlayerTurnEnd, //#プレイヤーの選択が終わり、処理を実行
        EnemySelect, //#敵のコマンド入力
        EnemyChimeraSelect, //#敵のキメラのコマンド入力
        EnemyTurnEnd, //#敵の選択が終わり、処理を実行
        GameWin, //#敵のHPがなくなった場合
        GameOver, //#自分のHPがなくなった場合
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.PlayerSelect;
        PlayerPanel.SetActive(true);
        PlayerChimeraPanel.SetActive(false);
        ResultPanel.SetActive(false);
        CommandSelect = false;
    }

    // Update is called once per frame

    void ViewResult()
    {
        ResultPanel.SetActive(true);
    }




    //ターン状態の遷移

    public void PlayerSelect()
    {
        if(CommandSelect == true)
        {
            PlayerPanel.SetActive(false);
            PlayerChimeraPanel.SetActive(true);
            CommandSelect = false;
            currentState = GameState.PlayerChimeraSelect;
        }
    }

    public void PlayerChimeraSelect()
    {
        if (CommandSelect == true)
        {
            PlayerPanel.SetActive(false);
            PlayerChimeraPanel.SetActive(false);
            CommandSelect = false;
            currentState = GameState.PlayerTurnEnd;
        }
    }



    public void PlayerTurnEnd()
    {
        second += Time.deltaTime;
        if (second >= 0.5f)
        {
            second = 0f;
            currentState = GameState.EnemyChimeraSelect;
        }

    }

    public void EnemySelect()
    {

    }

    public void EnemyChimeraSelect()
    {
        player.OnDamage(enemy.at);
        currentState = GameState.EnemyTurnEnd;
    }

    public void EnemyTurnEnd()
    {
        second += Time.deltaTime;
        if (second >= 0.5f)
        {
            second = 0f;
            PlayerPanel.SetActive(true);
            PlayerChimeraPanel.SetActive(false);
            currentState = GameState.PlayerSelect;
        }
        
        
    }

    public void GameWin()
    {

    }

    public void GameOver()
    {

    }

    // 各コマンド
    public void PushInstructionButton()
    {
        CommandSelect = true;
    }

    public void PushAttackButton()
    {
        enemy.OnDamage(player.at);
        CommandSelect = true;
        
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.PlayerSelect:
                PlayerSelect();
                break;
            case GameState.PlayerChimeraSelect:
                PlayerChimeraSelect();
                break;
            case GameState.PlayerTurnEnd:
                PlayerTurnEnd();
                break;
            case GameState.EnemySelect:
                EnemySelect();
                break;
            case GameState.EnemyChimeraSelect:
                EnemyChimeraSelect();
                break;
            case GameState.EnemyTurnEnd:
                EnemyTurnEnd();
                break;
            case GameState.GameWin:
                GameWin();
                break;
            case GameState.GameOver:
                break;
            default:
                break;
        }

    }

    
}
