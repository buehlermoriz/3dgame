using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startOutro : MonoBehaviour
{

public Animator animatorPlane;
public Animator animatorFade;
public GameObject videoPlayer;
public GameObject black;

GameObject player;

private AudioManager sound;

 void Awake()
    {
       sound = FindObjectOfType<AudioManager>();
    }

void Start () {
    videoPlayer.SetActive(false);
    player = GameObject.FindWithTag("Player"); 
    
}
    void OnTriggerEnter (Collider plyr) {
       
    if(plyr.gameObject.tag == "Player"){  
    StartCoroutine(OutroMusic(4));
     StartCoroutine(OutroPlane(6));
     StartCoroutine(fadeBlack(20));
     StartCoroutine(startAnimation(24));
    StartCoroutine(toMenu(74));

    }
    
    }


    public void displayPlane (){
        animatorPlane.SetTrigger("displayPlane");
    }
IEnumerator OutroMusic(float time){
        yield return new WaitForSeconds(time);
      
         sound.Play("outro");
    }
    IEnumerator OutroPlane(float time){
        yield return new WaitForSeconds(time);
           displayPlane();
        
    }
    IEnumerator fadeBlack(float time){
        yield return new WaitForSeconds(time);
           animatorFade.SetTrigger("fadeOut");
    }
       IEnumerator startAnimation(float time){
        yield return new WaitForSeconds(time);
         videoPlayer.SetActive(true);
        black.SetActive(false);
        
    }
        IEnumerator toMenu(float time){
        yield return new WaitForSeconds(time);
          SceneManager.LoadScene(0);
    }
    

}
