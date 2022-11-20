using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    public GameObject failScreen;
    public GameObject winScreen;


    void Update()
    {
        if (!CharacterControls.alive)
            failScreen.SetActive(true);
        else
            failScreen.SetActive(false);

        if(CharacterControls.win)
            winScreen.SetActive(true);
        else
            winScreen.SetActive(false);
    }
}
