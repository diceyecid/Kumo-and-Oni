using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumoMovement : MonoBehaviour
{
    public float Speed = 1;
    public float jumpForce = 1;
    private float moveInput;

    private Rigidbody2D rb;

    private bool faceRight = true;

    private bool isGrounded, isClimbable, drop;
    public Transform groundCheck, topCheck;
    public float checkRadius;
    public LayerMask whatIsGround, climbWall;

    private int extraJumps;
    public int extraJumpsValue;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            drop = false;
        }

        if (Input.GetKeyDown(KeyCode.G) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.G) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(drop == false)isClimbable = Physics2D.OverlapCircle(topCheck.position, checkRadius, climbWall);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)
        {
            Flip();
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront == true && isGrounded == false && moveInput != 0)
        {
            wallSliding = true;
            
        }
        else{
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.G) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if(wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
        }


        if (isClimbable)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            if (Input.GetKeyDown(KeyCode.G))
            {
                
                isClimbable = false;
                drop = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    void Flip()
    {
        faceRight = !faceRight;
        /*Vector3 Scaler = transform.lossyScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;*/
        transform.Rotate(0f, 180f, 0f);
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
        if (rb.velocity.y > 0) rb.velocity = new Vector2(rb.velocity.x, 2);
    }

    void move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)
        {
            Flip();
        }
    }
}
