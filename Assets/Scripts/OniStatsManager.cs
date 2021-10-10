using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OniStatsManager : MonoBehaviour
{
	private static int MAX_HEALTH = 5;

	private int Health = MAX_HEALTH;
	public Image[] HealthIcons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if( Input.GetKeyDown( KeyCode.Minus ) )
		{
			LoseHealth();
		}
		else if( Input.GetKeyDown( KeyCode.Equals ) )
		{
			GainHealth();
		}
        
    }

	// Decrease health by 1
	void LoseHealth()
	{
		if( Health > 0 )
		{
			Health--;
			HealthIcons[ Health ].enabled = false;
		}
	}

	// Increase health by 1
	void GainHealth()
	{
		if( Health < MAX_HEALTH )
		{
			HealthIcons[ Health ].enabled = true;
			Health++;
		}
	}
}
