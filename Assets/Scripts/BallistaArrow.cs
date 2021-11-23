using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrow : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * speed * -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    { 
            Destroy(gameObject);
    }

}
