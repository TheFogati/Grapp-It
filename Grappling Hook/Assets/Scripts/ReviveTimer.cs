using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveTimer : MonoBehaviour
{
    Animator anim;

    public Image clock;

    bool clockStart;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(clockStart)
        {
            clock.fillAmount -= (Time.deltaTime / 5);
            if (clock.fillAmount <= 0)
            {
                anim.SetTrigger("TimeOut");
                clockStart = false;
            }
        }
    }

    public void StartCountdown()
    {
        clockStart = true;
    }
}
