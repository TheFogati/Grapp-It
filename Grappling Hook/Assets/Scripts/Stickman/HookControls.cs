using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControls : MonoBehaviour
{
    public GameObject hook;
    public float force;
    public Transform gun;

    public bool hooked;

    void ShootHook()
    {
        hook.transform.parent = null;
        Rigidbody rbHook = hook.GetComponent<Rigidbody>();

        rbHook.isKinematic = false;
        rbHook.AddForce(hook.transform.forward * force, ForceMode.Impulse);
        //rbHook.velocity = new Vector3(rbHook.velocity.x, rbHook.velocity.y, force);
    }

    public void CallHookBack()
    {
        hooked = false;

        hook.transform.parent = gun;
        Rigidbody rbHook = hook.GetComponent<Rigidbody>();
        rbHook.isKinematic = false;

        rbHook.velocity = Vector3.zero;
        
        hook.transform.localPosition = new Vector3(0, 0, .2f);
        hook.transform.localRotation = Quaternion.Euler(0, 0, 0);
        hook.transform.localScale = Vector3.one;

        rbHook.isKinematic = true;
    }

    public void Hooked(Transform surface)
    {
        hooked = true;

        hook.transform.parent = surface;
        Rigidbody rbHook = hook.GetComponent<Rigidbody>();

        rbHook.velocity = Vector3.zero;
        rbHook.isKinematic = true;
    }
}
