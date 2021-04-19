using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchToLv1 : MonoBehaviour
{
  private  GameObject player;
 public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindWithTag("Player");
    }
        void OnTriggerEnter (Collider plyr) {
        if (plyr.gameObject.tag == "Player")
        {
            fade();
            StartCoroutine(changeLevel(2));

        }
    
    }
    public void fade (){
        animator.SetTrigger("fadeOut");

    }
    IEnumerator changeLevel(float time){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
