using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeToMenu : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public Vector3 lastPosition;
    public GameObject player;

    public void teleportPlayer()
    {

            Debug.Log("Player position is now being set to: " + PlayerPrefs.GetFloat("x") + PlayerPrefs.GetFloat("y") + PlayerPrefs.GetFloat("z"));
            //Convert xyz-coordinates from PlayerPrefs into a Vector3-Object to teleport the player to the position he logged off from
            x = PlayerPrefs.GetFloat("x");
            y = PlayerPrefs.GetFloat("y");
            z = PlayerPrefs.GetFloat("z");
            lastPosition = new Vector3(x, y, z);
            Debug.Log(lastPosition);

            player.transform.position = lastPosition;
            PlayerPrefs.SetInt("resume", 0);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (PlayerPrefs.GetInt("resume") == 1)
        {
            teleportPlayer();

        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //saving the current level and player coordinates to be used when the user presses "Resume" in the game menu
            PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("x", player.transform.position.x);
            PlayerPrefs.SetFloat("y", player.transform.position.y);
            PlayerPrefs.SetFloat("z", player.transform.position.z);
            Debug.Log("Player position registered at: " + PlayerPrefs.GetFloat("x") + PlayerPrefs.GetFloat("y") + PlayerPrefs.GetFloat("z"));

            SceneManager.LoadScene(0);
        }
    }
}
