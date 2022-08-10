using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTabs : MonoBehaviour
{
    public Image showcase;
    public Sprite[] showing;
    [Space]
    public GameObject characterTab;
    public GameObject grapplingTab;

    public void CharacterChange()
    {
        characterTab.SetActive(true);
        grapplingTab.SetActive(false);
        showcase.sprite = showing[0];
    }

    public void GrapplingChange()
    {
        characterTab.SetActive(false);
        grapplingTab?.SetActive(true);
        showcase.sprite = showing[1];
    }

    public void ChooseEpic(GameObject e)
    {
        e.SetActive(true);
    }

    public void ChooseCommon(GameObject e)
    {
        e.SetActive(false);
    }
}
