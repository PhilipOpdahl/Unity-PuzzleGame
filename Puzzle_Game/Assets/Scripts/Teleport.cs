using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public AudioClip collectibleSound;

    void OnTriggerEnter(Collider other) {
        AudioSource.PlayClipAtPoint(collectibleSound, transform.position,1f);
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
