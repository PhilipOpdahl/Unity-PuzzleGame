using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    [SerializeField] private Animator myAnimationController;

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider>().tag == "Player")
        {
        myAnimationController.SetBool("Start_dissolve", true);
        myAnimationController.SetBool("End_dissolve", false);
        myAnimationController.SetBool("Static", false);
    }
            Invoke("YouWin", 1.5f);
        }

    void YouWin(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
