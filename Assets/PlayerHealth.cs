using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
	
	private StatsManager healthUI;

	private const int INV_TIME = 5; 	// invincible time in 0.1 second

	private bool isInvincible;


	void Start()
	{
		if( gameObject.CompareTag( "Oni" ) )
		{
			// get health if game manager exists
			if( GameManager.Instance )
				health = GameManager.Instance.oniHealth;

			// get healthUI object
			if( GameObject.FindWithTag( "oniStats" ) )
			{
				healthUI = GameObject.FindWithTag( "oniStats" ).GetComponent<StatsManager>();
			}
		}
		else if( gameObject.CompareTag( "Kumo" ) )
		{
			// get health if game manager exists
			if( GameManager.Instance )
				health = GameManager.Instance.kumoHealth;

			// get healthUI object
			if( GameObject.FindWithTag( "kumoStats" ) )
			{
				healthUI = GameObject.FindWithTag( "kumoStats" ).GetComponent<StatsManager>();
			}
		}

		// not invincible as default
		isInvincible = false;
	}


	// player takes damage
    public void TakeDamage( int damage )
    {
		if( health > 0 && !isInvincible )
		{
			health -= damage;

			if( healthUI )
			{
				healthUI.LosePoint();		
			}

			StartCoroutine( Blink() );
		}
    }


	// blinking animation by altering opacity of sprite
	private IEnumerator Blink()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		Color defaultColor = sr.color;

		isInvincible = true;
		for( int i = 0; i < INV_TIME; i++ )
		{
			sr.color = new Color( 1f, 1f, 1f, 0f );
			yield return new WaitForSeconds( 0.05f );
			sr.color = defaultColor;
			yield return new WaitForSeconds( 0.05f );
		}
		isInvincible = false;
	}
}
