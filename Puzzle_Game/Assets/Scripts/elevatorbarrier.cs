using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorbarrier : MonoBehaviour
{
    public GameObject GroundWall;
    public GameObject TopWall;
    // Start is called before the first frame update
    void Start()
    {
        GroundWall.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        
            GroundWall.gameObject.SetActive(false);
        
       
	}

    void OnCollisionExit(Collision collisionInfo)
    {
         
            GroundWall.gameObject.SetActive(true);
        
       
	}
}
