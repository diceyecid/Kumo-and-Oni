using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumoMovement : MonoBehaviour
{
    public float Speed = 1, dist;
    public float jumpForce = 1;
    private float moveInput, Inputver;

    private Rigidbody2D rb;

    private bool faceRight = true;

    private bool isGrounded;
    public bool drop;
    public Transform groundCheck, topCheck;
    public float checkRadius;
    public LayerMask whatIsGround, climbWall, ropeLayer;
    public bool climbing;

    private int extraJumps;
    public int extraJumpsValue;

    bool isTouchingFront, horClimb;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    private bool attached;

    public Animator animator;
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;

            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
            animator.SetBool("hanging", false);
            animator.SetBool("walljumping", false) ;
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
                climbing = false;
            }
        }

        if (climbing)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("climbing", true);
        }
        else
        {
            animator.SetBool("climbing", false);
        }

        if (Input.GetKeyDown(KeyCode.G) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animator.SetBool("jumping", true);
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //if(drop == false)isClimbable = Physics2D.OverlapCircle(topCheck.position, checkRadius, climbWall);

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
        horClimb = Physics2D.OverlapCircle(topCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront == true && isGrounded == false && moveInput != 0 && wallJumping == false && climbing == false && attached == false)
        {
            wallSliding = true;
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
            animator.SetBool("hanging", true);
        }
        else{
            wallSliding = false;
            //animator.SetBool("falling", true);
            animator.SetBool("hanging", false);
        }

        if (wallSliding)
        {

            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.G) && wallSliding == true)
        {
            wallJumping = true;
            animator.SetBool("walljumping", true);
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if(wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, dist, ropeLayer);

        if (hit.collider != null && attached == false)
        {
            attached = true;
        }
        else
        {
            attached = false;
        }

        if (attached)
        {
            Inputver = Input.GetAxisRaw("Vertical2");
            rb.velocity = new Vector2(rb.velocity.x, Inputver * Speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1.6f;
        }
        if (isGrounded && horClimb == false || climbing) animator.SetFloat("Speed", Mathf.Abs(moveInput));
        else
        {
            animator.SetFloat("Speed", 0);
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
