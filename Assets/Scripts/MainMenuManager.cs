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

    // Start is called before the first frame update
    void Start()
    {
		// Find buttons
		PlayButton = MainMenuButtons.transform.Find( "PlayButton" ).GetComponent<Button>();
		OptionsButton = MainMenuButtons.transform.Find( "OptionsButton" ).GetComponent<Button>();
		CreditsButton = MainMenuButtons.transform.Find( "CreditsButton" ).GetComponent<Button>();

		// Button listeners
		PlayButton.onClick.AddListener( LoadLevel1 );
    }

    // Load level 1 of the game
	void LoadLevel1()
	{
		SceneManager.LoadScene( "Level1", LoadSceneMode.Single );
		SceneManager.LoadScene( "GUI", LoadSceneMode.Additive );
	}
}
