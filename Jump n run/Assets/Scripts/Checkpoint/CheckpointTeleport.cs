using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTeleport : MonoBehaviour {


    private Transform checkpointTransform;
    private GameObject player;
	void Start () {

        player = GameObject.FindWithTag("Player");
        checkpointTransform=transform.parent.gameObject
	}
	
	void OnTriggerEnter (Collider plyr) {
		if(plyr.gameObject.tag == "Player")
        {
            
            player.transform.position = checkpointTransform.position;
            player.transform.rotation = checkpointTransform.rotation;
            

        }
	}
}