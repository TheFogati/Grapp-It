using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProgress : MonoBehaviour
{
    private void Start()
    {
        PlayerData data = SaveSystem.LoadGame();

        GameManager.manager.money = data.money;
        GameManager.manager.stickmenPrice = data.stickmenPrice;
        GameManager.manager.grapplingHooksPrice = data.grapplingHooksPrice;


        for (int s = 0; s < GameManager.manager.simpleStickman.Length; s++)
        {
            GameManager.manager.simpleStickman[s].isUnlocked = data.unlockedSimpleStickman[s];
            GameManager.manager.simpleStickman[s].isSelected = data.selectedSimpleStickman[s];
        }
        for (int e = 0; e < GameManager.manager.epicStickman.Length; e++)
        {
            GameManager.manager.epicStickman[e].isUnlocked = data.unlockedEpicStickman[e];
            GameManager.manager.epicStickman[e].isSelected = data.selectedEpicStickman[e];
        }

        for (int s = 0; s < GameManager.manager.simpleGrapplingHook.Length; s++)
        {
            GameManager.manager.simpleGrapplingHook[s].isUnlocked = data.unlockedSimpleHook[s];
            GameManager.manager.simpleGrapplingHook[s].isSelected = data.selectedSimpleHook[s];
        }
        for(int e = 0; e < GameManager.manager.epicGrapplingHook.Length; e++)
        {
            GameManager.manager.epicGrapplingHook[e].isUnlocked = data.unlockedEpicHook[e];
            GameManager.manager.epicGrapplingHook[e].isSelected = data.selectedEpicHook[e];
        }
    }
}
