using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Oni;
    public Transform firePoint;
    public GameObject arrowPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Oni.GetComponent<SpriteRenderer>().sprite.name == "on_attacki3" || Oni.GetComponent<SpriteRenderer>().sprite.name == "on_attacki4")
        {

            if (collision.tag == "arrows")
            {

                Shoot();
                Destroy(collision.gameObject);
            }
        }
    }

    void Shoot()
    {
        //shooting logic
        SoundManager.PlaySound("parry");
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);


    }

}
