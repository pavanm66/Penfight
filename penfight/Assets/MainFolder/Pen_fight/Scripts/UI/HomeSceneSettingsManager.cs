using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneSettingsManager : MonoBehaviour
{

    bool isSoundOn;
    public bool IsSoundOn
    {
        get
        {
            return isSoundOn;
        }
        set
        {
            isSoundOn = value;
            PlayerPrefs.SetInt("Sound", isSoundOn ? 1 : 0);
        }
    }
    bool isMusicOn;
    public bool IsMusicOn
    {
        get
        {
            return isMusicOn;
        }
        set
        {
            isMusicOn = value;
            PlayerPrefs.SetInt("Music", isMusicOn ? 1 : 0);
        }
    }
    bool isVibrationOn;
    public bool IsVibrationOn
    {
        get
        {
            return isVibrationOn;
        }
        set
        {
            isVibrationOn = value;
            PlayerPrefs.SetInt("Vibration", isVibrationOn ? 1 : 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
}
