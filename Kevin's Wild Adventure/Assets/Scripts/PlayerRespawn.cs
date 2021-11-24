using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerRespawn : MonoBehaviour {
     public float threshold;
 
     [SerializeField] private AudioSource fallSoundEffect;

     void FixedUpdate () {
         if (transform.position.y < threshold) {
              fallSoundEffect.Play();
              transform.position = new Vector3(-13, -2, 0);
         }
     }
 }
