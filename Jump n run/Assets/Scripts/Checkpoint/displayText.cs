using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayText : MonoBehaviour
{
    public GameObject DisplayCheckpointMessage;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DisplayCheckpointMessage.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter (Collider plyr) {
		if(plyr.gameObject.tag == "Player")
        {
        DisplayCheckpointMessage.SetActive(true);
        }
        else
        {
            DisplayCheckpointMessage.SetActive(false);
        }
    }
    }
}
