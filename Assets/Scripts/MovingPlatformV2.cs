using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformV2 : MonoBehaviour
{
	// levers
	public Lever upper;
	public Lever lower;

	public float maxHeight;
	public float minHeight;
	private float step;

    // Start is called before the first frame update
    void Start()
    {
		step = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		if( upper.getState() == Lever.LEFT )
		{
			transform.localPosition += Vector3.down * step * Time.deltaTime;
		}
		else if( upper.getState() == Lever.RIGHT )
		{
			transform.localPosition += Vector3.up * step * Time.deltaTime;
		}

		if( lower )
		{
			if( lower.getState() == Lever.LEFT )
			{
				transform.localPosition += Vector3.down * step * Time.deltaTime;
			}
			else if( lower.getState() == Lever.RIGHT )
			{
				transform.localPosition += Vector3.up * step * Time.deltaTime;
			}
		}

		if( transform.localPosition.y > maxHeight )
		{
			transform.localPosition = new Vector3( transform.localPosition.x, maxHeight, transform.localPosition.z );
		}
		else if( transform.localPosition.y < minHeight )
		{
			transform.localPosition = new Vector3( transform.localPosition.x, minHeight, transform.localPosition.z );
		}
    }
}
