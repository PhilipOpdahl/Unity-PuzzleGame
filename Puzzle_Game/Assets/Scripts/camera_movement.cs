using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    
    public GameObject Cube;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Cube.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Cube.transform.position + offset;
    }
}
