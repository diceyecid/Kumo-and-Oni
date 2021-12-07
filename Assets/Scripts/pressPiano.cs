using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressPiano : MonoBehaviour
{
    private bool pressing, climbing, falling;
    private Rigidbody2D rb;
    public float top, bot, length;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing && this.transform.localPosition.y + 0.5f > bot)
        {
            rb.velocity = new Vector2(0, -1.5f);
        }
        else if (pressing == false && this.transform.localPosition.y + 0.5f < top)
        {
            rb.velocity = new Vector2(0, 2);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
        //print("climbing" + climbing);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Oni")
        {
            pressing = true;
        }
        /*if (collision.transform.tag == "Kumo")
        {
            kumo.transform.position = new Vector2(kumo.transform.position.x, transform.position.y - length);
            kumo.GetComponent<Rigidbody2D>().velocity = new Vector2(kumo.GetComponent<Rigidbody2D>().velocity.x, 0);
            kumo.GetComponent<KumoMovement>().climbing = true;
        }*/
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Oni")
        {
            pressing = false;
        }

    }


}
