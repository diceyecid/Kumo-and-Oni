using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellMenuManager : MonoBehaviour
{
	public Button InitButton;
	public Canvas ShellMenu;

	private Button ResumeButton;
	private Button OptionsButton;
	private Button MainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
		// Find all the shell menu button
		ResumeButton = ShellMenu.transform.Find( "ResumeButton" ).GetComponent<Button>();
		OptionsButton = ShellMenu.transform.Find( "OptionsButton" ).GetComponent<Button>();
		MainMenuButton = ShellMenu.transform.Find( "MainMenuButton" ).GetComponent<Button>();

		// Hide the shell menu by default 
      	ShellMenu.gameObject.SetActive( false );

		// Button listeners
	   	InitButton.onClick.AddListener( ToggleShellMenu );
		ResumeButton.onClick.AddListener( ToggleShellMenu ); 	// It will only turn off shell menu
		OptionsButton.onClick.AddListener( OpenOptionsMenu );
		MainMenuButton.onClick.AddListener( OpenMainMenu );
    }

	// Turn on and turn off shell menu
	void ToggleShellMenu()
	{
		ShellMenu.gameObject.SetActive( !ShellMenu.gameObject.activeSelf );
	}

	// Open up the options menu
	void OpenOptionsMenu()
	{
		
	}

	// Go back to main menu
	void OpenMainMenu()
	{

	}
}
