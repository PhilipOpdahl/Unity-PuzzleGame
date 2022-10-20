using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public bool IsRightPushed = false;
    public bool IsLeftPushed = false;
    public GameObject PlayerRight;
    public GameObject PlayerLeft;
    public GameObject Gate;
    public buttonActivate keylock;

    public buttonActivate script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLeftPushed && IsRightPushed)
        {
            Gate.gameObject.SetActive(false);
        }
    }

	void OnCollisionEnter(Collision collisionInfo)
	{
        if (collisionInfo.gameObject.name == "2")
        {
            IsRightPushed = true;
            keylock.KeyLock++;

        }
        if (collisionInfo.gameObject.name == "3")
        {
            IsLeftPushed = true;
            keylock.KeyLock++;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "2")
        {
            IsRightPushed = false;
            keylock.KeyLock--;
        }
        if (collisionInfo.gameObject.name == "3")
        {
            IsLeftPushed = false;
            keylock.KeyLock--;
        }
    }
}
