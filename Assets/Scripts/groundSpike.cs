using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpike : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator[] spikes;
    void Start()
    {
        spikes = gameObject.GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Animator a in spikes)
        {
            if (a != null)
            {
                a.SetFloat("timer", a.GetFloat("timer") - Time.deltaTime);
            }

            if (a.GetFloat("timer") < -5)
            {
                a.SetFloat("timer", 3);
                this.gameObject.SetActive(false);
            }
        }
    }
}
