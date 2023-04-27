using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayHandler : MonoBehaviour
{
    [SerializeField] Canvas minimap;
    [SerializeField] GameObject carScript;

    private WheelController wc;
    private int level;

    void Start()
    {
        carScript.TryGetComponent<WheelController>(out wc);
        level = 0;
    }

    public void LaunchGame()
    {
        // Get the parent object
        GameObject parent = transform.parent.gameObject;

        // Make it insivible
        parent.SetActive(false);

        minimap.enabled = true;

        if(wc != null)
        {
            wc.LaunchGame(level);
        }
    }

    public void UpdateDropdown(int dropdownLevel)
    {
        level = dropdownLevel;
    }
}
