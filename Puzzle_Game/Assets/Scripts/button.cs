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
    public AudioClip collectibleSound;

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
    }
}
