using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpicUnlocker : MonoBehaviour
{
    bool stickmanToUnlock;
    bool grapplerToUnlock;

    public Slider slider;
    public GameObject unlockBTN;
    public Text txtToUnlock;
    [Space]
    public GameObject unlockPanel;

    void Start()
    {
        stickmanToUnlock = false;
        grapplerToUnlock = false;
    }

    void Update()
    {
        CheckAvailability();

        if(!stickmanToUnlock && !grapplerToUnlock)
        {
            txtToUnlock.text = "Nothing";
            slider.gameObject.SetActive(false);
            unlockBTN.SetActive(false);
        }
        else
        {
            if (!stickmanToUnlock)
                GameManager.manager.unlockStick = false;
            if (!grapplerToUnlock)
                GameManager.manager.unlockStick = true;

            slider.value = GameManager.manager.unlockEpicValue;

            if (GameManager.manager.unlockStick)
                txtToUnlock.text = "A Epic Stickman";
            else
                txtToUnlock.text = "A Epic Grappler";

            if (GameManager.manager.unlockEpicValue >= 100)
            {
                slider.gameObject.SetActive(false);
                unlockBTN.SetActive(true);
            }
            else
            {
                slider.gameObject.SetActive(true);
                unlockBTN.SetActive(false);
            }
        }
    }

    void CheckAvailability()
    {
        foreach(EpicStickman es in GameManager.manager.epicStickman)
        {
            if(!es.isUnlocked)
            {
                stickmanToUnlock = true;
                break;
            }
        }
        foreach(EpicGrapplingHook eg in GameManager.manager.epicGrapplingHook)
        {
            if(!eg.isUnlocked)
            {
                grapplerToUnlock = true;
                break;
            }
        }
    }

    public void UnlockIt()
    {
        if (GameManager.manager.unlockStick)
            CheckStick();
        else
            CheckGrapp();

        GameManager.manager.unlockEpicValue = 0;
        GameManager.manager.unlockStick = !GameManager.manager.unlockStick;

        unlockPanel.SetActive(true);
        SaveSystem.SaveGame();
    }

    void CheckStick()
    {
        int rnd = Random.Range(0, GameManager.manager.epicStickman.Length);
        if (GameManager.manager.epicStickman[rnd].isUnlocked)
            CheckStick();
        else
            GameManager.manager.epicStickman[rnd].isUnlocked = true;
    }

    void CheckGrapp()
    {
        int rnd = Random.Range(0, GameManager.manager.epicGrapplingHook.Length);
        if (GameManager.manager.epicGrapplingHook[rnd].isUnlocked)
            CheckGrapp();
        else
            GameManager.manager.epicGrapplingHook[rnd].isUnlocked = true;
    }

    public void CloseTab(GameObject g)
    {
        g.SetActive(false);
    }
}
