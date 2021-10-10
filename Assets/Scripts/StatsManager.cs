using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
	public static int MAX_POINT = 5;

	private int Point = MAX_POINT;
	public Canvas Bar;

    // Start is called before the first frame update
    void Start()
	{
		
    }

    // Update is called once per frame
    void Update()
    {
		TestPoint();
    }

	// Test bar changes
	private void TestPoint()
	{
		if( Input.GetKeyDown( KeyCode.Minus ) )
		{
			LosePoint();
		}
		else if( Input.GetKeyDown( KeyCode.Equals ) )
		{
			GainPoint();
		}
	}

	// Decrease point by 1
	public void LosePoint()
	{
		if( Point > 0 )
		{
			Point--;
			Bar.transform.GetChild( Point ).gameObject.SetActive( false );
		}
	}

	// Increase point by 1
	public void GainPoint()
	{
		if( Point < MAX_POINT )
		{
			Bar.transform.GetChild( Point ).gameObject.SetActive( true );
			Point++;
		}
	}
}
