using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        print("Gameover screen active");
    }

    public void ReloadLevel1()
    {
		SceneLoader.ResetLevel();
    }

    public void ReloadLevel2()
    {
        SceneLoader.LoadLevel2();
    }

    public void ReloadLevel3()
    {
        SceneLoader.LoadLevel3();
    }

    public void ExitButton()
    {
        SceneLoader.LoadMainMenu();
	}
}
