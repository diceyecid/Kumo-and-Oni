using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGroup : MonoBehaviour
{
	private Lever[] levers;
	private int active;

    // Start is called before the first frame update
    void Start()
    {
		levers = GetComponentsInChildren<Lever>();
		active = -1;
    }

    // Update is called once per frame
    void Update()
    {
		for( int i = 0; i < levers.Length; i++ )
		{
			// find the newly active lever
			if( levers[i].getState() != Lever.NEUTRAL && i != active )
			{
				// set previously active lever to neutral and record newly activated lever
				if( active != -1 )
				{
					levers[active].setState( Lever.NEUTRAL );
				}
				active = i;
				break;
			}
		}
    }
}
