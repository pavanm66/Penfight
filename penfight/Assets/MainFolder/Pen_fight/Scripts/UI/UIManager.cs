using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI p1Score;
    public TextMeshProUGUI p2Score;
    public TextMeshProUGUI p1Timer;
    public TextMeshProUGUI p2Timer;
    public Image p1TimerRing;
    public Image p2TimerRing;
    public Text winnerName;
    float maxTurnTime;
    public GameObject gameOverPanel;
    public int[] scores = { 0, 0 };
    void Start()
    {
        gameOverPanel.SetActive(false);
    }


    public void GameEnd(int winner)
    {
        winnerName.text = "Player : " + winner.ToString();
        gameOverPanel.SetActive(true);
    }
}
