using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PenScaler : MonoBehaviour
{
    Vector3 spawnpos;
    Quaternion spawnrot;
 public PlayerTitle penTitle;
    // Start is called before the first frame update
   void Start()
    {
        spawnpos = transform.position;
        spawnrot = transform.rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = 10 * (0.5f + ((10 - transform.position.z) / 20));
        transform.localScale = new Vector3(x, x, x);
    }

    public bool IsinSpawnPos()
    {
        if (transform.position == spawnpos && transform.rotation == spawnrot)
            return true;
        else
        {
            return false;
        }
    }
    public void Respawn()
    {
        transform.position = spawnpos;
        transform.rotation = spawnrot;
       // IsinSpawnPos();
    }
}
