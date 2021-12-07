using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakKey : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private Rigidbody2D rb;
    private bool fall;
    private float timer = 1f;
    private Vector2 orginalpos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        orginalpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (fall && timer > 0)
        {
            timer -= Time.deltaTime;
            transform.localPosition = new Vector2(orginalpos.x + Random.Range(-0.05f, 0.05f), orginalpos.y + 0);
        }
        else if (fall && timer <= 0)
        {
            Destroy(this.gameObject);
            this.GetComponent<pressPiano>().enabled = false;
            this.rb.velocity = new Vector2(0, -6f);
            
        }


        //print(timer);
        //print(fall);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kumo")
        {
            animator.SetBool("isTrigger", true);
        }
        if (collision.transform.tag == "Oni")
        {
            animator.enabled = false;
            fall = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kumo")
        {
            animator.SetBool("isTrigger", false);
        }

        if (collision.transform.tag == "Oni")
        {
            print(1);
            timer = 1f;
            fall = false;
        }
    }
}
