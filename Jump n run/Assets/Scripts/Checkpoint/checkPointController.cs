using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointController : MonoBehaviour
{
    public checkpoint[] checkpoints;
    public int currentCheckPoint;
    public GameObject[] checkPointObjects;

    void Awake()
    {

        checkPointObjects = GameObject.FindGameObjectsWithTag("checkpoint");

        foreach (GameObject c in checkPointObjects)
        {
            //rename checkpoints
            int index = System.Array.IndexOf(checkPointObjects, c);
            c.name = "checkpoint " + index.ToString();
            checkpoints[index] = new checkpoint();
            checkpoints[index].element = c;
            checkpoints[index].index = index;
            Debug.Log(c.name);
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