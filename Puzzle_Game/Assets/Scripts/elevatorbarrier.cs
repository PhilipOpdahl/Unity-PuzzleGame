using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorbarrier : MonoBehaviour
{
    public GameObject GroundWall;
    public GameObject TopWall;

    private int updatedHigh = 1;
    private int updatedLow = 1;

    Vector3 temp = new Vector3(-1,0,0);
    Vector3 tempSide = new Vector3(0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        GroundWall.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.95f && updatedLow == 1){
            Invoke("RemoveLowWall", 0.2f);
            updatedLow = 0;
            updatedHigh = 1;
            Invoke("BuildLowWall", 2f);
        }

        if (transform.position.y > 4.85f && updatedHigh == 1){
            TopWall.transform.position += tempSide;
            updatedHigh = 0;
            updatedLow = 1;
            Invoke("BuildHighWall", 2f);
        }
    }

    void BuildLowWall()
    {
        GroundWall.transform.position -= 5*tempSide;
    }

    void BuildHighWall()
    {
        TopWall.transform.position -= tempSide;
    }

    void RemoveLowWall()
    {
        GroundWall.transform.position += 5*tempSide;
    }
}
