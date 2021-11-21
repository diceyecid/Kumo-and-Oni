using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	private const int LEFT = 0;
	private const int NEUTRAL = 1;
	private const int RIGHT = 2;

	public Sprite left;
	public Sprite neutral;
	public Sprite right;

	private Sprite[] sprites;
	private int state;
	private SpriteRenderer spriteRenderer;
	private GameObject kumo;
	private GameObject oni;
	
    // Start is called before the first frame update
    void Start()
    {
		// initialize lever sprites and state
		sprites = new Sprite[3];
		sprites[LEFT] = left;
		sprites[NEUTRAL] = neutral;
		sprites[RIGHT] = right;
		state = NEUTRAL;

		// get sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
		if( spriteRenderer.sprite == null )
			spriteRenderer.sprite = sprites[state];

		// get Kumo and Oni
		kumo = GameObject.FindGameObjectsWithTag( "Kumo" )[0];
		oni = GameObject.FindGameObjectsWithTag( "Oni" )[0];
    }

    // Update is called once per frame
    void Update()
    {
		detectInteraction();
    }

	// detect player input to identify interaction with lever 
	void detectInteraction()
	{
		// Kumo interaction with lever
		if( Input.GetKeyDown( InputKey.KumoInteract ) ) 
		{
			// distance between Kumo and lever
			float dist = kumo.transform.position.x - this.transform.position.x;

			// Kumo interacts the lever from the left
			if( dist > -1 && dist < 0 && state < RIGHT )
			{
				state++;
				spriteRenderer.sprite = sprites[state];
			}

			// Kumo interacts the lever from the right
			else if( dist > 0 && dist < 1 && state > LEFT )
			{
				state--;
				spriteRenderer.sprite = sprites[state];
			}
		}

		// Oni interaction with lever
		else if( Input.GetKeyDown( InputKey.OniInteract ) )
		{
			// distance between Oni and lever
			float dist = oni.transform.position.x - this.transform.position.x;

			// Oni interacts the lever from the left
			if( dist > -1 && dist < 0 && state < RIGHT )
			{
				state++;
				spriteRenderer.sprite = sprites[state];
			}

			// Oni interacts the lever from the right
			else if( dist > 0 && dist < 1 && state > LEFT )
			{
				state--;
				spriteRenderer.sprite = sprites[state];
			}
		}
	}
}
