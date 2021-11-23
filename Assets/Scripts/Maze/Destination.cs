using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
	public Door door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D( Collider2D other )
	{
		if( other.gameObject.name == "Diamond" )
			door.openDoor();
	}
}
