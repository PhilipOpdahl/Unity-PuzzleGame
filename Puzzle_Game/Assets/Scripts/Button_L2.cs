using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_L2 : MonoBehaviour
{
    public bool IsRightPushed = false;
    public bool IsLeftPushed = false;
    public bool IsMiddlePushed = false;
    public GameObject PlayerRight;
    public GameObject PlayerLeft;
    public GameObject PlayerMiddle;
    public GameObject Gate;
    public Button_Activate_L2 keylock;
    public AudioClip collectibleSound;

    public Button_Activate_L2 script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMiddlePushed && IsLeftPushed && IsRightPushed)
        {
            Gate.gameObject.SetActive(false);
        }
    }

	void OnTriggerEnter(Collider collisionInfo)
	{
        if (collisionInfo.gameObject.name == "2")
        {
            AudioSource.PlayClipAtPoint(collectibleSound, transform.position,2f);
            IsRightPushed = true;
            keylock.KeyLock++;
        }

        if (collisionInfo.gameObject.name == "3")
        {
            AudioSource.PlayClipAtPoint(collectibleSound, transform.position,2f);
            IsLeftPushed = true;
            keylock.KeyLock++;
        }

        if (collisionInfo.gameObject.name == "4")
        {
            AudioSource.PlayClipAtPoint(collectibleSound, transform.position,2f);
            IsMiddlePushed = true;
            keylock.KeyLock++;
        }
    }

    void OnTriggerExit(Collider collisionInfo)
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
        if (collisionInfo.gameObject.name == "4")
        {
            IsMiddlePushed = false;
            keylock.KeyLock--;
        }
    }
}
