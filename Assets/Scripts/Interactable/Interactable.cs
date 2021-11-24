using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public const float RANGE = 1.5f;
	
	public GameObject kumoInteractionUI;
	public GameObject oniInteractionUI;

	public GameObject kumo;
	public GameObject oni;

	private GameObject popup;
	private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
		popup = null;
		offset = new Vector3( 0, GetComponent<SpriteRenderer>().bounds.size.y * 1.5f, 0 );
    }

    // Update is called once per frame
    void Update()
    {
		if( !popup )
		{
			fadeIn();
		}
		else
		{
			fadeOut();
		}
    }


	// instantiate pop up
	void fadeIn()
	{
		if( ( kumo.transform.position - transform.position ).magnitude < RANGE )
		{
			popup = Instantiate( kumoInteractionUI, transform.position + offset, Quaternion.identity, transform );
		}

		if( ( oni.transform.position - transform.position ).magnitude < RANGE )
		{
			popup = Instantiate( oniInteractionUI, transform.position + offset, Quaternion.identity, transform );
		}
	}

	// destroy pop up
	void fadeOut()
	{
		if( ( kumo.transform.position - transform.position ).magnitude > RANGE && popup.tag == "kumoInteraction" )
		{
			Destroy( popup );
		}

		if( ( oni.transform.position - transform.position ).magnitude > RANGE && popup.tag == "oniInteraction" )
		{
			Destroy( popup );
		}
	}
}
