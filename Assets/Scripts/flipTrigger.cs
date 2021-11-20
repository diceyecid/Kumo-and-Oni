using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button, button2;
    public int timer;
    private bool wait;
    private int count;
    void Start()
    {
        count = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<button>().pressed || button2.GetComponent<button>().pressed)
        {
            this.GetComponent<Animator>().SetBool("isPressing", true);
            this.GetComponent<BoxCollider2D>().enabled = true;
            count = timer;
            wait = false;
        }
        else
        {
            wait = true;
        }

        if (wait)
        {
            count--;
        }

        if (count == 0)
        {
            this.GetComponent<Animator>().SetBool("isPressing", false);
            this.GetComponent<BoxCollider2D>().enabled = false;
            count = timer;
            wait = false;

        }

    }
}
