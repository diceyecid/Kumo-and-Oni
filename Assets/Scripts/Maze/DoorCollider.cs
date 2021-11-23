using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
	private Collider2D collider;

	// variables for detecting if Kumo and Oni passed the door
	private bool isKumoPassed;
	private bool isOniPassed;
	private int kumoColliderCount;
	private int oniColliderCount;
	private const int kumoTotalCollider = 3;
	private const int oniTotalCollider = 2;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerExit2D( Collider2D other )
	{
		// count collider passed
		kumoColliderCount += other.gameObject.tag == "Kumo" ? 1 : 0;
		oniColliderCount += other.gameObject.tag == "Oni" ? 1 : 0;

		// check if all collider passed
		if( kumoColliderCount == kumoTotalCollider )
		{
			isKumoPassed  = !isKumoPassed;
			kumoColliderCount = 0;
		}
		if( oniColliderCount == oniTotalCollider )
		{
			isOniPassed = !isOniPassed;
			oniColliderCount = 0;
		}
	}



	public bool getBothPassed()
	{
		return isKumoPassed && isOniPassed;
	}
}
