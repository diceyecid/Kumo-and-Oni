using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private int KumoHealth;
    private int OniHealth;
    public int heal;

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
        if (collision.CompareTag("Kumo"))
        {
            KumoHealth = GameObject.Find("Kumo").GetComponent<PlayerHealth>().health;
            KumoHealth += heal;
            
            if (KumoHealth > 5)
            {
                KumoHealth = 5;

            }

            
            StatsManager kumoStats = GameObject.FindWithTag("kumoStats").GetComponent<StatsManager>();
            for (int i = 0; i < heal; i++)
                kumoStats.GainPoint();

            Destroy(gameObject);
        }

        if (collision.CompareTag("Oni"))
        {

            GameObject.Find("Oni (bigger scale reference)").GetComponent<PlayerHealth>().health = 5;
            OniHealth += heal;
            print(OniHealth);

            if (OniHealth > 5)
            {
                OniHealth = 5;
                print(OniHealth);
            }

            
            StatsManager oniStats = GameObject.FindWithTag("oniStats").GetComponent<StatsManager>();

            for (int i = 0; i < heal; i++)
                oniStats.GainPoint();

            Destroy(gameObject);
        }
    }
}
