using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public TMP_Text textDisplay;
    public float secondsLeft = 30;
    public bool timerActive;
    

    private void Start()
    {
        timerActive = true;
    }

    private void Update()
    {
        DisplayTime();
        if (timerActive)
        {
            if (secondsLeft > 0)
            {
                secondsLeft -= Time.deltaTime;
            }
            else
            {
                secondsLeft = 0;
                timerActive = false;
            }
        }
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(secondsLeft / 60);
        float seconds = Mathf.FloorToInt(secondsLeft % 60);

        textDisplay.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
