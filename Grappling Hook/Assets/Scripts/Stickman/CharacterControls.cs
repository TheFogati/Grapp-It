using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public Animator anim;
    public Transform model;
    Rigidbody rb;

    [Header("Movement")]
    public float holdTime;
    public float speed;
    public float jumpForce;

    [Header("Check Ground")]
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask whatIsGround;
    bool isGrounded;
    
    [Header("Grappling Gun")]
    public HookControls hookControl;
    public Transform hook;
    public float hookForce;

    float timeHolding;
    bool releaseMe;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radiusCheck, whatIsGround);
        anim.SetBool("Grounded", isGrounded);
        print(isGrounded);

        if (!hookControl.hooked)
        {
            if(isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }
        else
        {
            Vector3 f = hook.position - transform.position;
            rb.AddForce(f.normalized * hookForce);

            
            if(hook.position.z - transform.position.z <= - 4)
            {
                anim.SetBool("Grappling", false);
                hookControl.CallHookBack();
                releaseMe = true;
            }
        }

        
        Commands();
        
        


        anim.SetFloat("JumpValue", rb.velocity.y);
    }

    void Commands()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Dead();

        if (Input.GetKey(KeyCode.J))
        {
            if(!releaseMe)
            {
                timeHolding += Time.deltaTime;
                if (timeHolding >= holdTime)
                    anim.SetBool("Grappling", true);
            }
        }
        else
        {
            hookControl.CallHookBack();
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            releaseMe = false;

            if (timeHolding < holdTime)
            {
                if (isGrounded)
                {
                    rb.AddForce(Vector3.up * (jumpForce * 10));
                    anim.SetTrigger("Jump");
                }
            }
            else
            {
                anim.SetBool("Grappling", false);
            }

            
            timeHolding = 0;
        }
    }

    void Alive()
    {
        anim.enabled = true;

        Collider[] col = model.GetComponentsInChildren<Collider>();
        foreach(Collider c in col)
        {
            c.enabled = false;
        }
    }
    void Dead()
    {
        anim.enabled = false;

        Collider[] col = model.GetComponentsInChildren<Collider>();
        foreach (Collider c in col)
        {
            c.enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radiusCheck);
    }
}
