using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderInteraction : MonoBehaviour
{
public GameObject DisplayGilderInteraction;
public Animator animator;

GameObject player;
private bool ObjectCollected = false; 
 

void Start () {
   DisplayGilderInteraction.SetActive(false);
    player = GameObject.FindWithTag("Player"); 
    
}
    void OnTriggerEnter (Collider plyr) {
        if(ObjectCollected == false){
    if(plyr.gameObject.tag == "Player"){  
    DisplayGilderInteraction.SetActive(true); 
    fade();
    StartCoroutine(ExecuteAfterTime(3));
    ObjectCollected=true;
    }
    }
    }

public void fade (){
        animator.SetTrigger("fadeObject");

    }
IEnumerator ExecuteAfterTime(float time){
        yield return new WaitForSeconds(time);
        DisplayGilderInteraction.SetActive(false);

    }
    

}
