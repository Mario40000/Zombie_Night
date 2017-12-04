using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

	
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
