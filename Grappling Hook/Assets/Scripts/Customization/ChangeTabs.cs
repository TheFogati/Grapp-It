using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTabs : MonoBehaviour
{
    public StoreManager storeManager;
    [Space]
    public Animator character;
    public GameObject charFocus;
    [Space]
    public GameObject characterTab;
    public GameObject grapplingTab;
    bool hookFocusing;

    private void Update()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        character.SetBool("HookFocus", hookFocusing);
    }

    public void CharacterChange()
    {
        characterTab.SetActive(true);
        grapplingTab.SetActive(false);

        hookFocusing = false;
        charFocus.SetActive(true);

        storeManager.SelectStickman(StoreManager.stickman);
    }

    public void GrapplingChange()
    {
        characterTab.SetActive(false);
        grapplingTab?.SetActive(true);

        hookFocusing = true;
        charFocus.SetActive(false);

        storeManager.SelectGrappling(StoreManager.grappling);
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
