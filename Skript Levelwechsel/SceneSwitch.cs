using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int numberNextLevel;

 void OnTriggerEnter (Collider other){
numberNextLevel = SceneManager.GetActiveScene().buildIndex +1;
 SceneManager.LoadScene(numberNextLevel);
 }

}
