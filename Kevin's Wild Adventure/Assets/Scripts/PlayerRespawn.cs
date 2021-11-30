using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour {
     public float threshold;
 
     // Creates a field that allows us to set the fall sound effect
     [SerializeField] private AudioSource fallSoundEffect;

     void FixedUpdate () {
         if (transform.position.y < threshold) {
              fallSoundEffect.Play();
              Invoke(nameof(Respawn), .02f);
        }
     }


    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
