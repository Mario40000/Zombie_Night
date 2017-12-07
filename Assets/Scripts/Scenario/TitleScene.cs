using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

    private void Start()
    {
        StaticData.life = 100;
        StaticData.lives = 3;
        StaticData.speed = 0;
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }
}
