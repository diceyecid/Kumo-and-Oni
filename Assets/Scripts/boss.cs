using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int summonTimer = 600;
    private int hp = 10;
    public int currentHP;
    private int randomN;
    public GameObject summon, blade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        summonTimer--;
        //stage1
        if (currentHP > 7)
        {

        
        if (summonTimer == 0)
        {
            this.GetComponent<Animator>().SetBool("isSummoning", true);
                //randomN = Random.Range(0, 2);
                randomN = 1;
        }
        
        if (this.GetComponent<SpriteRenderer>().sprite.name == "boss_summon6")
        {
            if (this.GetComponent<Animator>().GetBool("isSummoning"))
            {
                if (randomN == 0)Instantiate(summon, new Vector2(Random.Range(-10, 20), -2.7f), this.transform.rotation);
                else if (randomN == 1) Instantiate(blade, this.transform.position, this.transform.rotation);
            }
            summonTimer = 600;
            this.GetComponent<Animator>().SetBool("isSummoning", false);
        }
        }
    }
}
