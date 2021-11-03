using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundEntrance : MonoBehaviour
{
	public GameObject torchGroup;
	//private GameObject redTorch;
	//private GameObject blueTorch;
	//private GameObject greenTorch;
	//private GameObjecf yellowTorch;
	public GameObject floorGate;

	public  GameObject[] torches;
	private string correctOrder;
	private string currentOrder;
	
    // Start is called before the first frame update
    void Start()
    {
		//torchGroup = this.transform.Find( "Torch Group" ).GetComponent<GameObject>();
		//redTorch = torchGroup.transform.Find( "Red Torch" ).GetComponent<GameObject>();
		//blueTorch = torchGroup.transform.Find( "Blue Torch" ).GetComponent<GameObject>();
		//greenTorch = torchGroup.transform.Find( "Green Torch" ).GetComponent<GameObject>();
		//yellowTorch = torchGroup.transform.Find( "Yellow Torch" ).GetComponent<GameObject>();
		//torches = torchGroup.GetChildren();
		//floorGate = this.transform.Find( "Floor Gate" ).GetComponent<GameObject>();

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
