using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveTimer : MonoBehaviour
{
    Animator anim;

    public Image clock;

    bool once;

    GameObject player;
    public GameObject spawner;
    public GameObject spawnerGO;
    public static Transform checkpoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim.SetBool("Once", once);
    }

    public void Revive()
    {
        Destroy(spawner);
        Destroy(player);
        spawner = Instantiate(spawnerGO, checkpoint.position, Quaternion.identity);
        once = true;
        gameObject.SetActive(false);
    }
}
