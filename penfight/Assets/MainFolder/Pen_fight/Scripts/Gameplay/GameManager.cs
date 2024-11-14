using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    [FormerlySerializedAs("UI_manager")] public UIManager uIManager;
    [FormerlySerializedAs("Turn_Manager")] public TurnManager turnManager;

    [FormerlySerializedAs("Board_Manager")]
    public BoardManager boardManager;

    //public Game_Logic Game_Logic;
    public List<PenScript> pens = new List<PenScript>();

    public int maxScore = 3;
    //  public float max_turn_timer;


    private bool isBotPlayer;

    public bool IsBotPlayer
    {
        get { return isBotPlayer; }
        set { isBotPlayer = value; }
    }

    private int playerOneScore;

    public int PlayerOneScore
    {
        get { return playerOneScore; }
        set
        {
            playerOneScore = value;
            uIManager.p1Score.text = playerOneScore.ToString();
        }
    }

    private int playerTwoScore;

    public int PlayerTwoScore
    {
        get { return playerTwoScore; }
        set
        {
            playerTwoScore = value;
            uIManager.p2Score.text = playerTwoScore.ToString();
        }
    }

    /*private int[] scores;

    public int[] Scores
    {
        get { return scores; }
        set { scores = value; }
    }*/


    public void UpdateTimerUI(float timer)
    {
        if (IsBotPlayer)
        {
            uIManager.p1Timer.text = timer.ToString("0");
            uIManager.p1TimerRing.fillAmount = timer / turnManager.maxTurnTimer;
        }
        else
        {
            uIManager.p2Timer.text = timer.ToString("0");
            uIManager.p2TimerRing.fillAmount = timer / turnManager.maxTurnTimer;
        }
    }

    private void ResetTurn()
    {
        boardManager.ResetTurn();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartTurnTimer()
    {
        turnManager.StartTurnTimer();
    }

    void Start()
    {
        StartCoroutine(turnManager.StartGame());
    }

    private void GameCompleted(int winner)
    {
        turnManager.gameActive = false;
        uIManager.GameEnd(winner);
    }


    public void CheckResults(int playerGotPoint)
    {
        if (playerGotPoint != -1)
        {
            if (isBotPlayer)
            {
                PlayerOneScore++;
            }
            else
            {
                PlayerTwoScore++;
            }

            if (PlayerOneScore == maxScore || PlayerTwoScore == maxScore)
            {
                GameCompleted(playerGotPoint);
            }
            else
            {
                ResetTurn();
            }
        }
    }

    public bool AllPensStopped()
    {
        return boardManager.AllPensStopped();
    }

    public void SubmitTurn()
    {
        boardManager.SendResults();
    }
}