using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakKey : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private Rigidbody2D rb;
    private bool fall;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
        {
            
            this.rb.velocity = new Vector2(0, -6f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kumo")
        {
            animator.SetBool("isTrigger", true);
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Oni")
        {
            animator.enabled = false;
            fall = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kumo")
        {
            animator.SetBool("isTrigger", false);
        }
    }
}
