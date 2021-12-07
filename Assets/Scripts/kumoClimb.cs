using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kumoClimb : MonoBehaviour
{
    private bool climbing;
    public GameObject kumo;
    public float length;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kumo" && climbing == false)
        {

            climbing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kumo")
        {
            kumo.transform.position = new Vector2(kumo.transform.position.x, transform.position.y - 0.7f);
            kumo.GetComponent<Rigidbody2D>().velocity = new Vector2(kumo.GetComponent<Rigidbody2D>().velocity.x, 0);
            kumo.GetComponent<KumoMovement>().climbing = true;
        }

    }
}
