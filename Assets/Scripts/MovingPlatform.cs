using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public GameObject platform;
	public GameObject trigger;
	public int movingDuration;

	private bool isTriggered = false;
	private double timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTiggerEnter2D( Collider2D collision )
	{
		Debug.Log( "entered" );
		if( !isTriggered && collision.transform.gameObject == trigger )
		{
			Debug.Log( "triggered" );
			float speed  = 2 / movingDuration;

			while( timeCount < movingDuration )
			{
				platform.transform.Translate( 0, (float)( timeCount * speed ), 0 );
				timeCount += Time.deltaTime;
			}

			isTriggered = true;
		}
	}
}
