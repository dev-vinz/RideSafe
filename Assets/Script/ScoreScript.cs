using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text text;

    private string label;
    private int score;

    private bool gameLaunched;

    void Start()
    {
        gameLaunched = false;
        label = "Score : ";
        score = 0;
    }

    public void increaseScore(int increase)
    {
        if(gameLaunched)
        {
            score += increase;
        }
    }

    public void LaunchGame()
    {
        gameLaunched = true;
    }

    void Update()
    {
        text.text = label + score.ToString();
    }

    public string getScore()
    {
        gameLaunched = false;
        int oldScsore = score;
        score = 0;
        return label + oldScsore.ToString();
    }
}
