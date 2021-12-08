using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
	
	private StatsManager healthUI;

	void Start()
	{
		if( gameObject.CompareTag( "Oni" ) )
		{
			if( GameObject.FindWithTag( "oniStats" ) )
			{
				healthUI = GameObject.FindWithTag( "oniStats" ).GetComponent<StatsManager>();
			}
		}
		else if( gameObject.CompareTag( "Kumo" ) )
		{
			if( GameObject.FindWithTag( "kumoStats" ) )
			{
				healthUI = GameObject.FindWithTag( "kumoStats" ).GetComponent<StatsManager>();
			}
		}
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

		if( healthUI )
		{
			healthUI.LosePoint();		
		}
    }
}
