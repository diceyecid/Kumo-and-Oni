using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressPiano : MonoBehaviour
{
    private bool pressing;
    private Rigidbody2D rb;
    public float top, bot, length;
    public GameObject kumo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing && this.transform.position.y > bot)
        {
            rb.velocity = new Vector2(0, -1.5f);
        }
        else if (pressing == false && this.transform.position.y < top)
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
        if (collision.transform.tag == "Oni")
        {
            pressing = true;
        }

        if (kumo.GetComponent<KumoMovement>().isClimbable && collision.transform.tag == "Kumo")
        {
            kumo.transform.position = new Vector3(kumo.transform.position.x, transform.position.y - length, kumo.transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Oni")
        {
            pressing = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
}
