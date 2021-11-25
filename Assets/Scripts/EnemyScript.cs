using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public Transform Kumo;
    public Transform Oni;
    public Transform castPoint;
    public float moveSpeed;
    public float agroRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int damage = 40;
    private Rigidbody2D rb;
    public float fireRate = 1.5f;
    private float nextFire;

    bool isFacingLeft;
    private float distToPlayer;
    private bool isAgro = false;
    private bool isSearching;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector2(1, 1);
        isFacingLeft = true;
        animator.SetBool("AnimationDone", true);
    }

    // Update is called once per frame
    void Update()
    {

        if (CanSeePlayer(agroRange))
        {
            //agro enemy
            isAgro = true;
            
        }
        else
        {
            if (isAgro)
            {
                if (!isSearching)
                {
                    isSearching = true;
                    Invoke("StopChasingPlayer", 2);
                }
            }
            
        }

        if (isAgro)
        {
            ChasePlayer();
        }
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 9)
            {
                val = true;
                print("Enemy found");
            }
            else
            {
                val = false;
                print("No Enemy");
            }
            Debug.DrawLine(castPoint.position, endPos, Color.yellow);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }

        return val;
    }

    void ChasePlayer()
    {
        

            float distToKumo = Vector2.Distance(transform.position, Kumo.position);
            //print("distToKumo:" + distToKumo);

            float distToOni = Vector2.Distance(transform.position, Oni.position);
            //print("distToOni:" + distToOni);

            float distToAp = Vector2.Distance(transform.position, attackPoint.position);

            if (transform.position.x < Kumo.position.x || transform.position.x < Oni.position.x)
            {
            //enemy is to the left side of the player, so move right

                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                transform.localScale = new Vector2(-1, 1);
                isFacingLeft = false;
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

                if (distToOni < distToAp || distToKumo < distToAp)
                {
                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        Attack();
                    }

                }
                else if (distToOni > distToAp || distToKumo > distToAp)
                {
                    //animator.SetBool("Attacking", false);
                    print("stop attacking:");
                }
            }
            else if (transform.position.x > Kumo.position.x || transform.position.x > Oni.position.x)
            {
                //enemy is to the right side of the player , so move left
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                transform.localScale = new Vector2(1, 1);
                isFacingLeft = true;
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

                if (distToOni < distToAp || distToKumo < distToAp)
                {
                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        Attack();

                    }

                }
                else if (distToOni > distToAp || distToKumo > distToAp)
                {
                    //animator.SetBool("Attacking", false); 
                    print("stop attacking2");
            }
            }
       
    }

    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetFloat("Speed", 0);
        animator.SetBool("Attacking", false);
        print("Stop walking");
    }



    void Attack()
    {
        animator.SetBool("Attacking", true);
        StopChasingPlayer();
                
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D player in hitEnemies)
        {
            Debug.Log("We hit " + player.name);
            
            player.GetComponent<PlayerHealth>().TakeDamage(damage);

            if (player.CompareTag("Oni"))
            {
                StatsManager oniStats = GameObject.FindWithTag("oniStats").GetComponent<StatsManager>();
                oniStats.LosePoint();
            }else if (player.CompareTag("Kumo"))
            {
                StatsManager kumoStats = GameObject.FindWithTag("kumoStats").GetComponent<StatsManager>();
                kumoStats.LosePoint();
            }

        }
       

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void FinishAnimation()
    {
        animator.SetBool("AnimationDone", true);
        
    }

    void InitiateAnimation()
    {
        animator.SetBool("AnimationDone", false);
    }

}
