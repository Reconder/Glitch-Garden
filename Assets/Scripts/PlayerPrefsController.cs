using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string MASTER_DIFFICULTY_KEY = "master difficulty";


    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 10f;

    public static float MasterVolume
    {
        get => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        set
        {
            if (value >= MIN_VOLUME && value <= MAX_VOLUME)
            {
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
            }
            else
            {
                Debug.LogError("Master volume is out of range");
            }
        }
    }

    public static float MasterDifficulty
    {
        get => PlayerPrefs.GetFloat(MASTER_DIFFICULTY_KEY);
        set
        {
            if (value >= MIN_DIFFICULTY && value <= MAX_DIFFICULTY)
            {
                PlayerPrefs.SetFloat(MASTER_DIFFICULTY_KEY, value);
            }
            else
            {
                Debug.LogError("Master difficulty is out of range");
            }



        }
    }
}
