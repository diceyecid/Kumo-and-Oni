using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundEntrance : MonoBehaviour
{
	public GameObject floorGate;
	public  GameObject[] torches;

	private string correctOrder;
	private string currentOrder;
	
    // Start is called before the first frame update
    void Start()
    {
		correctOrder = "3120";
		currentOrder = "";
    }

    // Update is called once per frame
    void Update()
    {
		checkTorches();
		
		if( currentOrder == correctOrder )
		{
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
