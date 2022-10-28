using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
   [SerializeField] private Animator myAnimationController;

   private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
        myAnimationController.SetBool("WallDown", true);
        myAnimationController.SetBool("WallUp", false);
        myAnimationController.SetBool("Stop", false);
    }
   }

void ResetWall() {
    myAnimationController.SetBool("WallUp", true);
}

   private void OnTriggerExit(Collider other) {
    if (other.CompareTag("Player")) {
        myAnimationController.SetBool("WallDown", false);
        Invoke("ResetWall", 2f);
    }
   }
   
}

