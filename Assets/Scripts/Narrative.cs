using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrative : MonoBehaviour
{
	public Button btn;
	public int level;

	// Start is called before the first frame update
	void Start()
	{
		btn.onClick.AddListener( delegate{ SceneLoader.LoadLevel( level ); } );
	}

	// Update is called once per frame
	void Update()
	{

	}
}
