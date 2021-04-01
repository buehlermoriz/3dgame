using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public Transform checkpoint;
    GameObject player;
	void Start () {

        player = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter (Collider plyr) {
		if(plyr.gameObject.tag == "Player")
        {
            
            player.transform.position = checkpoint.position;
            

        }
	}
}