using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDrone : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource aSource;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Pincel")) { return; }

        if (!aSource.isPlaying)
        {
            aSource.clip = clips[Random.Range(0, clips.Length)];
            aSource.Play();
        }
        else
        {
            aSource.Stop();
        }
    }

}
