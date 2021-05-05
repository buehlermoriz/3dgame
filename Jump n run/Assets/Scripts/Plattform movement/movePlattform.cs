using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlattform : MonoBehaviour
{
public Animator animator;

GameObject player;


void Start () {

    player = GameObject.FindWithTag("Player"); 
    
}
    void OnTriggerEnter (Collider plyr) {
    if(plyr.gameObject.tag == "Player"){  
    player.transform.parent = transform;
    }
    }
    void OnTriggerExit (Collider plyr){
        if(plyr.gameObject.tag == "Player"){  
            player.transform.parent = null;
        }
    }
    


    

}
