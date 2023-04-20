using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text text;

    private string label;
    private int score;

    void Start()
    {
        label = "Score : ";
        score = 0;
    }

    public void increaseScore(int increase)
    {
        score += increase;
    }

    void Update()
    {
        text.text = label + score.ToString();
    }
}
