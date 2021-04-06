using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachCheckpoint : MonoBehaviour
{
public GameObject DisplayCheckpointMessage;
public static bool disabled = true;
    GameObject player;
	void Start () {

        player = GameObject.FindWithTag("Player");
	}
    void OnTriggerEnter (Collider plyr) {
		if(plyr.gameObject.tag == "Player")
        {
        DisplayCheckpointMessage.SetActive(false);
        }
        else
        {
            DisplayCheckpointMessage.SetActive(true);
        }
    }

}
