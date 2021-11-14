using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

  private Rigidbody2D rb;
  

    // Start is called before the first frame update
    private void Start()
    {
        // Get and store a reference to the Rigidbody2D component so that we can access it
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

      // Move the player left, right and jump
      float dirX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        
      if (Input.GetButtonDown("Jump")) {
        rb.velocity = new Vector2(0, 5);
      }

    }
}
