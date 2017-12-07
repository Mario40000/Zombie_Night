using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            returnMenu();
        }
	}

    void returnMenu()
    {
        StaticData.life = 100;
        StaticData.lives = 3;
        StaticData.speed = 0;
        SceneManager.LoadScene("TitleScene");
    }
}
