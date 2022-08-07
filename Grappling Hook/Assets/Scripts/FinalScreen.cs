using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    public GameObject failScreen;

    void Update()
    {
        if (!CharacterControls.alive)
            failScreen.SetActive(true);
        else
            failScreen.SetActive(false);
    }
}
