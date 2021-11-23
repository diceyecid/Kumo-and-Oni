using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int summonTimer = 600;
    private int hp = 10;
    public int currentHP;
    private int randomN, stage = 0;
    public GameObject summon, blade;
    public GameObject cam;


    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        //print(hp);
        summonTimer--;
        //stage1
        if (currentHP > 7)
        {

            if (summonTimer == 0)
            {
                this.GetComponent<Animator>().SetBool("isSummoning", true);
                    randomN = Random.Range(0, 2);
            }
        
            if (this.GetComponent<SpriteRenderer>().sprite.name == "boss_summon6")
            {
                if (this.GetComponent<Animator>().GetBool("isSummoning"))
                {
                    if (randomN == 0)Instantiate(summon, new Vector2(Random.Range(-10, 20), -2.7f), this.transform.rotation);
                    else if (randomN == 1) Instantiate(blade, new Vector2(this.transform.position.x, this.transform.position.y -1), this.transform.rotation);
                }
                summonTimer = 600;
                this.GetComponent<Animator>().SetBool("isSummoning", false);
            }
        }
        else if (currentHP > 3)
        {
            if (stage == 0)
            {
                stage = 1;
                cam.GetComponent<MultipleTargetCamera>().shake = true;
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
    }
}
