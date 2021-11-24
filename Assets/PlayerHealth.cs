using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;


    public void TakeDamage(int damage)
    {
        health -= damage;
    }

   
}
