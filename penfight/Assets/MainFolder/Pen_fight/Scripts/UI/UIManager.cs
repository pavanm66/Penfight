using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerOneNameText;
    [SerializeField] TextMeshProUGUI playerTwoNameText;
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

    [SerializeField] PlayerDataObject playerOneData;
    [SerializeField] PlayerDataObject playerTwoData;
    void Start()
    {
        gameOverPanel.SetActive(false);
        playerOneNameText.text = playerOneData.playerName;
        playerTwoNameText.text = playerTwoData.playerName;  
    }


    public void GameEnd(int winner)
    {
        if (winner == 0)
        {
            winnerName.text = playerOneNameText.text;
        }
        else
        {
            winnerName.text = playerTwoNameText.text;
        }
      //  winnerName.text = "Player : " + winner.ToString();
        gameOverPanel.SetActive(true);
    }
}
