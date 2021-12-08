using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossArrow : MonoBehaviour
{
    public float speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * speed * -1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Oni (bigger scale reference)")
        {
            GameObject.Find("Oni (bigger scale reference)").GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else if (collision.gameObject.name == "Kumo")
        {
            GameObject.Find("Kumo").GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
