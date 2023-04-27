using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayHandler : MonoBehaviour
{
    [SerializeField] Canvas minimap;
    [SerializeField] GameObject game;

    private GameManager gameManager;

    private WheelController wc;
    private int level;

    void Start()
    {
        game.TryGetComponent<GameManager>(out gameManager);
        level = 0;
    }

    public void LaunchGame()
    {
        gameManager.StartGame(level);
    }

    public void UpdateDropdown(int dropdownLevel)
    {
        level = dropdownLevel;
    }
}
