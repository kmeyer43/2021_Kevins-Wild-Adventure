using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    [SerializeField]
    private bool playOnStart = true;

    private void Update()
    {
        // Don't run remaining code if object is not on
        if (!playOnStart)
        {
            return;
        }

        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player landed on platform, start movement
        if (!playOnStart)
        {
            playOnStart = true;
        }
    }
}
