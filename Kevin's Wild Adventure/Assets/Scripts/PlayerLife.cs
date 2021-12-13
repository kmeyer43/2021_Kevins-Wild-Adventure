using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float threshold;
    public Image[] lives;
    int livesRemaining;
    public GameObject gameOverMenu;
    public static bool isGameOver;
    public GameObject addLives;
    public int startingLives;







    // Creates fields to set sound effects
    [SerializeField] private AudioSource fallSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource addLifeSoundEffect;



    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            LoseLife();
            fallSoundEffect.Play();
            
            Respawn();

            

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOverMenu.SetActive(false);
        int storedLife = PlayerPrefs.GetInt("livesRemaining");

        for (int i = 0; i < lives.Length; i++)
        {
            if (i + 1 > storedLife)
                lives[i].enabled = false;
        }

        livesRemaining = storedLife;
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {
            LoseLife();
            deathSoundEffect.Play();
            Die();
            
            Invoke(nameof(Respawn), 1.5f);
            


        }




    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("addLife"))


        {
            //Debug.Log("AddLife");
            addLife();
            addLives.SetActive(false);

        }
    }

    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
       

    }




    void Respawn()
    {
        rb.velocity = new Vector3();
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = CheckpointController.lastCheckPoint;
    }



    public void LoseLife()
    { 
        if (livesRemaining == 0)
        {
            return;
        }
         

        livesRemaining--;
        PlayerPrefs.SetInt("livesRemaining", livesRemaining);
        lives[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            //Debug.Log("YOU LOST");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            isGameOver = true;
            CheckpointController.ResetCheckpoint();
        }


    }

    public void addLife()
    {
        if (livesRemaining < 5)
        {
            lives[livesRemaining].enabled = true;
            livesRemaining++;
            PlayerPrefs.SetInt("livesRemaining", livesRemaining);
            addLifeSoundEffect.Play();
            
}




    }



    public void resumeGame()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("livesRemaining", startingLives);
        PlayerPrefs.DeleteKey("levelAt");
    }

    public void quitGame()
    {
        PlayerPrefs.SetInt("livesRemaining", startingLives);
        PlayerPrefs.DeleteKey("levelAt");
        Application.Quit();

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 1");
        PlayerPrefs.SetInt("livesRemaining", startingLives);
        PlayerPrefs.DeleteKey("levelAt");
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
    }

}
