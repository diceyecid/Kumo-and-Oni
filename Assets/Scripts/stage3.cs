using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3 : MonoBehaviour
{
    private int summonTimer;
    public GameObject blade;
    private int hp = 3;
    public bool real;
    // Start is called before the first frame update
    void Start()
    {
        summonTimer = Random.Range(500, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0) Destroy(this.gameObject);
        summonTimer--;

        if (summonTimer < 0)
        {
            this.GetComponent<Animator>().SetBool("isSummoning", true);
            if (this.GetComponent<SpriteRenderer>().sprite.name == "boss_summon6")
            {
                Instantiate(blade, new Vector2(this.transform.position.x, this.transform.position.y - 1), this.transform.rotation);
                summonTimer = Random.Range(500, 1000);
                this.GetComponent<Animator>().SetBool("isSummoning", false);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "blade")
        {
            hp--;
            Destroy(collision.gameObject);
        }

        if (real == false)
        {
            if (collision.tag == "kunai")
            {
                hp--;
                Destroy(collision.gameObject);
            }
        }
    }
}
