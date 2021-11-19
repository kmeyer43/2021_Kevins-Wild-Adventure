using UnityEngine;

/// <summary>
/// Simple Character movement.
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class KevinMovement : MonoBehaviour
{

    public static class Keys
{
    public const string ANIMATION_SPEED_KEY = "Speed";
    public const string ANIMATION_INAIR_KEY = "InAir";
    public const string ANIMATION_AIRSPEED_KEY = "AirSpeed";
}
    [Header("Movement")]
    /// <summary>
    /// Character Walk Speed
    /// </summary>
    [SerializeField]
    private float walkSpeed = 1f;

    /// <summary>
    /// Character Run Speed
    /// </summary>
    [SerializeField]
    private float runSpeed = 1.5f;

    /// <summary>
    /// Character Jump Force
    /// </summary>
    [SerializeField]
    private float jumpForce = 10f;

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

    // Reference to the Animator
    private Animator characterAnimator;
    // Reference to the Rigidbody2D
    private Rigidbody2D rb;

    // Input
    private float horizontalInput;
    private bool sprintInput;
    private bool jumpInput;

    // Property - if player is on ground
    private bool isGrounded = false;

    // Property - if player can do second jump
    private bool consumedDoubleJump = false;

    /// <summary>
    /// Setup component
    /// </summary>
    private void Awake()
    {
        // Get references
        characterAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Called on each frame
    /// </summary>
    private void Update()
    {
        // Get input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        sprintInput = Input.GetButton("Sprint");
        jumpInput = Input.GetButtonDown("Jump");

        // Set animation movement speed
        var animSpeed = horizontalInput * (sprintInput ? 2 : 1);
        characterAnimator.SetFloat(Keys.ANIMATION_SPEED_KEY, Mathf.Abs(animSpeed));
    }

    /// <summary>
    /// Called on each physics frame
    /// </summary>
    private void FixedUpdate()
    {
        // Check if grounded
        isGrounded = IsOnGround();

        // Get character velocity
        var velocity = rb.velocity;

        // Assign ground status to animator
        characterAnimator.SetBool(Keys.ANIMATION_INAIR_KEY, !isGrounded);

        // Initial jump only on ground
        if (isGrounded)
        {
            consumedDoubleJump = false;
            if (jumpInput)
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            // Double jump
            if (!consumedDoubleJump && jumpInput)
            {
                velocity.y = jumpForce;
                consumedDoubleJump = true;
            }
        }

        // Set air velocity
        characterAnimator.SetFloat(Keys.ANIMATION_AIRSPEED_KEY, velocity.y);

        // Calculate character movement
        var moveSpeed = 0f;
        var moveDirection = 1f;

        // Calculate move speed and direction
        if (!Mathf.Approximately(horizontalInput, 0))
        {
            moveSpeed = sprintInput ? runSpeed : walkSpeed;
            moveDirection = Mathf.Sign(horizontalInput);
        }

        // Set character velocity and direction
        velocity.x = moveSpeed * moveDirection;
        transform.localScale = new Vector3(moveDirection, 1, 1);
        rb.velocity = velocity;
    }

    /// <summary>
    /// Checks if player is on the ground.
    /// </summary>
    /// <returns><c>true</c>, if on ground, <c>false</c> otherwise.</returns>
    private bool IsOnGround()
    {
        // Get ground layer mask
        var groundMask = LayerMask.GetMask("Ground");

        // Raycasting
        var origin = rb.position + Vector2.down * groundOffsetCheck;
        var result = Physics2D.Raycast(origin, Vector2.down, groundDistanceCheck, groundMask);

        // Draw debug line to adjust parameters
        Debug.DrawLine(origin, origin + Vector2.down * groundDistanceCheck);

        // Check if something was hit
        return result.transform != null;
    }
}