using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
	public GameObject Overlay;
	public Canvas ShellMenu;

	public Button Level1;
	public Button Level2;
	public Button Level3;

    // Start is called before the first frame update
    void Start()
    {
		// Hide the shell menu by default
      	ShellMenu.gameObject.SetActive( false );

		// Button listeners
		Level1.onClick.AddListener( SceneLoader.LoadLevel1 );
		Level2.onClick.AddListener( SceneLoader.LoadLevel2 );
		Level3.onClick.AddListener( SceneLoader.LoadLevel3 );
    }

	void Update()
	{
		if( Input.GetKeyDown( InputKey.CHEAT ) )
		{
			Overlay.gameObject.SetActive( !Overlay.gameObject.activeSelf );
			ShellMenu.gameObject.SetActive( !ShellMenu.gameObject.activeSelf );
		}
	}
}
