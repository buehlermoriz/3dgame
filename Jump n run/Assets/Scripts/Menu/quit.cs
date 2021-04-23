using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{

     // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("click");
            //saving the current level and player coordinates to be used when the user presses "Resume" in the game menu
            PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(0);
        }
    }
}
