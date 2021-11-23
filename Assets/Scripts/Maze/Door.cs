using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	// variables for animation
	public bool isOpen;
	private bool isMoving;
	private float height;

	// variables for detecting if Kumo and Oni passed the door
	private bool isKumoPassed;
	private bool isOniPassed;

    // Start is called before the first frame update
    void Start()
    {
		isMoving = false;
		height = 3.0f;
		
		isKumoPassed = false;
		isOniPassed =  false;

		if( isOpen )
		{
			isOpen = false;
			isMoving = true;
		}
    }

    // Update is called once per frame
    void Update()
    {
		movingAnimation();
    }



	// moving animation
	private void movingAnimation()
	{
		// door open animation
		if( isMoving && !isOpen )
		{
			transform.position += new Vector3( 0, Time.deltaTime, 0 );

			// reached top
			if( transform.position.y >= height )
			{
				transform.position = new Vector3( transform.position.x, height, transform.position.z );
				isMoving = false;
				isOpen = true;
			}
		}

		// door close animation
		else if( isMoving && isOpen )
		{
			transform.position -= new Vector3( 0, Time.deltaTime, 0 );

			// reached bottom
			if( transform.position.y <= 0 )
			{
				transform.position = new Vector3( transform.position.x, 0, transform.position.z );
				isMoving = false;
				isOpen = false;
			}
		}
	}

	// check if Kumo and Oni passed the door
	private void OnTriggerExit2D( Collider2D other )
	{
		isKumoPassed = other.gameObject.tag == "Kumo" ? !isKumoPassed : isKumoPassed;
		isOniPassed = other.gameObject.tag == "Oni" ? !isOniPassed : isOniPassed;

		if( isKumoPassed && isOniPassed ) 
		{
			closeDoor();
			GetComponent<EdgeCollider2D>().isTrigger = false;
		}
	}



	// open door
	public void openDoor()
	{
		if( !isOpen )
		{
			isMoving = true;
		}
	}

	public void closeDoor()
	{
		if( isOpen )
		{
			isMoving = true;
		}
	}
}
