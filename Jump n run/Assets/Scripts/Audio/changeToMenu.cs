using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeToMenu : MonoBehaviour
{

    public AudioClip introScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(introScore.length));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        switchScene();
    }
    void switchScene()
    {
   SceneManager.LoadScene(0);
    }
}