using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	public const int LEFT = 0;
	public const int NEUTRAL = 1;
	public const int RIGHT = 2;

	public Sprite left;
	public Sprite neutral;
	public Sprite right;

	private int state;
	private Sprite[] sprites;
	private Vector2[][] colliderPoints;

	private SpriteRenderer spriteRenderer;
	private PolygonCollider2D polygonCollider;

	private GameObject kumo;
	private GameObject oni;
	


    // Start is called before the first frame update
    void Start()
    {
		// initialize lever state and sprites
		state = NEUTRAL;
		sprites = new Sprite[3];
		sprites[LEFT] = left;
		sprites[NEUTRAL] = neutral;
		sprites[RIGHT] = right;

		// initialize lever polygon collider vertices
		colliderPoints = new Vector2[3][];
		initColliderPoints( colliderPoints );

		// get sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprites[state];

		// get polygon collider 
		polygonCollider = GetComponent<PolygonCollider2D>();
		polygonCollider.SetPath( 0, colliderPoints[state] );

		// get Kumo and Oni
		kumo = GameObject.FindGameObjectsWithTag( "Kumo" )[0];
		oni = GameObject.FindGameObjectsWithTag( "Oni" )[0];
    }



    // Update is called once per frame
    void Update()
    {
		detectInteraction();
    }



/********** getters and setters **********/

	// get current state of lever
	public int getState()
	{
		return state;
	}

	// set current state of lever
	public void setState( int s )
	{
		state = s;

		// change the sprite and collider to the new state
		spriteRenderer.sprite = sprites[state];
		polygonCollider.SetPath( 0, colliderPoints[state] );
	}



/********** private methods **********/

	// initialize the collider points for each state
	private void initColliderPoints( Vector2[][] colliderPoints )
	{
		// left state
		colliderPoints[LEFT] = new Vector2[16];
		colliderPoints[LEFT][0] = new Vector2( 0.1244888f, -0.2826375f );
		colliderPoints[LEFT][1] = new Vector2( 0.1244888f, -0.2173069f );
		colliderPoints[LEFT][2] = new Vector2( -0.1887436f, 0.4687598f );
		colliderPoints[LEFT][3] = new Vector2( -0.3132197f, 0.4687598f );
		colliderPoints[LEFT][4] = new Vector2( -0.3132197f, 0.09808946f );
		colliderPoints[LEFT][5] = new Vector2( -0.06165314f, -0.2173069f );
		colliderPoints[LEFT][6] = new Vector2( -0.1265488f, -0.2173069f );
		colliderPoints[LEFT][7] = new Vector2( -0.1265488f, -0.2826375f );
		colliderPoints[LEFT][8] = new Vector2( -0.5620651f, -0.2826375f );
		colliderPoints[LEFT][9] = new Vector2( -0.5620651f, -0.4070233f );
		colliderPoints[LEFT][10] = new Vector2( -0.6875f, -0.4070233f );
		colliderPoints[LEFT][11] = new Vector2( -0.6875f, -0.53125f );
		colliderPoints[LEFT][12] = new Vector2( 0.6875f, -0.53125f );
		colliderPoints[LEFT][13] = new Vector2( 0.6875f, -0.4070233f );
		colliderPoints[LEFT][14] = new Vector2( 0.5620651f, -0.4070233f );
		colliderPoints[LEFT][15] = new Vector2( 0.5620651f, -0.2826375f );
		
		// neutral state
		colliderPoints[NEUTRAL] = new Vector2[17];
		colliderPoints[NEUTRAL][0] = new Vector2( -0.06399028f, 0.53125f );
		colliderPoints[NEUTRAL][1] = new Vector2( -0.06399028f, -0.2199031f );
		colliderPoints[NEUTRAL][2] = new Vector2( -0.1265488f, -0.2199031f );
		colliderPoints[NEUTRAL][3] = new Vector2( -0.1265488f, -0.2826375f );
		colliderPoints[NEUTRAL][4] = new Vector2( -0.5620651f, -0.2826375f );
		colliderPoints[NEUTRAL][5] = new Vector2( -0.5620651f, -0.4070233f );
		colliderPoints[NEUTRAL][6] = new Vector2( -0.6875f, -0.4070233f );
		colliderPoints[NEUTRAL][7] = new Vector2( -0.6875f, -0.53125f );
		colliderPoints[NEUTRAL][8] = new Vector2( 0.6875f, -0.53125f );
		colliderPoints[NEUTRAL][9] = new Vector2( 0.6879272f, -0.4070233f );
		colliderPoints[NEUTRAL][10] = new Vector2( 0.6879272f, -0.4070233f );
		colliderPoints[NEUTRAL][11] = new Vector2( 0.5618668f, -0.4070233f );
		colliderPoints[NEUTRAL][12] = new Vector2( 0.5618668f, -0.2826375f );
		colliderPoints[NEUTRAL][13] = new Vector2( 0.1246872f, -0.2826375f );
		colliderPoints[NEUTRAL][14] = new Vector2( 0.1246872f, -0.2199031f );
		colliderPoints[NEUTRAL][15] = new Vector2( 0.06211853f, -0.2199363f );
		colliderPoints[NEUTRAL][16] = new Vector2( 0.06211853f, 0.53125f );
		
		// right state
		colliderPoints[RIGHT] = new Vector2[16];
		colliderPoints[RIGHT][0] = new Vector2( 0.1244888f, -0.2826375f );
		colliderPoints[RIGHT][1] = new Vector2( 0.1244888f, -0.2173069f );
		colliderPoints[RIGHT][2] = new Vector2( 0.06165314f, -0.2173069f );
		colliderPoints[RIGHT][3] = new Vector2( 0.3132197f, 0.1124535f );
		colliderPoints[RIGHT][4] = new Vector2( 0.3132197f, 0.4687598f );
		colliderPoints[RIGHT][5] = new Vector2( 0.1887436f, 0.4687598f );
		colliderPoints[RIGHT][6] = new Vector2( -0.1265488f, -0.2173069f );
		colliderPoints[RIGHT][7] = new Vector2( -0.1265488f, -0.2826375f );
		colliderPoints[RIGHT][8] = new Vector2( -0.5620651f, -0.2826375f );
		colliderPoints[RIGHT][9] = new Vector2( -0.5620651f, -0.4070233f );
		colliderPoints[RIGHT][10] = new Vector2( -0.6875f, -0.4070233f );
		colliderPoints[RIGHT][11] = new Vector2( -0.6875f, -0.53125f );
		colliderPoints[RIGHT][12] = new Vector2( 0.6875f, -0.53125f );
		colliderPoints[RIGHT][13] = new Vector2( 0.6875f, -0.4070233f );
		colliderPoints[RIGHT][14] = new Vector2( 0.5620651f, -0.4070233f );
		colliderPoints[RIGHT][15] = new Vector2( 0.5620651f, -0.2826375f );

	}



	// detect player input to identify interaction with lever 
	private void detectInteraction()
	{
		// Kumo interaction with lever
		if( Input.GetKeyDown( InputKey.KUMO_INTERACT ) ) 
		{
			// distance between Kumo and lever
			float dist = kumo.transform.position.x - this.transform.position.x;
			float height = kumo.transform.position.y - this.transform.position.y;

			// Kumo interacts the lever from the left
			if( dist > -1.5 && dist < 0 && height < 1.5 && state < RIGHT )
			{
				setState( state + 1 );
			}

			// Kumo interacts the lever from the right
			else if( dist > 0 && dist < 1.5 && height < 1.5 && state > LEFT )
			{
				setState( state - 1 );
			}
		}

		// Oni interaction with lever
		else if( Input.GetKeyDown( InputKey.ONI_INTERACT ) )
		{
			// distance between Oni and lever
			float dist = oni.transform.position.x - this.transform.position.x;
			float height = oni.transform.position.y - this.transform.position.y;

			// Oni interacts the lever from the left
			if( dist > -1.5 && dist < 0 && height < 1.5 && state < RIGHT )
			{
				setState( state + 1 );
			}

			// Oni interacts the lever from the right
			else if( dist > 0 && dist < 1.5 && height < 1.5 &&state > LEFT )
			{
				setState( state - 1 );
			}
		}

		return;
	}
}
