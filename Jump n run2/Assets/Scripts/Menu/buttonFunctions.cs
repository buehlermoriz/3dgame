using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{


    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void resumeGame()
    {
        if (!PlayerPrefs.HasKey("lastLevel"))
        {
            Debug.Log("You have not reached a checkpoint yet.");
        }
        else if (PlayerPrefs.HasKey("lastLevel"))
        {
            Debug.Log("Loading next scene.");
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel"));
        }
    }

    public void quitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}