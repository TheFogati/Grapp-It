using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProp : MonoBehaviour
{
    public GameObject brokenModel;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(brokenModel, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
