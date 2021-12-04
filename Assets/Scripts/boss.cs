using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int summonTimer = 600;
    private int hp = 5;
    public int currentHP;
    private int randomN, stage = 0, num;
    public GameObject summon, blade, platform, ground;
    public GameObject cam, spikes, stage3, kumo, oni;
    public GameObject shield, dmgShield;
    private float dmg = 1f;
    private bool hurtAnim;
    private Vector3 orginalpos;
    void Start()
    {
        orginalpos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //print(hp);
        summonTimer--;

        if (summonTimer < 0)
        {
            this.GetComponent<Animator>().SetBool("isSummoning", true);
            randomN = Random.Range(0, 2);
        }
        //stage1
        if (hp > 7)
        {

            
        
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
        else if (hp > 3)
        {
            if (stage == 0)
            {
                stage = 1;
                cam.GetComponent<MultipleTargetCamera>().shake = true;
                platform.SetActive(true);
            }

            if (this.GetComponent<SpriteRenderer>().sprite.name == "boss_summon6")
            {
                if (this.GetComponent<Animator>().GetBool("isSummoning"))
                {
                    if (randomN == 0)
                    {
                        num = Random.Range(1, 7);
                        switch (num)
                        {
                            case 1:
                                spikes.transform.GetChild(0).gameObject.SetActive(true);
                                break;
                            case 2:
                                spikes.transform.GetChild(1).gameObject.SetActive(true);
                                break;
                            case 3:
                                spikes.transform.GetChild(2).gameObject.SetActive(true);
                                break;
                            case 4:
                                spikes.transform.GetChild(3).gameObject.SetActive(true);
                                break;
                            case 5:
                                spikes.transform.GetChild(4).gameObject.SetActive(true);
                                break;
                            case 6:
                                spikes.transform.GetChild(5).gameObject.SetActive(true);
                                break;
                        }
                    }
                    else if (randomN == 1) Instantiate(blade, new Vector2(this.transform.position.x, this.transform.position.y - 1), this.transform.rotation);
                }
                summonTimer = 400;
                this.GetComponent<Animator>().SetBool("isSummoning", false);
            }
            
        }
        else
        {

            cam.GetComponent<MultipleTargetCamera>().shake = true;
            ground.SetActive(false);
            stage3.SetActive(true);
            platform.SetActive(false);
            kumo.transform.position = new Vector2(-9, kumo.transform.position.y);
            oni.transform.position = new Vector2(-2, oni.transform.position.y);
            Destroy(this.gameObject);
        }


        if (dmg > 0 && hurtAnim)
        {
            dmg -= Time.deltaTime;
            transform.localPosition = new Vector3(orginalpos.x + Random.Range(-0.1f, 0.1f), orginalpos.y + Random.Range(-0.1f, 0.1f), orginalpos.z);
        }
        else
        {
            hurtAnim = false;
            dmg = 1f;
            shield.SetActive(true);
            dmgShield.SetActive(false);
            transform.localPosition = orginalpos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "blade")
        {
            hp--;
            Destroy(collision.gameObject);
            shield.SetActive(false);
            dmgShield.SetActive(true);
            hurtAnim = true;
        }
    }
}
