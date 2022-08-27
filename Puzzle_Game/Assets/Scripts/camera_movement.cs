using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    
    public GameObject Cube;

    private Vector3 offset;

    public bool cameraStop;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Cube.transform.position;

    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            cameraStop = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraStop == false)
        {
            transform.position = Cube.transform.position + offset;   
        }

        cameraStop = false;

        
    }
}
