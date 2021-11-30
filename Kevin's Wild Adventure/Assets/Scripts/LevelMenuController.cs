using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void playLevel1()
    {

        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void playLevel2()
    {

        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1f;
    }

    public void playLevel3()
    {

        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1f;
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
