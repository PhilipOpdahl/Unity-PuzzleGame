using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonActivate : MonoBehaviour
{
    public int KeyLock = 2;
    public GameObject Gate;
    public GameObject Gatebar;
    public GameObject Player;
    public GameObject Player2;
    public GameObject Player3;
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    public button script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyLock == 2)
        {
            Gate.gameObject.SetActive(false);
            Gatebar.gameObject.SetActive(false);
            Player.gameObject.SetActive(true);
            Player2.gameObject.SetActive(false);
            Player3.gameObject.SetActive(false);
            firstPersonCamera.enabled = true;
            overheadCamera.enabled = false;

        }
    }
}
