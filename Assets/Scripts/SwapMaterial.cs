using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
	public Material normal;
	public Material diffuse;

	private bool isDiffuse = false;

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
			SpriteRenderer renderer = other.GetComponent<SpriteRenderer>();
			if( renderer )
			{
				renderer.material = isDiffuse ? normal : diffuse;
				isDiffuse = !isDiffuse;
			}
		}
	}
}
