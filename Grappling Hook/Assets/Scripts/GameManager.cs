using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimpleStickman
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool isSelected;
}

[System.Serializable]
public class EpicStickman
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool isSelected;
}

[System.Serializable]
public class SimpleGrapplingHook
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool isSelected;
}

[System.Serializable]
public class EpicGrapplingHook
{
    public string name;
    public GameObject model;
    public bool isUnlocked;
    public bool isSelected;
}

public class GameManager : MonoBehaviour
{
    public SimpleStickman[] simpleStickman;
    public EpicStickman[] epicStickman;
    public SimpleGrapplingHook[] simpleGrapplingHook;
    public EpicGrapplingHook[] epicGrapplingHook;
    #region Don't Destroy
    public static GameManager manager;
    void Awake()
    {
        if (!manager)
            manager = this;
        else if (manager)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
    #endregion
}
