using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour
{
    // varables.
    public Vector3 lastCheckPoint;
    public Transform startPos;
    public GameObject player;

    //Keys colours for door/key varables
    static public bool Coin = false;
    static public bool Coin1 = false;
    static public bool Coin2 = false;
    static public bool Coin3 = false;

    //Lives left and points varables
    static public int Points;
    public int Health = 3;

    //parts that apply to UI
    static public bool paused = false;
    static public bool gameOver = false;
    public GameObject endGame;

    //Array
    public GameObject[] lives;
    public GameObject pauseMenu;
    public Text PointsText;

    //starts before first playthrough
    void Start()
    {
        Time.timeScale = 1f;
        //sends player to start point
        lastCheckPoint = startPos.position;
        player.transform.position = lastCheckPoint;
        // Sets starting points to 1000
        Points = 0000;
        UpdateLives();
        pauseMenu.SetActive(false);
        player.SetActive(true);
        SetPoints();
        gameOver = false;
    }


    // writes into the points text box
    public void SetPoints()
    {
        PointsText.text = Points.ToString();
    }

    //When player "dies" number of UI "hearts" decrease.
    public void UpdateLives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (Health > i)
            {
                lives[i].SetActive(true);

            }
            else
            {
                lives[i].SetActive(false);
            }

        }
        if (Health <= 0)
        {
            GameOver();
        }
    }

    //Pause game when Menue open Code
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    //When Circle key pressed UI menu opens
    private void Update()
    {
        if (Input.GetKey("joystick button 1"))
        {
            if (!paused)
            {
                PauseMenu();
            }
            else
            {
                Unpause();
            }
        }


        //Squere Restarts game
        if (Input.GetKey("joystick button 2"))
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
            Debug.Log("gameloaded");
        }


        //Will quit game when "Triangle is clicked"
        if (Input.GetKey("joystick button 3"))
        {
            Application.Quit();
        }



    }

    //UI Quit to menu button 
    public void QuitToMenu() //will change the game to the quit to menu is clicked.
    {
        SceneManager.LoadScene("MainMenu");
    }

    

    /*//UI quit game button
    public void QuitGame()
    {
        Application.Quit();
    }*/

    //UI Start Main Game 
    public void StartGame()
    {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Debug.Log("gameloaded");
    }

    public void GameOver() //will change the game to the quit to menu is clicked.
    {
        endGame.SetActive(true);
        player.SetActive(false);
        gameOver = true;
    }
}