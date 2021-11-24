using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
	private Animator anim;
	private bool triggerStay;
	private string triggerObjName;

    // Start is called before the first frame update
    void Start()
    {
		anim = this.GetComponent<Animator>();
		triggerStay = false;
		triggerObjName = "";
    }

    // Update is called once per frame
    void Update()
    {
		if( triggerStay )
		{
			if( triggerObjName == "Kumo" && Input.GetKeyDown( InputKey.KUMO_INTERACT ) ) 
			{
				anim.SetBool( "isLit", !anim.GetBool( "isLit" ) );
			}
			else if( triggerObjName == "Oni" && Input.GetKeyDown( InputKey.ONI_INTERACT ) )
			{
				anim.SetBool( "isLit", !anim.GetBool( "isLit" ) );
			}
		}
    }

    private void OnTriggerEnter2D( Collider2D collision )
	{
		if( collision.tag == "Kumo" )
		{
			triggerStay = true;
			triggerObjName = "Kumo";
		}
		else if( collision.tag == "Oni" )
		{
			triggerStay = true;
			triggerObjName = "Oni";
		}
	}

    private void OnTriggerExit2D( Collider2D collision )
	{
		if( collision.tag == triggerObjName )
		{
			triggerStay = false;
			triggerObjName = "";
		}
	}
}
