using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldmanAI : MonoBehaviour
{
    public float walkSpeed;
    public int WaitForAttack;
    public int damage;
    public float attackRate = 3f;

    private bool mustPartrol;
    private bool mustTurn;
    private bool playerInRange;
    private float currentSpeed;
    private float nextFire;
    private bool playerBehind;
    private bool isMoving;

    public Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    public Transform playerCheck;
    public LayerMask playerLayer;
    public Transform backCheck;

    public LayerMask enemyLayer;
    public Collider2D shieldCollider;

    public Animator animator;


    void Start()
    {
        mustPartrol = true;
        playerInRange = false;
        currentSpeed = walkSpeed;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();

        if (mustPartrol)
        {
            Patrol();
        }

        if (playerInRange)
        {
            StartCoroutine(Attack());
        }

       
            
    }

    private void FixedUpdate()
    {
        if (mustPartrol)
        {
            //flip if not touching ground
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

            playerInRange = Physics2D.OverlapCircle(playerCheck.position, 0.1f, playerLayer);

            playerBehind = Physics2D.OverlapCircle(backCheck.position, 0.1f, playerLayer);
        }
    }

    void Walk()
    {
        if (isMoving)
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(walkSpeed));
        }
    }

    void Patrol()
    {
        //flip when no more ground or touches walk
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer) || playerBehind || bodyCollider.IsTouchingLayers(enemyLayer))
        {
            Flip();
        }

        walkSpeed = currentSpeed;
        isMoving = true;

    }

    void Flip()
    {
        mustPartrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        currentSpeed *= -1;
        mustPartrol = true;
    }


    IEnumerator Attack()
    {
        mustPartrol = false;

        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + attackRate;
            AttackPlayer();
        }

        yield return new WaitForSeconds(WaitForAttack);


        animator.SetBool("Attacking", false);
        mustPartrol = true;
    }


    void AttackPlayer()
    {

        isMoving = false;
        animator.SetBool("Attacking", true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerCheck.position, 0.1f, playerLayer);

        foreach (Collider2D player in hitEnemies)
        {
            Debug.Log("We hit " + player.name);

            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        if (playerCheck == null)
            return;


        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        Gizmos.DrawWireSphere(playerCheck.position, 0.1f);
        Gizmos.DrawWireSphere(backCheck.position, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("kunai"))
        {
            SoundManager.PlaySound("kumoAttack");
            print("Block");
        }
    }
}
