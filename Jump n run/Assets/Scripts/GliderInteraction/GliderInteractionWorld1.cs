using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderInteractionWorld1 : MonoBehaviour
{
public GameObject DisplayGilderInteraction;
public Animator animator;

GameObject player;

private bool ObjectCollected = false;
private AudioSource sound;

 void Awake()
    {
       sound = GetComponent<AudioSource>();
    }

void Start () {
   DisplayGilderInteraction.SetActive(false);
    player = GameObject.FindWithTag("Player"); 
    
}
    void OnTriggerEnter (Collider plyr) {
        if(ObjectCollected == false){
    if(plyr.gameObject.tag == "Player"){  
         sound.Play();
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