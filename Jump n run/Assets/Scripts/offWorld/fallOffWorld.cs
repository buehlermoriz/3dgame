using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallOffWorld : MonoBehaviour
{

      private GameObject player;
        public Transform startingPoint;
    // Start is called before the first frame update
    void Start()
    {
          player = GameObject.FindWithTag("Player");
        
    }
void OnTriggerEnter (Collider plyr) {

        if (plyr.gameObject.tag == "Player")
        {

             player.transform.position = startingPoint.position;
                player.transform.rotation = startingPoint.rotation;
        }
        
}
}
