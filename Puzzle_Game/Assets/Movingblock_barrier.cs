using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingblock_barrier : MonoBehaviour
{
    public GameObject Right;
    public GameObject Left;
    public GameObject Front;
    public GameObject Back;
    public GameObject Platform_Col;

    private int updatedRight = 1;
    private int updatedLeft = 1;

    Vector3 temp = new Vector3(0,2,0);

    // Start is called before the first frame update
    void Start()
    {
        //GroundWall.gameObject.SetActive(true);
    }


    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("RightZone")  && updatedRight == 1){
            Right.gameObject.transform.position += temp;
            Front.gameObject.transform.position += temp;
            Back.gameObject.transform.position += temp;
            Platform_Col.gameObject.transform.position += temp;
            Invoke("BuildRightWall", 1f);
            updatedRight = 0;

        }

        if (other.CompareTag("LeftZone")  && updatedLeft == 1){
            Left.gameObject.transform.position += temp;
            Front.gameObject.transform.position += temp;
            Back.gameObject.transform.position += temp;
            Platform_Col.gameObject.transform.position += temp;
            Invoke("BuildLeftWall", 1f);
            updatedLeft = 0;

        }
    }

    void BuildRightWall()
    {
        Right.gameObject.transform.position -= temp;
        Front.gameObject.transform.position -= temp;
        Back.gameObject.transform.position -= temp;
        Platform_Col.gameObject.transform.position -= temp;
        updatedRight = 1;
    }

    void BuildLeftWall()
    {
        Left.gameObject.transform.position -= temp;
        Front.gameObject.transform.position -= temp;
        Back.gameObject.transform.position -= temp;
        Platform_Col.gameObject.transform.position -= temp;
        updatedLeft = 1;
    }
}
