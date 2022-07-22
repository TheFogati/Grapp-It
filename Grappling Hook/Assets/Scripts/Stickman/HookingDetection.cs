using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookingDetection : MonoBehaviour
{
    public HookControls hookControl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GrapplingSurface")
            hookControl.Hooked(other.transform);
    }
}
