using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Animator myAnimationController;
    public Transform teleportTarget;
    public GameObject thePlayer;
    public AudioClip collectibleSound;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {

        myAnimationController.SetBool("Start_dissolve", true);
        myAnimationController.SetBool("End_dissolve", false);
        myAnimationController.SetBool("Static", false);
        Invoke("Dissolve", 1f);

        AudioSource.PlayClipAtPoint(collectibleSound, transform.position,1f);
    }
    }

    void Dissolve() {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
        myAnimationController.SetBool("Start_dissolve", false);
        myAnimationController.SetBool("End_dissolve", true);
        myAnimationController.SetBool("Static", false);
   }
   }
}
