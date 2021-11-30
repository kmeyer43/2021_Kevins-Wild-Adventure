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

    void Start()
    {
        winMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            DontDestroyOnLoad(playerFinishSoundEffect);
            playerFinishSoundEffect.Play();
            TimerController.instance.EndTimer();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
        isStopped = true;
    }


    public void nextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    }


}
