using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControls : MonoBehaviour
{
    public GameObject hook;
    public float force;
    public Transform gun;

    public bool hooked;

    public Vector3 hookStartPosition;
    public Quaternion hookStartRotation;
    public Vector3 hookStartScale;

    private void Start()
    {
        hook = CharacterControls.hook.gameObject;

        hookStartPosition = hook.transform.localPosition;
        hookStartRotation = hook.transform.localRotation;
        hookStartScale = hook.transform.localScale;
    }

    void ShootHook()
    {
        hook.transform.parent = null;
        Rigidbody rbHook = hook.GetComponent<Rigidbody>();

        rbHook.isKinematic = false;
        rbHook.AddForce(hook.transform.forward * force, ForceMode.Impulse);
    }

    public void CallHookBack()
    {
        hooked = false;

        hook.transform.parent = gun;
        Rigidbody rbHook = hook.GetComponent<Rigidbody>();
        rbHook.isKinematic = false;

        rbHook.velocity = Vector3.zero;

        hook.transform.localPosition = hookStartPosition;
        hook.transform.localRotation = hookStartRotation;
        hook.transform.localScale = hookStartScale;

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
