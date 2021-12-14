using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Allows us to enter a sound effect for when the player finishes a level
    [SerializeField] private AudioSource playerFinishSoundEffect;


    public GameObject winMenu;
    public static bool isStopped;
    public GameObject gameTimer;
    public int nextSceneLoad;

    void Start()
    {
        isStopped = false;
        winMenu.SetActive(false);
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //DontDestroyOnLoad(playerFinishSoundEffect);
            playerFinishSoundEffect.Play();
            TimerController.instance.EndTimer();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        //Setting Int for Index
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
        gameTimer.SetActive(false);
        winMenu.SetActive(true);
        Time.timeScale = 0f;
        isStopped = true;
    }


    public void nextLevel()
    {

        //Move to next level
        SceneManager.LoadScene(nextSceneLoad);
        Time.timeScale = 1f;
        isStopped = false;
        CheckpointController.ResetCheckpoint();
    }


    public void goToMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        isStopped = false;
        CheckpointController.ResetCheckpoint();
    }


}
