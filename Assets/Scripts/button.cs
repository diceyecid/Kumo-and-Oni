using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    private bool exit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (exit == true && this.transform.position.y <= -1)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.1f);
        }
        else if (exit == true && this.transform.position.y >= -1)
        {
            //exit = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Oni" || collision.gameObject.tag == "Kumo")
        {
            exit = false;
            if (this.transform.position.y >= -1.3) this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Oni" || collision.gameObject.tag == "Kumo")
        {
            exit = true;
        }
    }
}
