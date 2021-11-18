using UnityEngine;
/// <summary>
/// Simple Character movement.
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class KevinMovement : MonoBehaviour
{
    // Reference to the Animator
    private Animator characterAnimator;
    // Reference to the Rigidbody2D
    private Rigidbody2D rb;
    /// <summary>
    /// Setup component
    /// </summary>
    private void Awake()
    {
        // Get references
        characterAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    [Header("Movement")]
    /// <summary>
    /// Character Walk Speed
    /// </summary>
    [SerializeField]
    private float walkSpeed = 1f;
    // Input
    private float horizontalInput;
   
    /// <summary>
    /// Called on each frame
    /// </summary>
    private void Update()
    {
        // Get input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        // Set animation movement speed
        var animSpeed = horizontalInput;
        characterAnimator.SetFloat(Keys.ANIMATION_SPEED_KEY, Mathf.Abs(animSpeed));
    }

    /// <summary>
    /// This class contains constant strings for use in code.
    /// </summary>
    public static class Keys
    {
        public const string ANIMATION_SPEED_KEY = "Speed";
        public const string ANIMATION_INAIR_KEY = "InAir";
        public const string ANIMATION_AIRSPEED_KEY = "AirSpeed";
    }
    /// <summary>
    /// Called on each physics frame
    /// </summary>
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