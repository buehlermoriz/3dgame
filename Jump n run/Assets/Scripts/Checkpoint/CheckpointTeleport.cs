using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTeleport : MonoBehaviour {

    //These two variables describe the checkpoint the deathplane is assigned to
    private Transform checkpointTransform;
    private GameObject assignedCheckpoint;
    //These tow variables describe the checkpoint the Player has last reached.
    //If the player falls off behind his current checkpoint, these variables are used to teleport him to his current checkpoint even though the death plane is assigned to a checkpoint before.
    private GameObject currentCheckpoint;
    private Transform currentCheckpointTransform;
    //This GameObject is the player
    private GameObject player;
    //This variable is used to temporarily store player progress
    private int playerProgress; 
	void Start () {

        player = GameObject.FindWithTag("Player");

        checkpointTransform = transform.parent;
        assignedCheckpoint = checkpointTransform.gameObject;

    }
	
	void OnTriggerEnter (Collider plyr) {

        playerProgress = PlayerPrefs.GetInt("progress");


        if (plyr.gameObject.tag == "Player")
        {
            if (assignedCheckpoint.name == "checkpoint " + playerProgress.ToString())
            {
                player.transform.position = checkpointTransform.position;
                player.transform.rotation = checkpointTransform.rotation;
                print("Teleported back to checkpoint " + playerProgress + ".");
            //if the player hits a deathplane behind the current checkpoint, he will get teleported back to the current one.
            } else if (assignedCheckpoint.name == "checkpoint " + (playerProgress - 1).ToString())
            {
                currentCheckpoint = GameObject.Find("checkpoint " + playerProgress.ToString());
                currentCheckpointTransform = currentCheckpoint.transform;

                player.transform.position = currentCheckpointTransform.position;
                player.transform.rotation = currentCheckpointTransform.rotation;
                print("Teleported forward to checkpoint " + playerProgress + ".");
            }
        }
	}
}