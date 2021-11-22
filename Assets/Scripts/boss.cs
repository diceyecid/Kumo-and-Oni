using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int summonTimer = 600;
    private int hp = 10;
    public GameObject summon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        summonTimer--;

        if (summonTimer == 0)
        {
            print(1);
            Instantiate(summon, new Vector2(Random.Range(-10, 20), -2.7f), this.transform.rotation);
            summonTimer = 600;
        }
    }
}
