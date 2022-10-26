using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
   void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
	}
}
