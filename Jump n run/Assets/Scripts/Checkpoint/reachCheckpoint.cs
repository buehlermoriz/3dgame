using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachCheckpoint : MonoBehaviour
{
public GameObject DisplayCheckpointMessage;
GameObject player;
private bool CheckpointBereitsErreicht = false; 

void Start () {
    DisplayCheckpointMessage.SetActive(false);
    player = GameObject.FindWithTag("Player"); 
    
}
    void OnTriggerEnter (Collider plyr) {
        if(CheckpointBereitsErreicht == false){
    if(plyr.gameObject.tag == "Player"){  
    DisplayCheckpointMessage.SetActive(true); 
    StartCoroutine(ExecuteAfterTime(3));
    CheckpointBereitsErreicht = true;
    }
}


IEnumerator ExecuteAfterTime(float time){
        yield return new WaitForSeconds(time);
        DisplayCheckpointMessage.SetActive(false);

    }
    
}
}
