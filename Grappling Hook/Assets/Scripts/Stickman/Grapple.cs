using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public static bool grappling = false;

    public void Grab()
    {
        grappling = true;
    }

    public void Release()
    {
        grappling = false;
    }
}
