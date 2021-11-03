using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public Canvas MainMenuButtons;

	private Button PlayButton;
	private Button OptionsButton;
	private Button CreditsButton;
	private Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
		// Find buttons
		PlayButton = MainMenuButtons.transform.Find( "PlayButton" ).GetComponent<Button>();
		OptionsButton = MainMenuButtons.transform.Find( "OptionsButton" ).GetComponent<Button>();
		CreditsButton = MainMenuButtons.transform.Find( "CreditsButton" ).GetComponent<Button>();
		ExitButton = this.transform.Find( "ExitButton" ).GetComponent<Button>();

		// Button listeners
		PlayButton.onClick.AddListener( LoadLevel1 );
		ExitButton.onClick.AddListener( QuitGame );
    }

    // Load level 1 of the game
	private void LoadLevel1()
	{
		SceneManager.LoadScene( "Level1", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}

	private void QuitGame()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
