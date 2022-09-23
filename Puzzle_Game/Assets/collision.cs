using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{   
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Wall")
        {
            Debug.Log("Uh oh, we hit wall");
        }
    }
}
