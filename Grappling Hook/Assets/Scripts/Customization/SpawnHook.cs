using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHook : MonoBehaviour
{
    GameObject gun;
    public Transform gunPoint;

    void Start()
    {
        gun = Instantiate(SpawnModels.hookShown, transform.position, Quaternion.identity);
        gun.transform.SetParent(gunPoint);
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
        
    }
}
