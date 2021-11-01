using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int damage = 40;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && animator.GetBool("attacking") == false)
        {
            Attack();
        }
        else
        {
            animator.SetBool("attacking", false);
        }
    }

    void Attack()
    {
        //play an attack animation 
        animator.SetBool("attacking", true);

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<SimpleEnemy>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


