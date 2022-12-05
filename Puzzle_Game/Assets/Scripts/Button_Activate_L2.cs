using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Activate_L2 : MonoBehaviour
{
    public int KeyLock = 2;
    public GameObject Gate;
    public GameObject Gatebar;
    public GameObject Player;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    //public GameObject ForceFieldSFX;

    public GameObject Trigger;

    public Button_L2 script;
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
            Trigger.gameObject.SetActive(false);
            //ForceFieldSFX.gameObject.SetActive(false);
            
            Invoke("Teleport", 1f);
            

        }
    }

    void Teleport(){
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        Player.gameObject.SetActive(true);
        Player2.gameObject.SetActive(false);
        Player3.gameObject.SetActive(false);
        Player4.gameObject.SetActive(false);
    }
}
