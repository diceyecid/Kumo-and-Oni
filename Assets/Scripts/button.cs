using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    private bool exit, colliding, oni, kumo;
    public bool pressed;
    public int pos;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y <= pos && exit == true) this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.0005f);

        if (this.transform.position.y >= pos) pressed = false;

            if (oni == false && kumo == false)
        {
            exit = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Oni")
        {
            oni = true;
            pressed = true;
            exit = false;
            if (this.transform.position.y >= pos - 0.5) this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.1f);
        }

        if (collision.gameObject.tag == "Kumo")
        {
            kumo = true;
            pressed = true;
            exit = false;
            if (this.transform.position.y >= pos - 0.5) this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Oni")
        {
            oni = false;
        }

        if (collision.gameObject.tag == "Kumo")
        {
            kumo = false;
        }
    }
}
