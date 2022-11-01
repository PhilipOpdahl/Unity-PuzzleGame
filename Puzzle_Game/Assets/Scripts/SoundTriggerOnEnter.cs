using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerOnEnter : MonoBehaviour
{
    AudioSource source;

    Collider soundTrigger;

    void Awake()
    {
       source = GetComponent<AudioSource>(); 
       soundTrigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            source.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Stop();
    }
}
