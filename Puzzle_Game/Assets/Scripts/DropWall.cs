using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWall : MonoBehaviour
{
[SerializeField] private Animator MyAnimationController;

private void OnTriggerEnter(Collider other)  {
    if (other.CompareTag("Player")) {
        MyAnimationController.SetBool("PlayAnimation", true);
        MyAnimationController.SetBool("PlayAnimation2", false);
        MyAnimationController.SetBool("StopAnimation", false);
    }
}

private void OnTriggerExit(Collider other)  {
    if (other.CompareTag("Player")) {
        MyAnimationController.SetBool("PlayAnimation", false);
        MyAnimationController.SetBool("PlayAnimation2", true);
        //MyAnimationController.SetBool("StopAnimation", false);
        Invoke("WallReset", 2f);
    }
}

void WallReset(){
    MyAnimationController.SetBool("StopAnimation", true);
}

}