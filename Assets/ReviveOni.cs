using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveOni : MonoBehaviour
{
    public int WaitForReviveTime = 3;
    private bool KumoInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Oni (bigger scale reference)").GetComponent<PlayerHealth>().health <= 0)
        {
            if (KumoInRange && Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(Revive());
            }
            else if (KumoInRange && Input.GetKeyUp(KeyCode.F))
            {
                StopCoroutine(Revive());
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kumo")
        {
            KumoInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Kumo")
        {
            KumoInRange = false;

        }
    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(WaitForReviveTime);
        GameObject.Find("Oni (bigger scale reference)").GetComponent<PlayerHealth>().health = 5;
        StatsManager oniStats = GameObject.FindWithTag("oniStats").GetComponent<StatsManager>();
        oniStats.GainPoint();
    }
}
