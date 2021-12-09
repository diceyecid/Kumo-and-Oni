using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
