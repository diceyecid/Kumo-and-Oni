using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
	// levers
	public Lever leftRight;
	public Lever upDown;

	private Rigidbody2D rb;
	private float step;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		step = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		// left and right movement
		if( leftRight.getState() == Lever.LEFT )
		{
			rb.MovePosition( transform.position + Vector3.left * step * Time.deltaTime );
		}
		else if( leftRight.getState() == Lever.RIGHT )
		{
			rb.MovePosition( transform.position + Vector3.right * step * Time.deltaTime );
		}

		// up and down movement
		if( upDown.getState() == Lever.LEFT )
		{
			rb.MovePosition( transform.position + Vector3.up * step * Time.deltaTime );
		}
		else if( upDown.getState() == Lever.RIGHT )
		{
			rb.MovePosition( transform.position + Vector3.down * step * Time.deltaTime );
		}
    }
}
