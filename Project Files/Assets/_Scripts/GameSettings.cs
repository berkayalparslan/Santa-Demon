using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    public bool gameOver;


    void Start()
    {
        gameOver = false;
    }


    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale==0 && gameOver==false )
        {
            Continue();

        }

        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale==1 && gameOver==false )
        {
            Pause();
        }

        if(gameOver==true && Input.anyKey ==true)
        {
            Restart();
        }

    }


    void Restart()
    {
        SceneManager.LoadScene("Game");
        Continue();
    }


    public void Pause()
    {
        Time.timeScale = 0.0f;
    }


    void Continue()
    {
        Time.timeScale = 1.0f;
    }


}
