using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuGlobalData : MonoBehaviour
{
    //parts that apply to UI
    static public bool paused = false;
    static public bool gameOver = false;

    //starts before first frame
    void Start()
    {
        gameOver = false;
    }

    /*//UI quite game button
    public void QuitGame()
    {
        Application.Quit();
    }*/

    private void Update()
    {
        //Will Quite game when Triangle pressed on menu screen"
        if (Input.GetKey("joystick button 3"))
        {
            Application.Quit();
        }

        if (Input.GetKey("joystick button 2"))
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
            Debug.Log("gameloaded");
        }
    }


    //UI Starts Game 
   /* public void StartGame() //will change the game to the quit to menu is clicked.
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Debug.Log("gameloaded");
    }*/

    

//Takes User to Intro card
public void IntroCard() //will change the game to the quit to menu is clicked.
    {
        SceneManager.LoadScene("IntroCard");
        Time.timeScale = 1f;
        Debug.Log("gameloaded");
    }

}
