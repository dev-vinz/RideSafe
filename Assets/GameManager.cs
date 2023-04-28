using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject endGameCanvas;
    [SerializeField] GameObject playingCanvas;

    [SerializeField] GameObject car;

    private WheelController wc;

    void Start()
    {
        car.TryGetComponent<WheelController>(out wc);
    }

    public void StartGame(int level)
    {
        endGameCanvas.SetActive(false);

        menuCanvas.SetActive(false);
        menuCanvas.GetComponent<Canvas>().enabled = false;

        playingCanvas.SetActive(true);
        playingCanvas.GetComponent<Canvas>().enabled = true;

        wc.LaunchGame(level);
    }

    public void StopGame(string time, string score)
    {   
        playingCanvas.SetActive(true);
        playingCanvas.GetComponent<Canvas>().enabled = false;

        menuCanvas.SetActive(true);
        menuCanvas.GetComponent<Canvas>().enabled = false;

        endGameCanvas.SetActive(true);
        endGameCanvas.GetComponent<Canvas>().enabled = true;

        endGameCanvas.GetComponent<EndGameManager>().SetValues(time, score);

        wc.StopGame();
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame");
        endGameCanvas.SetActive(false);
        endGameCanvas.GetComponent<Canvas>().enabled = false;

        menuCanvas.SetActive(true);
        menuCanvas.GetComponent<Canvas>().enabled = true;
    }
}
