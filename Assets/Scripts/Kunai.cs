using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireRate = 0.5f;
    private float nextFire;
    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }

        }
        else
        {
            animator.SetBool("attacking", false);
        }

    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("attacking", true);
        SoundManager.PlaySound("kumoAttack");

    }
}
