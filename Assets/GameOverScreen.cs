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

    public void ResetButton()
    {
        SceneLoader.LoadLevel1();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
