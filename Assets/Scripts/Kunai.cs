using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int timer = 20;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && timer == 20)
        {
            Shoot();
            this.GetComponent<Animator>().SetBool("attacking", true);
            timer--;
            
        }
        if (timer  == 0)
        {
            timer = 20;
            this.GetComponent<Animator>().SetBool("attacking", false);
        }
        if (timer > 0 && timer < 20)
        {
            timer--;
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
