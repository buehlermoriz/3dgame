using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachCheckpoint : MonoBehaviour
{
    public GameObject DisplayCheckpointMessage;
    private bool checkpointReached = false;
    private AudioManager sound;
    private GameObject player;
    private int playerProgress;
    private string checkpointName;
    private int checkpointNumber;

    void Start()
    {
        sound = FindObjectOfType<AudioManager>();
        DisplayCheckpointMessage.SetActive(false);
        player = GameObject.FindWithTag("Player");

        checkpointName = this.name;
        checkpointNumber = int.Parse(checkpointName.Substring(checkpointName.Length - 1));
    }
    void OnTriggerEnter(Collider plyr)
    {
        
        if (plyr.gameObject.tag == "Player")
        {

            playerProgress = PlayerPrefs.GetInt("progress");
            //if the player the last checkpoint the player has reached is unequal to this one, set the progress accordingly
            if (checkpointNumber != playerProgress)
            {
                PlayerPrefs.SetInt("progress", checkpointNumber);
                print("You reached checkpoint " + checkpointNumber.ToString() + ".");
            }


            if (!checkpointReached)
            {
                checkpointReached = true;
                //Display UI
                DisplayCheckpointMessage.SetActive(true);
                StartCoroutine(ExecuteAfterTime(3));
                //play sound
                sound.Play("checkpoint");
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DisplayCheckpointMessage.SetActive(false);
    }
}
