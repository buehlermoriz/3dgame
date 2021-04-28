using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointController : MonoBehaviour
{
    public GameObject DisplayCheckpointMessage;
    private GameObject[] checkPointObjects;
    public checkpoint[] checkpoints;
    public int currentCheckPoint;
    private AudioManager sound;
    private GameObject player;

     
    void Awake()
    {
        sound = FindObjectOfType<AudioManager>();
        DisplayCheckpointMessage=GameObject.Find("checkpointReached");
        //disable onscreen message
        //DisplayCheckpointMessage.SetActive(false);
        //define object references
        player = GameObject.FindWithTag("Player");

        checkPointObjects = GameObject.FindGameObjectsWithTag("checkpoint");
        checkpoints = new checkpoint[checkPointObjects.Length];
        foreach (GameObject c in checkPointObjects)
        {
            //add collider to checkpoint
            //var type = Type.GetType( "checkpointCollider.cs" );
            //c.AddComponent<checkpointCollider>() as checkpointCollider;
            //rename checkpoints
            int index = System.Array.IndexOf(checkPointObjects, c);
            c.name = "checkpoint " + index.ToString();
            //add new checpoint element to "checkpoints[]"-Array for each checkpoint object found in game
            checkpoints[index] = new checkpoint();
            checkpoints[index].element = c;
            checkpoints[index].index = index;
        }
        currentCheckPoint = 0;
        Debug.Log(checkpoints);
    }



    // Update is called once per frame
    void checkPointReached()
    {
        //currentCheckPoint.reachCheckpoint()

        //currentCheckPoint++;

    }
}