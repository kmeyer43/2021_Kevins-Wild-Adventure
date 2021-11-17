using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void playLevel1()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void playLevel2()
    {

        SceneManager.LoadScene("Level 2");
    }

    public void playLevel3()
    {

        SceneManager.LoadScene("Level 3");
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
