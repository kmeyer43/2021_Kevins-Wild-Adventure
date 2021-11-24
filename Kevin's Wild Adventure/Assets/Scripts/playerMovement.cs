using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Reference to the Animator
    private Animator characterAnimator;
    private Rigidbody2D rb;

    public float jumpForce;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    
    [Header("Movement")]
    /// <summary>
    /// Character Walk Speed
    /// </summary>
    [SerializeField]
    private float walkSpeed = 1f;

    [Header("Ground check")]
    /// <summary>
    /// Ground check origin offset
    /// </summary>
    [SerializeField]
    private float groundOffsetCheck = 1f;
    /// <summary>
    /// Ground check distance
    /// </summary>
    [SerializeField]
    private float groundDistanceCheck = 0.4f;
    // Input
    private float horizontalInput;

    // Create a field to allow us to set the jump sound effect
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        // Get and store a reference to the Rigidbody2D component so that we can access it
        rb = GetComponent<Rigidbody2D>();
        // Get references
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        // Move the player left, right and jump
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * 7f, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // Set animation movement speed
        var animSpeed = horizontalInput;
        characterAnimator.SetFloat("Speed", Mathf.Abs(animSpeed));

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        // Set jump animator to isJumping variable

        characterAnimator.SetBool("isJumping", isJumping);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            isJumping = true;
            jumpSoundEffect.Play();
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)

        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //if (Input.GetButtonDown("Jump")) {
        // rb.velocity = new Vector2(0, 7);
        //}

    }

        private void FixedUpdate()
    {
        // Get character velocity
        var velocity = rb.velocity;
        // Calculate character movement
        var moveSpeed = 0f;
        var moveDirection = 1f;
        // Calculate move speed and direction
        if (!Mathf.Approximately(horizontalInput, 0))
        {
            moveSpeed = walkSpeed;
            moveDirection = Mathf.Sign(horizontalInput);
        }
        // Set character velocity and direction
        velocity.x = moveSpeed * moveDirection;
        transform.localScale = new Vector3(moveDirection, 1, 1);
        rb.velocity = velocity;

    }

}
