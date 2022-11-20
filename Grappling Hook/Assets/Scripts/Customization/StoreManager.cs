using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public Button stickmanBTN;
    public Button grapplingBTN;
    public Text stickmanText;
    public Text grapplingText;
    public Text stickmanPrice;
    public Text grapplingPrice;

    public static bool epicStickman;
    public static bool epicGrappling;
    bool toEquip;

    public static int stickman;
    public static int grappling;

    private void Start()
    {
        for (int n = 0; n < GameManager.manager.simpleStickman.Length; n++)
        {
            if (GameManager.manager.simpleStickman[n].isSelected)
                stickman = n;
        }
        for (int n = 0; n < GameManager.manager.epicStickman.Length; n++)
        {
            if (GameManager.manager.epicStickman[n].isSelected)
                stickman = n;
        }

        for (int n = 0; n < GameManager.manager.simpleGrapplingHook.Length; n++)
        {
            if (GameManager.manager.simpleGrapplingHook[n].isSelected)
                grappling = n;
        }
        for (int n = 0; n < GameManager.manager.epicGrapplingHook.Length; n++)
        {
            if (GameManager.manager.epicGrapplingHook[n].isSelected)
                grappling = n;
        }

        CheckStickmanAvailability(stickman);
        CheckGrapplingAvailability(grappling);
    }

    void Update()
    {
        stickmanPrice.text = GameManager.manager.stickmenPrice.ToString();
        grapplingPrice.text = GameManager.manager.grapplingHooksPrice.ToString();

        if(!toEquip)
        {
            stickmanPrice.enabled = true;
            grapplingPrice.enabled = true;
        }
        else
        {
            stickmanPrice.enabled = false;
            grapplingPrice.enabled = false;
        }
    }

    public void BuyEquipStickman()
    {
        if(toEquip)
        {
            if (!epicStickman)
            {
                foreach (SimpleStickman ss in GameManager.manager.simpleStickman)
                {
                    if (ss.isSelected)
                        ss.isSelected = false;
                }
                foreach (EpicStickman es in GameManager.manager.epicStickman)
                {
                    if (es.isSelected)
                        es.isSelected = false;
                }

                epicStickman = false;
                GameManager.manager.simpleStickman[stickman].isSelected = true;
                CheckStickmanAvailability(stickman);
            }
            else
            {
                foreach (SimpleStickman ss in GameManager.manager.simpleStickman)
                {
                    if (ss.isSelected)
                        ss.isSelected = false;
                }
                foreach (EpicStickman es in GameManager.manager.epicStickman)
                {
                    if (es.isSelected)
                        es.isSelected = false;
                }

                epicStickman = true;
                GameManager.manager.epicStickman[stickman].isSelected = true;
                CheckStickmanAvailability(stickman);
            }
        }
        else
        {
            if(!epicStickman)
            {
                if (GameManager.manager.money >= GameManager.manager.stickmenPrice)
                {
                    GameManager.manager.money -= GameManager.manager.stickmenPrice;
                    GameManager.manager.stickmenPrice += 20;

                    GameManager.manager.simpleStickman[stickman].isUnlocked = true;
                    CheckStickmanAvailability(stickman);
                    BuyEquipStickman();
                }
            }

            
        }
        SaveSystem.SaveGame();
    }
    public void BuyEquipGrappling()
    {
        if(toEquip)
        {
            if(!epicGrappling)
            {
                foreach (SimpleGrapplingHook sgh in GameManager.manager.simpleGrapplingHook)
                {
                    if (sgh.isSelected)
                        sgh.isSelected = false;
                }
                foreach (EpicGrapplingHook egh in GameManager.manager.epicGrapplingHook)
                {
                    if (egh.isSelected)
                        egh.isSelected = false;
                }

                epicGrappling = false;
                GameManager.manager.simpleGrapplingHook[grappling].isSelected = true;
                CheckGrapplingAvailability(grappling);
            }
            else
            {
                foreach (SimpleGrapplingHook sgh in GameManager.manager.simpleGrapplingHook)
                {
                    if (sgh.isSelected)
                        sgh.isSelected = false;
                }
                foreach (EpicGrapplingHook egh in GameManager.manager.epicGrapplingHook)
                {
                    if (egh.isSelected)
                        egh.isSelected = false;
                }

                epicGrappling = true;
                GameManager.manager.epicGrapplingHook[grappling].isSelected = true;
                CheckGrapplingAvailability(grappling);
            }
        }
        else
        {
            if(!epicGrappling)
            {
                if(GameManager.manager.money >= GameManager.manager.grapplingHooksPrice)
                {
                    GameManager.manager.money -= GameManager.manager.grapplingHooksPrice;
                    GameManager.manager.grapplingHooksPrice += 20;

                    GameManager.manager.simpleGrapplingHook[grappling].isUnlocked = true;
                    CheckGrapplingAvailability(grappling);
                    BuyEquipGrappling();
                }
            }
        }
        SaveSystem.SaveGame();
    }


    public void IsEpicStickman(bool i)
    {
        epicStickman = i;
    }
    public void IsEpicGrappling(bool i)
    {
        epicGrappling = i;
    }

    public void SelectStickman(int i)
    {
        stickman = i;
        CheckStickmanAvailability(i);
    }

    public void SelectGrappling(int i)
    {
        grappling = i;
        CheckGrapplingAvailability(i);
    }


    void CheckStickmanAvailability(int i)
    {
        if(!epicStickman)
        {
            if(GameManager.manager.simpleStickman[i].isSelected)
            {
                toEquip = true;
                stickmanBTN.interactable = false;
                stickmanText.text = "Equipped";
            }
            else
            {
                stickmanBTN.interactable = true;

                if (GameManager.manager.simpleStickman[i].isUnlocked)
                {
                    toEquip = true;
                    stickmanText.text = "Equip";
                }
                else
                {
                    toEquip = false;
                    stickmanText.text = "Buy";

                }
            }
            
        }
        else
        {
            if(GameManager.manager.epicStickman[i].isSelected)
            {
                toEquip = true;
                stickmanBTN.interactable = false;
                stickmanText.text = "Equipped";
            }
            else
            {
                if (GameManager.manager.epicStickman[i].isUnlocked)
                {
                    toEquip = true;
                    stickmanBTN.interactable = true;
                    stickmanText.text = "Equip";
                }
                else
                {
                    toEquip = false;
                    stickmanBTN.interactable = false;
                    stickmanText.text = "Locked";
                }
            }
        }
    }

    void CheckGrapplingAvailability(int i)
    {
        if (!epicGrappling)
        {
            if (GameManager.manager.simpleGrapplingHook[i].isSelected)
            {
                toEquip = true;
                grapplingBTN.interactable = false;
                grapplingText.text = "Equipped";
            }
            else
            {
                grapplingBTN.interactable = true;

                if (GameManager.manager.simpleGrapplingHook[i].isUnlocked)
                {
                    toEquip = true;
                    grapplingText.text = "Equip";
                }
                else
                {
                    toEquip = false;
                    grapplingText.text = "Buy";
                }
            }

        }
        else
        {
            if (GameManager.manager.epicGrapplingHook[i].isSelected)
            {
                toEquip = true;
                grapplingBTN.interactable = false;
                grapplingText.text = "Equipped";
            }
            else
            {
                if (GameManager.manager.epicGrapplingHook[i].isUnlocked)
                {
                    toEquip = true;
                    grapplingBTN.interactable = true;
                    grapplingText.text = "Equip";
                }
                else
                {
                    toEquip = false;
                    grapplingBTN.interactable = false;
                    grapplingText.text = "Locked";
                }
            }
        }
    }
}
