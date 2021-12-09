using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D( Collider2D other )
	{
		if( other.tag == "Kumo" || other.tag == "Oni" )
		{
			GameManager.Instance.FinishLevel2();
		}
	}
}
