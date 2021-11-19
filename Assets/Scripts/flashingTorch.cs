using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashingTorch : MonoBehaviour
{
    // Start is called before the first frame update

    public int timer;
    private int count;
    public GameObject light1, light2;
    void Start()
    {
        count = timer;
        this.GetComponent<Animator>().SetBool("isLit", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            count--;
            
        }
        else
        {
            if (this.GetComponent<Animator>().GetBool("isLit"))
            {
                this.GetComponent<Animator>().SetBool("isLit", false);
                light1.gameObject.SetActive(false);
                light2.gameObject.SetActive(false);
            }
            else
            {
                this.GetComponent<Animator>().SetBool("isLit", true);
                light1.gameObject.SetActive(true);
                light2.gameObject.SetActive(true);
            }
            count = timer;
        }
    }
}
