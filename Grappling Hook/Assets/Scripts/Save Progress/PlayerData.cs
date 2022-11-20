using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;
    public int stickmenPrice;
    public int grapplingHooksPrice;

    public bool[] unlockedSimpleStickman;
    public bool[] selectedSimpleStickman;
    public bool[] unlockedEpicStickman;
    public bool[] selectedEpicStickman;

    public bool[] unlockedSimpleHook;
    public bool[] selectedSimpleHook;
    public bool[] unlockedEpicHook;
    public bool[] selectedEpicHook;

    public int unlockEpicValue;
    public bool unlockStick;

    public PlayerData()
    {
        money = GameManager.manager.money;
        stickmenPrice = GameManager.manager.stickmenPrice;
        grapplingHooksPrice = GameManager.manager.grapplingHooksPrice;

        #region Stickmen
        unlockedSimpleStickman = new bool[GameManager.manager.simpleStickman.Length];
        for (int u = 0; u < GameManager.manager.simpleStickman.Length; u++)
            unlockedSimpleStickman[u] = GameManager.manager.simpleStickman[u].isUnlocked;

        selectedSimpleStickman = new bool[GameManager.manager.simpleStickman.Length];
        for (int s = 0; s < GameManager.manager.simpleStickman.Length; s++)
            selectedSimpleStickman[s] = GameManager.manager.simpleStickman[s].isSelected;


        unlockedEpicStickman = new bool[GameManager.manager.epicStickman.Length];
        for (int u = 0; u < GameManager.manager.epicStickman.Length; u++)
            unlockedEpicStickman[u] = GameManager.manager.epicStickman[u].isUnlocked;

        selectedEpicStickman = new bool[GameManager.manager.epicStickman.Length];
        for (int s = 0; s < GameManager.manager.epicStickman.Length; s++)
            selectedEpicStickman[s] = GameManager.manager.epicStickman[s].isSelected;
        #endregion

        #region Grappling Hooks
        unlockedSimpleHook = new bool[GameManager.manager.simpleGrapplingHook.Length];
        for (int u = 0; u < GameManager.manager.simpleGrapplingHook.Length; u++)
            unlockedSimpleHook[u] = GameManager.manager.simpleGrapplingHook[u].isUnlocked;

        selectedSimpleHook = new bool[GameManager.manager.simpleGrapplingHook.Length];
        for (int s = 0; s < GameManager.manager.simpleGrapplingHook.Length; s++)
            selectedSimpleHook[s] = GameManager.manager.simpleGrapplingHook[s].isSelected;


        unlockedEpicHook = new bool[GameManager.manager.epicGrapplingHook.Length];
        for (int u = 0; u < GameManager.manager.epicGrapplingHook.Length; u++)
            unlockedEpicHook[u] = GameManager.manager.epicGrapplingHook[u].isUnlocked;

        selectedEpicHook = new bool[GameManager.manager.epicGrapplingHook.Length];
        for (int s = 0; s < GameManager.manager.epicGrapplingHook.Length; s++)
            selectedEpicHook[s] = GameManager.manager.epicGrapplingHook[s].isSelected;
        #endregion

        unlockEpicValue = GameManager.manager.unlockEpicValue;
        unlockStick = GameManager.manager.unlockStick;
    }
}
