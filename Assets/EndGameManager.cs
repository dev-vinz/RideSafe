using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] GameObject score;
    [SerializeField] GameObject time;

    [SerializeField] GameObject game;

    private Text scoreText;
    private Text timeText;

    private GameManager gameManager;

    void Start()
    {
        scoreText = score.GetComponent<Text>();
        timeText = time.GetComponent<Text>();
        game.TryGetComponent<GameManager>(out gameManager);
    }

    public void SetValues(string timeS, string scoreS)
    {
        scoreText.text = scoreS;
        timeText.text = timeS;
    }
}
