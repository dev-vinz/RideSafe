using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text text;

    private bool started;

    private float timeValue;

    private string seconds;
    private string minutes;
    private string hours;

    // Start is called before the first frame update
    void Start()
    {
        seconds = "00";
        minutes = "00";
        hours = "00";

        started = true;
        timeValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            timeValue += Time.deltaTime;
        }

        float time = timeValue;

        // hours
        int hoursValue = (int)Math.Floor(time / 3600);
        time -= (hoursValue * 3600);

        if(hoursValue < 10)
        {
            hours = "0" + hoursValue.ToString();
        }
        else
        {
            hours = hoursValue.ToString();
        }

        // minutes
        int minutesValue = (int)Math.Floor(time / 60);
        time -= (minutesValue * 60);

        if(minutesValue < 10)
        {
            minutes = "0" + minutesValue.ToString();
        }
        else
        {
            minutes = minutesValue.ToString();
        }

        // seconds
        int secondsValue = (int)Math.Floor(time);

        if(secondsValue < 10)
        {
            seconds = "0" + secondsValue.ToString();
        }
        else
        {
            seconds = secondsValue.ToString();
        }


        text.text = hours + ":" + minutes + ":" + seconds;//timeValue.ToString();
    }
}
