using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Allows us to enter a sound effect for when the player finishes a level
    [SerializeField] private AudioSource playerFinishSoundEffect;

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
        SceneManager.LoadScene("MainMenu");
    }
}
