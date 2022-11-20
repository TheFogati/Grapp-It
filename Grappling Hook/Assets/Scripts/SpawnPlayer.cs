using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    GameObject stickman;
    [SerializeField]public static GameObject grapplingGun;

    void Awake()
    {
        foreach (SimpleStickman ss in GameManager.manager.simpleStickman)
        {
            if (ss.isSelected)
                stickman = ss.model;
        }
        foreach (EpicStickman es in GameManager.manager.epicStickman)
        {
            if (es.isSelected)
                stickman = es.model;
        }

        foreach (SimpleGrapplingHook sg in GameManager.manager.simpleGrapplingHook)
        {
            if(sg.isSelected)
                grapplingGun = sg.model;
        }

        foreach (EpicGrapplingHook eg in GameManager.manager.epicGrapplingHook)
        {
            if (eg.isSelected)
                grapplingGun = eg.model;
        }

        Instantiate(stickman, transform.position, Quaternion.identity);
    }
}
