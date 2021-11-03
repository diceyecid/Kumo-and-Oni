using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public GameObject platform;
	public int movingDistance;
	public int movingDuration;

	private bool isTriggered;
	private float speed;
	private double timeCount;

    // Start is called before the first frame update
    void Start()
    {
		isTriggered = false;
		speed = -1 * movingDistance / movingDuration;
		timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if( isTriggered && timeCount < movingDuration )
		{
			platform.transform.Translate( 0, Time.deltaTime * speed, 0 );
			timeCount += Time.deltaTime;
		}
    }

    private void OnTriggerEnter2D( Collider2D collision )
	{
		print( "trigger" );
		if( !isTriggered )
		{
			isTriggered = true;
		}
	}
}
