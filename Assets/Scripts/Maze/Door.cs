using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public bool isOpen;
	private bool isMoving;
	private float height;

    // Start is called before the first frame update
    void Start()
    {
		isMoving = false;
		height = 3.0f;

		if( isOpen )
		{
			isOpen = false;
			isMoving = true;
		}
    }

    // Update is called once per frame
    void Update()
    {
		// door open animation
        if( isMoving && !isOpen )
		{
			transform.position += new Vector3( 0, Time.deltaTime, 0 );

			// reached top
			if( transform.position.y >= height )
			{
				transform.position = new Vector3( 0, height, 0 );
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
				transform.position = new Vector3( 0, 0, 0 );
				isMoving = false;
				isOpen = false;
			}
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
