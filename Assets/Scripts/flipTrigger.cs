using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<button>().pressed)
        {
            this.GetComponent<Animator>().SetBool("isPressing", true);
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isPressing", false);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
