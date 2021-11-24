using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    // Load level 1 of the game
	public static void LoadLevel1()
	{
		SceneManager.LoadScene( "Level1", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}

    // Load underground of level 1
	public static void LoadUnderground()
	{
		SceneManager.LoadScene( "underground", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}

	// Load Level 2 of the game
	public static void LoadLevel2()
	{
		SceneManager.LoadScene( "Level2", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}

    // Load roof of level 2
	public static void LoadRoof()
	{
		SceneManager.LoadScene( "roof", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}

	// Load Level 3 of the game
	public static void LoadLevel3()
	{
		SceneManager.LoadScene( "Level3", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}
}
