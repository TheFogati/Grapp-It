using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevDebug : MonoBehaviour
{
    public void UnlockAll()
    {
        for (int s = 0; s < GameManager.manager.simpleStickman.Length; s++)
        {
            GameManager.manager.simpleStickman[s].isUnlocked = true;
            GameManager.manager.simpleStickman[s].isSelected = false;
        }
        for (int e = 0; e < GameManager.manager.epicStickman.Length; e++)
        {
            GameManager.manager.epicStickman[e].isUnlocked = true;
            GameManager.manager.epicStickman[e].isSelected = false;
        }

        for (int s = 0; s < GameManager.manager.simpleGrapplingHook.Length; s++)
        {
            GameManager.manager.simpleGrapplingHook[s].isUnlocked = true;
            GameManager.manager.simpleGrapplingHook[s].isSelected = false;
        }
        for (int e = 0; e < GameManager.manager.epicGrapplingHook.Length; e++)
        {
            GameManager.manager.epicGrapplingHook[e].isUnlocked = true;
            GameManager.manager.epicGrapplingHook[e].isSelected = false;
        }

        GameManager.manager.simpleStickman[0].isSelected = true;
        GameManager.manager.simpleGrapplingHook[0].isSelected = true;

        SaveSystem.SaveGame();

        SceneManager.LoadScene(0);
    }

    public void LockAll()
    {
        for (int s = 0; s < GameManager.manager.simpleStickman.Length; s++)
        {
            GameManager.manager.simpleStickman[s].isUnlocked = false;
            GameManager.manager.simpleStickman[s].isSelected = false;
        }
        for (int e = 0; e < GameManager.manager.epicStickman.Length; e++)
        {
            GameManager.manager.epicStickman[e].isUnlocked = false;
            GameManager.manager.epicStickman[e].isSelected = false;
        }

        for (int s = 0; s < GameManager.manager.simpleGrapplingHook.Length; s++)
        {
            GameManager.manager.simpleGrapplingHook[s].isUnlocked = false;
            GameManager.manager.simpleGrapplingHook[s].isSelected = false;
        }
        for (int e = 0; e < GameManager.manager.epicGrapplingHook.Length; e++)
        {
            GameManager.manager.epicGrapplingHook[e].isUnlocked = false;
            GameManager.manager.epicGrapplingHook[e].isSelected = false;
        }

        GameManager.manager.simpleStickman[0].isUnlocked = true;
        GameManager.manager.simpleGrapplingHook[0].isUnlocked = true;
        GameManager.manager.simpleStickman[0].isSelected = true;
        GameManager.manager.simpleGrapplingHook[0].isSelected = true;

        GameManager.manager.stickmenPrice = 200;
        GameManager.manager.grapplingHooksPrice = 200;

        GameManager.manager.money = 0;

        SaveSystem.SaveGame();

        SceneManager.LoadScene(0);
    }

    public void HESOYAM()
    {
        GameManager.manager.money += 250000;

        SaveSystem.SaveGame();
    }
}
