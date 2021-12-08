using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
	public static int currentLevel{ get; private set; }

	// Load the main menu of the game
	public static void LoadMainMenu()
	{
        SceneManager.LoadScene( "MainMenu", LoadSceneMode.Single );
		currentLevel = 0;
	}

	// Load intro narrative
	public static void LoadIntro()
	{
	}

    // Load level 1 of the game
	public static void LoadLevel1()
	{
		SceneManager.LoadScene( "Level1", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
		currentLevel = 1;
	}

    // Load underground of level 1
	public static void LoadUnderground()
	{
		SceneManager.LoadScene( "underground", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
		currentLevel = 1;
	}

	// Load transition narrative between level 1 and 2
	public static void LoadTransition1()
	{
	}

	// Load Level 2 of the game
	public static void LoadLevel2()
	{
		SceneManager.LoadScene( "Level2", LoadSceneMode.Single );
		SceneManager.LoadScene( "roof", LoadSceneMode.Additive );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
		currentLevel = 2;
	}

    // Load roof of level 2
	public static void LoadRoof()
	{
		SceneManager.LoadScene( "roof", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
		currentLevel = 2;
	}

	// Load transition narrative between level 2 and 3
	public static void LoadTransition2()
	{
	}

	// Load Level 3 of the game
	public static void LoadLevel3()
	{
		SceneManager.LoadScene( "lvl3", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
		currentLevel = 3;
	}

	// Load good ending of the game
	public static void LoadGoodEnding()
	{
	}

	// Load bad ending of the game
	public static void LoadBadEnding()
	{
	}

	// Load the game over screen
	public static void LoadGameOver()
	{
		SceneManager.LoadScene( "GameOver", LoadSceneMode.Single );
		currentLevel = 0;
	}

	// reset current level
	public static void ResetLevel()
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
}
