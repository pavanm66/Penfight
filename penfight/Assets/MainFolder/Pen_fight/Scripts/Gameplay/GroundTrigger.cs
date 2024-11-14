using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
    
{
    [SerializeField] BoardManager boardManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PenScaler>().penTitle == PlayerTitle.Player1){

           boardManager.PenTriggered(0);
        }
        if (other.gameObject.GetComponent<PenScaler>().penTitle == PlayerTitle.Player2){

           boardManager.PenTriggered(1);
        }
        
    }
    
};