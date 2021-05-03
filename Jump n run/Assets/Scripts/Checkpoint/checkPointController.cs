using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointController : MonoBehaviour
{

    private GameObject[] checkPointObjects;

    void Awake()
    {
        PlayerPrefs.SetInt("progress", -1);

        checkPointObjects = GameObject.FindGameObjectsWithTag("checkpoint");

        foreach (GameObject c in checkPointObjects)
        {
            //rename checkpoints
            int index = System.Array.IndexOf(checkPointObjects, c);
            c.name = "checkpoint " + index.ToString();
        }
    }

}