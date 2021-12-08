using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 5f;
    private int num;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <0)
        {
            timer = 5f;
            num = Random.Range(1, 7);
            switch (num) {
                case 1: 
                    transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 2:
                    transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 3:
                    transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 4:
                    transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case 5:
                    transform.GetChild(4).gameObject.SetActive(true);
                    break;
                case 6:
                    transform.GetChild(5).gameObject.SetActive(true);
                    break;
            }
        }

    }
}
