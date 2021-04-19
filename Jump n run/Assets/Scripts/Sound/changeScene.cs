using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{

    public AudioClip introScore;
    private int nextLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(introScore.length));
    }


    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        switchScene();

    }


    void switchScene()
    {
        nextLevelIndex = SceneManager.GetActiveScene().buildIndex +1;
        SceneManager.LoadScene(nextLevelIndex);
    }
}
