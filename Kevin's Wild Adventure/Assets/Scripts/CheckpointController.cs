using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    // Creates a field to set a sound for the checkpoint
    [SerializeField] private AudioSource checkPointSoundEffect;

    public static Vector3 lastCheckPoint = new Vector3(-13, -2, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            checkPointSoundEffect.Play();
            lastCheckPoint = transform.position;
        } 
    }
    
    public static void ResetCheckpoint()
    {
        lastCheckPoint = new Vector3(-13, -2, 0);
    }
}
