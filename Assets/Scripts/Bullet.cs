using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;


    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        SimpleEnemy enemy = collision.GetComponent<SimpleEnemy>();
        
        if(enemy != null && collision.gameObject.name != "Ballista")
        {
            enemy.TakeDamage(damage);

        }
    }

	private void OnTriggerStay2D( Collider2D collision )
	{
		if( collision.transform.gameObject.layer != 12 )
		{
			Destroy(gameObject); 
		}
	}

}
