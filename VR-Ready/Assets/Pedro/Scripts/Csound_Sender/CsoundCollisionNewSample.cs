using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundCollisionNewSample : MonoBehaviour
{
    public AudioClip[] samples;
    public AudioSource audio;


    private void OnCollisionEnter(Collision collision)
    {
        audio.clip = samples[Random.Range(0, samples.Length)];
        audio.Play();
    }
}
