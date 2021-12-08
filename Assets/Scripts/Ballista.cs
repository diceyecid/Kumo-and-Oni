using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
	public GameObject arrow;

	private Vector3 offset; 	// start position of arrow relative to ballista
	private bool cooldown; 		// Has it shoot for this animation?	

	// Call when start
	void Start()
	{
		// calculate offset of the arrow
		offset = this.GetComponent<Renderer>().bounds.size;
		offset.x /= 2;
		offset.y = 0;
		offset.z = -1;

		cooldown = false;
	}

    // Update is called once per frame
    void Update()
    {
		string spriteName = this.GetComponent<SpriteRenderer>().sprite.name;

		if( !cooldown && spriteName == "ballista_3" )
		{

			Shoot();
			cooldown = true;
		}
		else if( cooldown && spriteName != "ballista_3" )
		{
			cooldown = false;
		}
    }

	// shoot arrows automatically 
	void Shoot()
	{
		Instantiate(arrow, this.transform.position - offset, this.transform.rotation );
	}
}
