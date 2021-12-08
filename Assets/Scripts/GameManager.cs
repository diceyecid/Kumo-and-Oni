using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			return _instance;
		}
	}

	public int currentLevel{ get; set; }
	public int kumoHealth{ get; private set; }
	public int oniHealth{ get; private set; }



/********** life cycle hooks **********/ 



	// Awake is called when the script instance is being loaded
	private void Awake()
	{
		// prevent more than one game manager initiates
		if( _instance == null )
			_instance = this;
		else if( _instance != this )
			Destroy( gameObject );

		// make this game manager stay consistent across scene loads
		DontDestroyOnLoad( gameObject );
	}
	
    // Start is called before the first frame update
    private void Start()
    {
	   kumoHealth = 5;
	   oniHealth = 5;
    }

    // Update is called once per frame
    private void Update()
    {
		if( SceneLoader.currentLevel > 0 )
		{
			GameObject kumo = GameObject.FindWithTag("Kumo");
			PlayerHealth kumoHealth = kumo.GetComponent<PlayerHealth>();

			GameObject oni = GameObject.FindWithTag("Oni");
			PlayerHealth oniHealth = oni.GetComponent<PlayerHealth>();

			if(oniHealth.health <= 0 && kumoHealth.health <= 0)
			{
				print("Gameover");
				GameOver();
			}
		}
    }



/********** public methods **********/



	// initialize game from level 1
	public void Init()
	{
		SceneLoader.LoadLevel1();
	}

	// players died, game over
	public void GameOver()
	{
		SceneLoader.LoadGameOver();
	}

	// reset current level
	public void ResetLevel()
	{
		switch( currentLevel )
		{
			case 1: 
				SceneLoader.LoadLevel1();
				break;
			case 2:
				SceneLoader.LoadLevel2();
				break; 
			case 3:
				SceneLoader.LoadLevel3();
				break; 
		}
	}

	// finishes level 1
	public void FinishLevel1()
	{
		// save health stats 
		kumoHealth = GameObject.FindWithTag( "Kumo" ).GetComponent<PlayerHealth>().health;
		oniHealth = GameObject.FindWithTag( "Oni" ).GetComponent<PlayerHealth>().health;
		
		SceneLoader.LoadLevel2();
	}

	// finishes level 2
	public void FinishLevel2()
	{
		// save health stats 
		kumoHealth = GameObject.FindWithTag( "Kumo" ).GetComponent<PlayerHealth>().health;
		oniHealth = GameObject.FindWithTag( "Oni" ).GetComponent<PlayerHealth>().health;
		
		SceneLoader.LoadLevel3();
	}
}
