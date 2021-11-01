using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniMovement : MonoBehaviour
{
    public float Speed = 1;
    public float jumpForce = 1;
    private float moveInput, Inputver;

    private Rigidbody2D rb;

    private bool faceRight = true;

    private bool isGrounded, attached;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround, ropeLayer;

    private Transform attachedTo;

    private int extraJumps;
    public int extraJumpsValue;

    public Animator animator;
    public float dist;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal2") * Speed;
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput , rb.velocity.y);
        

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)
        {
            Flip();
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
            Inputver = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, Inputver * Speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1.6f;
        }

        
    }


    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

