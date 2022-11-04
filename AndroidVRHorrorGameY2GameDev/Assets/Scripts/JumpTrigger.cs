using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject ThePlayer;
    public GameObject JumpCam;
   

    void OnTriggerEnter()
    {
        Scream.Play();
        JumpCam.SetActive(true);
        ThePlayer.SetActive(true);
        StartCoroutine(EndJump());
        
    }


    /*What jappens when the attached object is triggered. (starts the jump scare)*/
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        ThePlayer.SetActive(false);
        JumpCam.SetActive(false);
    }
}
