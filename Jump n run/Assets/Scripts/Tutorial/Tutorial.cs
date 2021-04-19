using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
public GameObject DisplayTutorialMessageWASD;
public GameObject DisplayTutorialMessageShift;
public GameObject DisplayTutorialMessageSpace;
public GameObject DisplayTutorialMessageWellDone;
private bool wPressed = false;
private bool aPressed = false;
private bool sPressed = false;
private bool dPressed = false;
private string currentObjective = "wasd";

GameObject player;

void Start () {
    DisplayTutorialMessageWASD.SetActive(true);
    DisplayTutorialMessageShift.SetActive(false);
    DisplayTutorialMessageSpace.SetActive(false);
    DisplayTutorialMessageWellDone.SetActive(false);
   

    player = GameObject.FindWithTag("Player");     
}
void Update () {
    switch (currentObjective){
        case "wasd":
//check WASD
     if (Input.GetKeyDown(KeyCode.W)){
         wPressed = true;
     }
     if (Input.GetKeyDown(KeyCode.A)){
         aPressed = true;
     }
     if (Input.GetKeyDown(KeyCode.S)){
         sPressed = true;
     }
     if (Input.GetKeyDown(KeyCode.D)){
         dPressed = true;
     }
//after WASD
    if (wPressed==true && aPressed == true && sPressed == true && dPressed==true){
        wPressed= false;
        aPressed = false;
        sPressed = false;
        dPressed = false;
        DisplayTutorialMessageWASD.SetActive(false);
        DisplayTutorialMessageWellDone.SetActive(true);
       StartCoroutine(changeToShift(2));
    }
    IEnumerator changeToShift(float time){
        yield return new WaitForSeconds(time);
        DisplayTutorialMessageWellDone.SetActive(false);
        DisplayTutorialMessageShift.SetActive(true);
        currentObjective = "shift";
    }
    break;
    case "shift":
    //after Shift
    if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift) ){
        DisplayTutorialMessageShift.SetActive(false);
        DisplayTutorialMessageWellDone.SetActive(true);
       StartCoroutine(changeToSpace(2));
    }
       IEnumerator changeToSpace(float time){
        yield return new WaitForSeconds(time);
        DisplayTutorialMessageWellDone.SetActive(false);
        DisplayTutorialMessageSpace.SetActive(true);
        currentObjective = "space";
    }
    break;
    case "space":
//after Space
if (Input.GetKeyDown(KeyCode.Space)){
        DisplayTutorialMessageSpace.SetActive(false);
        DisplayTutorialMessageWellDone.SetActive(true);
       StartCoroutine(changeAfterSpace(2));
    }
    IEnumerator changeAfterSpace(float time){
        yield return new WaitForSeconds(time);
        DisplayTutorialMessageWellDone.SetActive(false);
         currentObjective = "";
    }
break;
default:
break;
    }
}}
