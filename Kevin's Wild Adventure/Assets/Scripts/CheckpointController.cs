using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    // Creates a field to set a sound for the checkpoint
    [SerializeField] private AudioSource checkPointSoundEffect;

    public bool alreadyPlayed = false;

    public static Vector3 lastCheckPoint = new Vector3(-13, -2, 0);

    Vector3 checkPointPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            checkPointPos = transform.position;
            checkPointPos.y += 4;
            checkPointPos.x += -1;
            lastCheckPoint = checkPointPos;
            if (!alreadyPlayed) {
                checkPointSoundEffect.Play();
                alreadyPlayed = true;
            }
        }
        
    }
    
    public static void ResetCheckpoint()
    {
        lastCheckPoint = new Vector3(-13, -2, 0);
    }
}
