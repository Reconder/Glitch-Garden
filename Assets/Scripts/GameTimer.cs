using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10f;
    Slider slider;
    bool timerFinished;

    private void Start()
    {
        timerFinished = false;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;
        CheckIfFinished();
    }

    private void CheckIfFinished()
    {
        if (timerFinished) { return; }
        
        if ((Time.timeSinceLevelLoad >= levelTime))
        {
            timerFinished = true;
            FindObjectOfType<LevelController>().TimerHasFinished();
        }
    }
}
