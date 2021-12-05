using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss1, boss2;
    public GameObject hp10, hp9, hp8, hp7, hp6, hp5, hp4, hp3, hp2, hp1;
    private int hp = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 3) hp = boss1.gameObject.GetComponent<boss>().getHP();
        else hp = boss2.gameObject.GetComponent<stage3>().getHP();

        print(hp);
        if (hp == 10)
        {
            hp10.SetActive(true);
        }
        else
        {
            hp10.SetActive(false);
        }

        if (hp == 9)
        {
            hp9.SetActive(true);
        }
        else
        {
            hp9.SetActive(false);
        }

        if (hp == 8)
        {
            hp8.SetActive(true);
        }
        else
        {
            hp8.SetActive(false);
        }

        if (hp == 7)
        {
            hp7.SetActive(true);
        }
        else
        {
            hp7.SetActive(false);
        }

        if (hp == 6)
        {
            hp6.SetActive(true);
        }
        else
        {
            hp6.SetActive(false);
        }

        if (hp == 5)
        {
            hp5.SetActive(true);
        }
        else
        {
            hp5.SetActive(false);
        }

        if (hp == 4)
        {
            hp4.SetActive(true);
        }
        else
        {
            hp4.SetActive(false);
        }

        if (hp == 3)
        {
            hp3.SetActive(true);
        }
        else
        {
            hp3.SetActive(false);
        }

        if (hp == 2)
        {
            hp2.SetActive(true);
        }
        else
        {
            hp2.SetActive(false);
        }

        if (hp == 1)
        {
            hp1.SetActive(true);
        }
        else
        {
            hp1.SetActive(false);
        }
    }
}
