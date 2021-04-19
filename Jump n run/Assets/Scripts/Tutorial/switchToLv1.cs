using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchToLv1 : MonoBehaviour
{
  public  GameObject player;
  public GameObject Fadeblack;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindWithTag("Player");
    }
        void OnTriggerEnter (Collider plyr) {
        if (plyr.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
