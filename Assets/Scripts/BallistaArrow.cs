using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrow : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * speed * -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
           

        if(collision.gameObject.name == "Oni (bigger scale reference)")
        {
            GameObject.Find("Oni (bigger scale reference)").GetComponent<PlayerHealth>().TakeDamage(damage);
          /*  StatsManager oniStats = GameObject.FindWithTag("oniStats").GetComponent<StatsManager>();
            oniStats.LosePoint();
*/
        }
        else if (collision.gameObject.name == "Kumo")
        {
            GameObject.Find("Kumo").GetComponent<PlayerHealth>().TakeDamage(damage);
       /*     StatsManager kumoStats = GameObject.FindWithTag("kumoStats").GetComponent<StatsManager>();
            kumoStats.LosePoint();*/
        }
 

        Destroy(gameObject);
    }

}
