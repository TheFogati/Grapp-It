using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSound : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] steps;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        
    }

    public void Step()
    {
        audio.clip = steps[Random.Range(0, steps.Length)];
        audio.Play();
    }
}
