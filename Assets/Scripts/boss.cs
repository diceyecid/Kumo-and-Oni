using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int summonTimer = 600;
    private double shakeTimer = 240;
    private int hp = 10;
    public int currentHP;
    private int randomN, stage = 0;
    public GameObject summon, blade;
    public GameObject cam;

    private Vector3 originalPos;

    public float shakeAmount = 10f;
    public float decreaseFactor = 1.0f;

    void Start()
    {
        originalPos = cam.GetComponent<MultipleTargetCamera>().offset;

       
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
                    randomN = Random.Range(0, 2);
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
        else if (currentHP > 3)
        {
            if (stage == 0)
            {
                stage = 1;
                cam.GetComponent<MultipleTargetCamera>().shake = true;
            }

            if (shakeTimer > 0 && shakeTimer < 240)
            {
                cam.GetComponent<MultipleTargetCamera>().offset = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeTimer -= Time.deltaTime * decreaseFactor;
                shakeTimer--;
            }
            else
            {
                shakeTimer = 0f;
                cam.GetComponent<MultipleTargetCamera>().offset = originalPos;
            }
        }

        
    }
}
