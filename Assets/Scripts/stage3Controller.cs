using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject largeK, trueKing, fake1, fake2;
    private bool hurting;
    private float shakeTime = 3f;
    private int pos;

    private float dmg = 1f;
    private bool hurtAnim;
    private Vector3 orginalpos;
    public GameObject dmgShield;
    void Start()
    {
        hurting = trueKing.GetComponent<stage3>().hurting;
        orginalpos = largeK.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hurting = trueKing.GetComponent<stage3>().hurting;
        if (hurting)
        {
            trueKing.SetActive(false);
            fake1.SetActive(false);
            fake2.SetActive(false);
            largeK.SetActive(true);
            dmgShield.SetActive(true);
        }

        if (shakeTime > 0 && hurting)
        {
            shakeTime -= Time.deltaTime;
        }
        else if (hurting)
        {
            pos = Random.Range(0, 3);
            shakeTime = 3f;
            hurting = false;
            trueKing.SetActive(true);
            fake1.SetActive(true);
            fake2.SetActive(true);
            switch (pos)
            { 
                case 1:
                    trueKing.transform.localPosition = new Vector2(trueKing.transform.localPosition.x, 11.65f);
                    fake1.transform.localPosition = new Vector2(fake1.transform.localPosition.x, 6.41f);
                    fake2.transform.localPosition = new Vector2(fake2.transform.localPosition.x, 0.73f);
                    break;

                case 2:
                    trueKing.transform.localPosition = new Vector2(trueKing.transform.localPosition.x, 6.41f);
                    fake1.transform.localPosition = new Vector2(fake1.transform.localPosition.x, 11.65f);
                    fake2.transform.localPosition = new Vector2(fake2.transform.localPosition.x, 0.73f);
                    break;

                case 3:
                    trueKing.transform.localPosition = new Vector2(trueKing.transform.localPosition.x, 0.73f);
                    fake1.transform.localPosition = new Vector2(fake1.transform.localPosition.x, 6.41f);
                    fake2.transform.localPosition = new Vector2(fake2.transform.localPosition.x, 11.65f);
                    break;
            }
            largeK.SetActive(false);
            trueKing.GetComponent<stage3>().hurting = false;
        }

    }
}
