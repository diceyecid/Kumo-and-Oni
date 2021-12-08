using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public int health;
    public GameObject self;
    private const int INV_TIME = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
    
        StartCoroutine(Blink());

        
    }

    private IEnumerator Blink()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;


        for (int i = 0; i < INV_TIME; i++)
        {
            sr.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.05f);
            sr.color = defaultColor;
            yield return new WaitForSeconds(0.05f);
        }

        Destroy(self);
    }
}

