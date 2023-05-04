using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitHandler : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Quit Game");

        // Quit the game
        Application.Quit();
    }
}
