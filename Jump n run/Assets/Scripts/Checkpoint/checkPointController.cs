using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointController : MonoBehaviour
{
    public checkpoint[] checkpoints;
    public int currentCheckPoint;

    void Awake()
    {


        private GameObject[] checkPointObjects;

    checkPointObjects = GameObject.FindGameObjectsWithTag("checkpoint");

        foreach (GameObject c in checkPointObjects)
        {
            //rename checkpoints
            int index = System.Array.IndexOf(checkpointObjects, c);
        c.name = "checkpoint " + index.ToString();
        }
            checkpoints.push(new checkpoint);
            Debug.Log(c.name);
    currentCheckPoint = 0;
    Debug.Log(checkpoints);
    }

    

    // Update is called once per frame
    void checkPointReached()
    {
        currentCheckPoint.reachCheckpoint

        currentCheckPoint++;

    }
}