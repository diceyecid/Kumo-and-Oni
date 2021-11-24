using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject kumo = GameObject.Find("Kumo");
        PlayerHealth kumoHealth = kumo.GetComponent<PlayerHealth>();
        GameObject oni = GameObject.Find("Oni (bigger scale reference)");
        PlayerHealth oniHealth = oni.GetComponent<PlayerHealth>();

        if(oniHealth.health <= 0 && kumoHealth.health <= 0)
        {
            print("Gameover");
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }
}
