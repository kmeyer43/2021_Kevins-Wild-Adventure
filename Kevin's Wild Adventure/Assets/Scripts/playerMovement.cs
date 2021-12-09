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
    public bool isDead;

    [Header("Movement")]
    /// <summary>
    /// Character Walk Speed
    /// </summary>
    [SerializeField]
    private float walkSpeed = 1f;



    // Input
    private float horizontalInput;

    // Create fielsd to allow us to set the jump and walking sound effects
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkingSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        // Get and store a reference to the Rigidbody2D component so that we can access it
        rb = GetComponent<Rigidbody2D>();
        // Get references
        characterAnimator = GetComponent<Animator>();
        // Coroutine to set walking sound interval
        StartCoroutine("WalkingSoundInterval");
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
        if (isGrounded == true && isDead == false && Input.GetKeyDown(KeyCode.Space))
        {
            
            isJumping = true;
            jumpSoundEffect.Play();
            walkingSoundEffect.Stop();
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true && isDead == false)

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

        private void FixedUpdate() {

        // Get character velocity
        var velocity = rb.velocity;
        // Calculate character movement
        var moveSpeed = 0f;
        var moveDirection = 1f;
        // Calculate move speed and direction
        if (isDead == false && !Mathf.Approximately(horizontalInput, 0))
        {
            moveSpeed = walkSpeed;
            moveDirection = Mathf.Sign(horizontalInput);
        }
        // Set character velocity and direction
        velocity.x = moveSpeed * moveDirection;
        transform.localScale = new Vector3(moveDirection, 1, 1);
        rb.velocity = velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Trap"))
        {
    
            Die();
            Invoke(nameof(Respawn), 1.5f);

        }

    }

    private void Die()
    {
        isDead = true;
    }

    void Respawn()
    {
        isDead = false;

    }

    IEnumerator WalkingSoundInterval() {

    yield return new WaitForSeconds(0.01f);
 
    while(true)
    {

        if (isGrounded == true && !Mathf.Approximately(horizontalInput, 0)) {
            walkingSoundEffect.Play();
        }
        yield return new WaitForSeconds(0.25f);
    }
}



}
