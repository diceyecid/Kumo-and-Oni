using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    public int health;
=======
    public int health = 100;
	
	private StatsManager healthUI;
>>>>>>> fdf54fdb9567cc115d286691dc679093ef08d7a3

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
