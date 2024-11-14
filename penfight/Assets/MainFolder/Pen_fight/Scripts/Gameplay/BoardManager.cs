using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public List<PenScript> pens = new List<PenScript>();
    public int penFell = -1;
    public void PenTriggered(int pid)
    {
        if (penFell == -1)
        {
            penFell = pid;
        }
    }


    public bool AllPensStopped()
    {
        if (pens[0].rb.velocity.magnitude != 0 || pens[1].rb.velocity.magnitude != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
       
    }

    public void SendResults()
    {
        StartCoroutine(ISendResults());
    }

     IEnumerator ISendResults()
    {
        int playerGotPoint;
        if (penFell != -1)
        {
           // yield return StartCoroutine(Wait_for(3));
            yield return new WaitForSeconds(3f);
            playerGotPoint = (penFell + 1) % 2;
        }
        else
        {
            playerGotPoint = penFell;
        }
        GameManager.Instance.CheckResults(playerGotPoint);
    }


    public void ResetTurn()
    {
        penFell = -1;
        foreach (PenScript pen in pens)
        {
            pen.Respawn();
        }

    }
}
