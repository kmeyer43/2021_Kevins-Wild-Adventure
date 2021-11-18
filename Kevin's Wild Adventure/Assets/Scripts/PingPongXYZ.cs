using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongXYZ : MonoBehaviour
{
    // Serialize Fields allow the Unity editor to set the value
    // of the property
	[SerializeField]
	private float speed = 0;


	[SerializeField]
	private Vector3 distance = Vector3.zero;

    // Allows object to be auto on or triggered on when player enters trigger
	[SerializeField]
	private bool playOnStart = false;


	[SerializeField]
	private bool loop = false;

    // Time for platform to wait at the ends to allow player to get on / off
	[SerializeField]
	private float pauseTimeAtEnd = 0;

    // Local script variables
	private bool posDir;
	private Vector3 origPos;
	private Vector3 targetPos;
	private float curDist;
	private float moveSpeed;
	private float timer;

	// Use this for initialization
	void Start()
	{
		// Determine start position
		origPos = transform.localPosition;

		// Determine end position based on the distance the designer set
		targetPos = origPos + distance;

        // moveSpeed, in this case, is the percentage to move the platform
        // each second. This script will use Lerp() which is percentage based.
		moveSpeed = speed / Vector3.Distance(origPos, targetPos);

        // Preset values
		curDist = 0;
		posDir = true;
		timer = 0;
	}

	// Update is called once per frame
	void Update()
	{
        // Don't run remaining code if object is not on
		if (!playOnStart)
		{
			return;
		}

		// Check pause time to have platform wait at the end
        // to allow the player to get on / off the platform
		if (timer >= 0)
		{
			timer -= Time.deltaTime;
			return;
		}

        // Call local method to perform the moving
		MoveObject();
	}

	private void MoveObject()
	{
		// Calculate the distance to move based on how fast each frame calculates
        // this causes the platform to move at a consistent speed regardless of
        // the Frames Per Second, so slower / faster computers run the same
		if (posDir)
		{
			curDist += moveSpeed * Time.deltaTime;
		}
		else
		{
			curDist -= moveSpeed * Time.deltaTime;
		}
		// Debug.Log("CurDist" + curDist);

        // Lerp() uses a percentage to determine position between two points
        // 0% is at the start point (origPos) and 100% is at the end point (targetPos)
		transform.localPosition = Vector3.Lerp(origPos, targetPos, curDist);

		// If at end, stop and reverse
		if (posDir)
		{
			if (curDist >= 1.0f)
			{
				// At the End!

				// Reverse direction flag
				posDir = false;

				// Check if looping, if it is then set timer to wait time to pause platform
				if (loop)
				{
					timer = pauseTimeAtEnd;
				}
				else
				{
                    // Not looping, stop platform
					playOnStart = false;
				}
			}
		}
		else
		{
            // Going towards start point

			if (curDist < 0.0f)
			{
				// At the Start!
				posDir = true;

				// Check if looping
				if (loop)
				{
					timer = pauseTimeAtEnd;
				}
				else
				{
					playOnStart = false;
				}
			}
		}
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
