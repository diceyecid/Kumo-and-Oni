using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundEntrance : MonoBehaviour
{
	public GameObject floorGate;
	public  GameObject[] torches;

	private string correctOrder;
	private string currentOrder;
	private bool isFloorDropAnim;
	private float timeCount;
	
    // Start is called before the first frame update
    void Start()
    {
		correctOrder = "3120";
		currentOrder = "";
		isFloorDropAnim = false;
		timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
		checkTorches();
		
		if( currentOrder == correctOrder )
		{
			isFloorDropAnim = true;
		}

		if( isFloorDropAnim )
		{
			floorGate.transform.Translate( 0, timeCount * -1, 0 );
			timeCount += Time.deltaTime;
		}
	
		if( timeCount >= 20 )
		{
			isFloorDropAnim = false;
			floorGate.SetActive( false );
		}
    }

	void checkTorches()
	{
		for( int i = 0; i < torches.Length; i++ )
		{
			Animator anim = torches[i].GetComponent<Animator>();

			if( anim.GetBool( "isLit" )  && !currentOrder.Contains( i.ToString() ) )
			{
				currentOrder += i.ToString();	
			}
			else if( !anim.GetBool( "isLit" ) && currentOrder.Contains( i.ToString() ) )
			{
				currentOrder = currentOrder.Replace( i.ToString(), "" );
			}
		}
	}
}
