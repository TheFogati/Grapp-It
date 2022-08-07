using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    [Header("Movement")]
    public float holdTime;
    public float speed;
    public float jumpForce;
    public string[] deathTags;

    [Header("Check Ground")]
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask whatIsGround;
    bool isGrounded;

    [Header("Grappling Gun")]
    public Transform gunPoint;
    public HookControls hookControl;
    public GameObject gun;
    static public Transform hook;
    public float hookForce;

    public static bool alive;

    float timeHolding;
    bool releaseMe;
    bool grappling;
    bool roll;

    RaycastHit groundDistance;
    string groundName;

    void Start()
    {
        alive = true;

        anim = GetComponentInChildren<Animator>();

        gun = Instantiate(SpawnPlayer.grapplingGun, transform.position, Quaternion.identity);
        gun.transform.SetParent(gunPoint);
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localRotation = Quaternion.Euler(0, 0, 0);

        hook = GetComponentInChildren<HookingDetection>().transform;

        rb = GetComponent<Rigidbody>();
        Alive(true);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radiusCheck, whatIsGround);

        anim.SetBool("Grounded", isGrounded);

        if (!hookControl.hooked)
        {
            if(isGrounded)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);

            if (Vector3.Distance(hook.position, transform.position) > 25)
            {
                grappling = false;
                anim.SetBool("Grappling", false);
                hookControl.CallHookBack();
                releaseMe = true;
            }
        }
        else
        {
            Vector3 f = hook.position - transform.position;
            rb.AddForce(f.normalized * hookForce);

            if(hook.position.z - transform.position.z <= - 4)
            {
                grappling = false;
                anim.SetBool("Grappling", false);
                hookControl.CallHookBack();
                releaseMe = true;
            }
        }

        Commands();
        /*
        if(transform.position.y >= 2 && !grappling)
            roll = true;
        */

        if(Physics.Raycast(transform.position, Vector3.down ,out groundDistance))
        {
            if (groundDistance.collider.name != groundName)
                roll = false;

            if (groundDistance.collider.tag == "Ground")
            {
                groundName = groundDistance.collider.name;
                if (Vector2.Distance(transform.position, groundDistance.point) >= 2)
                    roll = true;
            }
        }

        anim.SetBool("Roll", roll);
        anim.SetFloat("JumpValue", rb.velocity.y);

        if (isGrounded || grappling)
            roll = false;

    }

    void Commands()
    {
        if (Input.GetKey(KeyCode.J))
        {
            if(!releaseMe)
            {
                timeHolding += Time.deltaTime;
                if (timeHolding >= holdTime)
                {
                    grappling = true;
                    anim.SetBool("Grappling", true);
                }
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
                grappling = false;
                anim.SetBool("Grappling", false);
            }

            timeHolding = 0;
        }
    }


    void Alive(bool state)
    {
        alive = state;
        anim.enabled = state;
        SetRigidBodyState(!state);
        SetColliderState(!state);
    }

    void SetRigidBodyState(bool state)
    {
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbs)
        {
            r.isKinematic = !state;
            if(state)
                r.velocity = rb.velocity;
        }

        rb.isKinematic = state;
    }

    void SetColliderState(bool state)
    {
        Collider[] col = GetComponentsInChildren<Collider>();

        foreach (Collider c in col)
            c.enabled = state;

        GetComponent<Collider>().enabled = !state;
        hook.GetComponentInChildren<Collider>().enabled = !state;
    }


    private void OnCollisionEnter(Collision collision)
    {
        foreach (string s in deathTags)
        {
            if (collision.gameObject.tag == s)
                Alive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radiusCheck);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundDistance.point, .15f);
    }
}
