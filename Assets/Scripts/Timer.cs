using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //Display visual timer
    public TextMesh displayText;
    //starting time for timer
    public float timerDuration;
    //current seconds remaining on the timer
    private float timeRemaining = 0;


	// Use this for initialization
	void Start () {
    
	}

	
	// Update is called once per frame
	void Update () {
        //only process the timer if it is running
        if (IsTimerRunning())
        {
            //timer IS running, so process
            timeRemaining = timeRemaining-Time.deltaTime;
            //check if time has run out
            if(timeRemaining<=0)
            {
                //set time to 0
                StopTimer();
            }
            //update visual display
            displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
	}


    //starts the timer counting
    public void StartTimer()
    {
        timeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    //stop the timer
    public void StopTimer()
    {
        timeRemaining = 0;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    //is the timer currently running?
    public bool IsTimerRunning()
    {
        if (timeRemaining !=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
