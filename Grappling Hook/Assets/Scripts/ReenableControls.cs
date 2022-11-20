using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReenableControls : MonoBehaviour
{
    private void Start()
    {
        GameManager.manager.controlEnabled = true;
    }
}
