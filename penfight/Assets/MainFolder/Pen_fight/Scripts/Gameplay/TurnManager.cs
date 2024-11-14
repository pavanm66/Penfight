using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    #region Properties

    private bool isTurnActive;

    public bool IsTurnActive
    {
        get { return isTurnActive; }
        set { isTurnActive = value; }
    }

    int turn = 0;

    public int Turn
    {
        get { return turn; }
        set
        {
            Timer = maxTurnTimer;
            print(Timer + " is timer at start");
            turn = value;
            turn = turn % 2;
            GameManager.Instance.IsBotPlayer = Turn == 0 ? true : false;
        }
    }


    #endregion
   
    public bool gameActive = true;

    public IEnumerator StartGame()
    {
        while (gameActive)
        {
           // yield return new WaitForSeconds(1.5f);
            yield return StartCoroutine(GameManager.Instance.pens[Turn].StartTurn());
            Turn++;
            yield return null;
        }
    }

    //Timer
    #region Timer_Region
    private float timer;

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            GameManager.Instance.UpdateTimerUI(timer);
        }
    }

    public float maxTurnTimer; //this is for max time for turn

    public void StartTurnTimer()
    {
        //print(IsTurnActive + " is turn active");
        if (Timer > 0 )
        {
            Timer -= Time.deltaTime * 2f;
        }
      
        
        
      //  print(IsTurnActive + " after if else");
        // StartCoroutine(IStartTurnTimer());
    }
    

    #endregion

}