using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointCollider : MonoBehaviour
{
    public GameObject DisplayCheckpointMessage;
    private bool checkpointReached = false;
    private AudioManager sound;
    private GameObject player;

    void Start()
    {
        sound = FindObjectOfType<AudioManager>();
        DisplayCheckpointMessage.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter(Collider plyr)
    {
        if (checkpointReached == false)
        {
            if (plyr.gameObject.tag == "Player")
            {
                sound.Play("checkpoint");
                DisplayCheckpointMessage.SetActive(true);
                StartCoroutine(ExecuteAfterTime(3));
                checkpointReached = true;
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DisplayCheckpointMessage.SetActive(false);
    }
}
