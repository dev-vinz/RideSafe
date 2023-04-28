using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] Transform carTransform;

    [SerializeField] Transform FinishLineTransformC1;
    [SerializeField] Transform FinishLineTransformC2;
    [SerializeField] Transform FinishLineTransformC3;
    [SerializeField] Transform FinishLineTransformC4;
    
    [SerializeField] GameObject game;

    [SerializeField] GameObject score;

    private bool started;
    private bool gameLaunched;

    private float timeValue;
    private float collideDistance;
    private float minTime;

    private string seconds;
    private string minutes;
    private string hours;

    private Transform finishline;
    private WheelController wc;
    private ScoreScript scoreScript;
    private GameManager gameManager;

    public void Restart()
    {
        minTime = timeValue + 20f;
    }

    public void ChangeCircuit(int level)
    {
        switch(level)
        {
            case 0:
                finishline = FinishLineTransformC1;
                break;
            case 1:
                finishline = FinishLineTransformC2;
                break;
            case 2:
                finishline = FinishLineTransformC3;
                break;
            case 3:
                finishline = FinishLineTransformC4;
                break;
        }
    }

    public void LaunchGame()
    {
        gameLaunched = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        finishline = FinishLineTransformC1;

        seconds = "00";
        minutes = "00";
        hours = "00";

        started = false;
        gameLaunched = false;

        timeValue = 0f;
        collideDistance = 4f;
        minTime = 1f; // TODO : FIX to 20

        text.text = "00:00:00";

        score.TryGetComponent<ScoreScript>(out scoreScript);
        game.TryGetComponent<GameManager>(out gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            timeValue += Time.deltaTime;

            UpdateTimerDisplay();

            checkForFinishing();
        }
        else
        {
            checkForStarting();
        }
    }

    private void checkForStarting()
    {
        float dist = Vector3.Distance(carTransform.position, finishline.position);

        if(dist < collideDistance && gameLaunched)
        {
            started = true;
        }
    }

    private void checkForFinishing()
    {
        float dist = Vector3.Distance(carTransform.position, finishline.position);

        if(dist < collideDistance && timeValue > minTime)
        {
            gameManager.StopGame(text.text, scoreScript.getScore());

            started = false;
            timeValue = 0f;

            UpdateTimerDisplay();

            gameLaunched = false;
        }
    }

    private void UpdateTimerDisplay()
    {
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


        text.text = hours + ":" + minutes + ":" + seconds;
    }
}
