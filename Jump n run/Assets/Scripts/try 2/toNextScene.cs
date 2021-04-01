using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toNextScene : MonoBehaviour
{
public int nextSceneToLoad;

public void Start ()
{
    nextSceneToLoad = SceneManager.GetActiveScene().buildIndex +1;
}
public void OnTriggerEnter3D(CapsuleCollider collision)
{
    SceneManager.LoadScene(nextSceneToLoad);
}
}
