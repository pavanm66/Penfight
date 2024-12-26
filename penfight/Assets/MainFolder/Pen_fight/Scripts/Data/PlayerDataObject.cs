using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerData",menuName = "ScriptableObjects/Data",order = 1)]
public class PlayerDataObject : ScriptableObject
{
    public string playerName;
    public Color penColor;

}
