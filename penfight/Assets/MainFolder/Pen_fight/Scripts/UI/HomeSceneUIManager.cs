using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneUIManager : MonoBehaviour
{

    [SerializeField] InputField playerOneText;
    [SerializeField] InputField playerTwoText;
    [SerializeField] GameObject playerDetailsPanel;
    [SerializeField] GameObject quitPanel;
    [SerializeField] GameObject homePanel;
    [SerializeField] GameObject settingsPanel;

    public string playerOneName, playerTwoName;

    [SerializeField] PlayerDataObject playerOneData;
    [SerializeField] PlayerDataObject playerTwoData;

    [SerializeField] GameObject soundOn, soundOff;
    [SerializeField] GameObject musicOn, musicOff;
    [SerializeField] GameObject vibrationOn, vibrationOff;


    private void Start()
    {
        if (!homePanel.activeSelf)
        {
            homePanel.SetActive(true);

        }
        quitPanel.SetActive(false);
        settingsPanel.SetActive(false);
        playerDetailsPanel.SetActive(false);
    }
 
    void GetPlayerData()
    {
        if (playerOneText != null)
        {
            playerOneName = playerOneText.text;
            playerOneData.playerName = playerOneName;
        }
        if (playerTwoText != null)
        {
            playerTwoName = playerTwoText.text;
            playerTwoData.playerName = playerTwoName;
        }
    }
    public void LoadGameScene()
    {
        if (playerOneText.text == null || playerTwoText.text == null)
        {
            print("enter player details");
        }
        else
        {
            GetPlayerData();
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }

}
