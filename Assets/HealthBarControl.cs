using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarControl : MonoBehaviour
{
   

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject kumo = GameObject.Find("Kumo");
        GameObject oni = GameObject.Find("Oni (bigger scale reference)");
        PlayerHealth kumoHealth = kumo.GetComponent<PlayerHealth>();
        PlayerHealth oniHealth = oni.GetComponent<PlayerHealth>();

        GameObject health5 = GameObject.Find("Oni 5");
        GameObject health4 = GameObject.Find("Oni 4");
        GameObject health3 = GameObject.Find("Oni 3");
        GameObject health2 = GameObject.Find("Oni 2");
        GameObject health1 = GameObject.Find("Oni 1");


        if (oniHealth.health == 5)
        {
            health5.GetComponent<SpriteRenderer>().enabled = true;
            health4.GetComponent<SpriteRenderer>().enabled = true;
            health3.GetComponent<SpriteRenderer>().enabled = true;
            health2.GetComponent<SpriteRenderer>().enabled = true;
            health1.GetComponent<SpriteRenderer>().enabled = true;
        }else if (oniHealth.health == 4)
        {
            health5.GetComponent<SpriteRenderer>().enabled = false;
            health4.SetActive(true);
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
        }else if (oniHealth.health == 3)
        {
            health5.SetActive(false);
            health4.SetActive(false);
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
        }
        else if (oniHealth.health == 2)
        {
            health5.SetActive(false);
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(true);
            health1.SetActive(true);
        }
        else if (oniHealth.health == 1)
        {
            health5.SetActive(false);
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(true);
        }
        else if (oniHealth.health == 0)
        {
            health5.SetActive(false);
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);
        }

    }
}
