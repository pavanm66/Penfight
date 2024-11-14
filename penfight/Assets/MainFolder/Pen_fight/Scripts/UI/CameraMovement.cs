using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Vector3 newPos;
    public  List<GameObject> playersInGame = new List<GameObject>();

    void LateUpdate()
    {
        var totalX = 0f;
        var totalY = 0f;
        foreach (var player in playersInGame)
        {
            totalX += player.transform.position.x;
            totalY += player.transform.position.y;
        }
        var centerX = totalX / playersInGame.Count;
        var centerY = totalY / playersInGame.Count;
        Vector3 pos=new Vector3(centerX, centerY,-10);

        newPos = Vector3.Lerp(gameObject.transform.position, pos, 1);
        gameObject.transform.position = new Vector3(newPos.x, newPos.y, newPos.z);

    }
}