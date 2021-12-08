using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveKumo : MonoBehaviour
{
    public int WaitForReviveTime = 3;
    private bool OniInRange;
    public int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Kumo").GetComponent<PlayerHealth>().health <= 0) {
            if (OniInRange && Input.GetKeyDown(KeyCode.Comma))
            {
                
                StartCoroutine(Revive());

            }
            else if (!OniInRange && Input.GetKeyUp(KeyCode.Comma))
            {
                StopCoroutine(Revive());
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Oni")
        {
            OniInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Oni")
        {
            OniInRange = false;

        }
    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(WaitForReviveTime);
        SoundManager.PlaySound("heal");
        GameObject.Find("Kumo").GetComponent<PlayerHealth>().health = 5;
        StatsManager kumoStats = GameObject.FindWithTag("kumoStats").GetComponent<StatsManager>();
        for (int i = 0; i < maxHealth; i++)
            kumoStats.GainPoint();
    }
}
