using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public int startingLives;
    public void playGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void resetGame()
    {
        PlayerPrefs.SetInt("livesRemaining", startingLives);
        PlayerPrefs.DeleteKey("levelAt");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
