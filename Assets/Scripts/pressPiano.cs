using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressPiano : MonoBehaviour
{
    private bool pressing;
    private Rigidbody2D rb;
    public int top, bot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pressing && this.transform.position.y > -1)
        {
            rb.velocity = new Vector2(0, -1.5f);
        }
        else if (pressing == false && this.transform.position.y < 0)
        {
            rb.velocity = new Vector2(0, 2);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(1);
        if (collision.transform.tag == "Oni")
        {
            pressing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Oni")
        {
            pressing = false;
        }
    }
}
