using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniMovement : MonoBehaviour
{
    public float Speed = 1;
    public float jumpForce = 1;
    private float moveInput;

    private Rigidbody2D rb;

    private bool faceRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;


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

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal2");
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


    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.lossyScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
