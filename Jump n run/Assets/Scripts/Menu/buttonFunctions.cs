using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{

    private AudioManager sound;

    void Awake()
    {
       sound = FindObjectOfType<AudioManager>();
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        sound.Play("click");

    }

    public void resumeGame()
    {
        sound.Play("click");
        if (!PlayerPrefs.HasKey("lastLevel"))
        {
            Debug.Log("You have not reached a checkpoint yet.");
        }
        else if (PlayerPrefs.HasKey("lastLevel"))
        {
            PlayerPrefs.SetInt("resume", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel"));


            Debug.Log("Loading next scene.");
        }
    }

    public void quitGame()
    {
        sound.Play("click");
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}