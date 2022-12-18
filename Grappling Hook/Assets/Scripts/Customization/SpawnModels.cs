using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModels : MonoBehaviour
{
    public GameObject[] simpleCharModel;
    public GameObject[] epicCharModel;
    public GameObject[] simpleHookModel;
    public GameObject[] epicHookModel;

    GameObject characterShown;
    public static GameObject hookShown;

    int characterNum;

    void Start()
    {
        ShowModelAlreadyUsing();
    }


    public void SelectCharacter(int i)
    {
        characterNum = i;

        if (characterShown != null)
            Destroy(characterShown);

        if(!StoreManager.epicStickman)
            characterShown = Instantiate(simpleCharModel[i], transform.position, Quaternion.identity);
        else
            characterShown = Instantiate(epicCharModel[i], transform.position, Quaternion.identity);
    }

    public void SelectGrappling(int i)
    {
        if(!StoreManager.epicGrappling)
            hookShown = simpleHookModel[i];
        else
            hookShown = epicHookModel[i];

        SelectCharacter(characterNum);
    }

    void ShowModelAlreadyUsing()
    {
        for (int n = 0; n < GameManager.manager.simpleGrapplingHook.Length; n++)
        {
            if (GameManager.manager.simpleGrapplingHook[n].isSelected)
                hookShown = simpleHookModel[n];
        }
        for (int n = 0; n < GameManager.manager.epicGrapplingHook.Length; n++)
        {
            if (GameManager.manager.epicGrapplingHook[n].isSelected)
                hookShown = epicHookModel[n];
        }

        for (int i = 0; i < GameManager.manager.simpleStickman.Length; i++)
        {
            if(GameManager.manager.simpleStickman[i].isSelected)
            {
                StoreManager.epicStickman = false;
                SelectCharacter(i);
            }
                
        }
        for (int i = 0; i < GameManager.manager.epicStickman.Length; i++)
        {
            if (GameManager.manager.epicStickman[i].isSelected)
            {
                StoreManager.epicStickman = true;
                SelectCharacter(i);
            }
        }
    }
}
