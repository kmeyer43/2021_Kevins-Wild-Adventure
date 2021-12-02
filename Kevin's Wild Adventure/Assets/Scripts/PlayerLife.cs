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
    public int livesRemaining;
    public GameObject gameOverMenu;
    public static bool isGameOver;





    // Creates a field that allows us to set the fall sound effect
    [SerializeField] private AudioSource fallSoundEffect;



    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            LoseLife();
            fallSoundEffect.Play();
            Respawn();

            

        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOverMenu.SetActive(false);
       
          
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {
            LoseLife();
            Die();
            Invoke(nameof(Respawn), 1.5f);
            


        }

    }

    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        

    }




    void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = new Vector3(-13, -2, 0);

    }



    public void LoseLife()
    { 
        if (livesRemaining == 0)
        {
            return;
        }
         

        livesRemaining--;

        lives[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            //Debug.Log("YOU LOST");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            isGameOver = true;
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
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
    }

}
