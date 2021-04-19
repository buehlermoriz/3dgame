using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour {
    public Transform checkpoint;
   // GameObject player;
    public Image blackFade;
    
	void Start () {
        blackFade.canvasRenderer.SetAlpha(0.0f);
    //    player = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter (Collider plyr) {
	//	if(plyr.gameObject.tag == "Player")
      //  {
            blackFade.CrossFadeAlpha(1,0.5f,false);
           // player.transform.position = checkpoint.position;
           // player.transform.rotation = checkpoint.rotation;
            

       // }
	}
}