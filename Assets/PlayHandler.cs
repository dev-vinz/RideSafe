using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHandler : MonoBehaviour
{
    [SerializeField] Canvas minimap;

    public void LaunchGame()
    {
        // Get the parent object
        GameObject parent = transform.parent.gameObject;

        // Make it insivible
        parent.SetActive(false);

        minimap.enabled = true;
    }
}
