using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Attach : MonoBehaviour{

    public GameObject Player;
    public player_movement Parented;
    public player_movement script;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject == Player){
            Player.transform.parent = transform;
            Parented.parented = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject == Player){
            Player.transform.parent = null;
            Parented.parented = false;
        }
    }

    void Update(){
        //Debug.Log(Parented.parented);
    }
    
}
