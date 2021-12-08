using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
	public Canvas Bar;

	private int MaxPoint;
	private int Point;

    // Start is called before the first frame update
    void Start()
	{
		MaxPoint = Bar.transform.childCount;
		Point = MaxPoint;

		// get game manager health
		if( GameManager.Instance )
		{
			if( gameObject.CompareTag( "oniStats" ) )
			{
				SetPoint( GameManager.Instance.oniHealth );
			}
			else if( gameObject.CompareTag( "kumoStats" ) )
			{
				SetPoint( GameManager.Instance.kumoHealth );
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
		//TestPoint();
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
		if( Point < MaxPoint )
		{
			Bar.transform.GetChild( Point ).gameObject.SetActive( true );
			Point++;
		}
	}

	// Set point, return if set successful
	public bool SetPoint( int p )
	{
		if( p < 0 || p > MaxPoint )
			return false;

		else if( p == Point )
			return true;

		else if( p < Point )
		{
			int diff = Point - p;
			for( int i = 0; i < diff; i++ )
			{
				LosePoint();
			}
		}

		else if( p > Point )
		{
			int diff = Point - p;
			for( int i = 0; i < diff; i++ )
			{
				GainPoint();
			}
		}

		return true;
	}
}
