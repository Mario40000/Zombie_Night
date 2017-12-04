using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public Text moneyText;
	// Use this for initialization
	void Start ()
    {
        moneyText.text = "Your total currency is: " + StaticData.money + " $$$";
	}
	
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
        StaticData.money = 0;
        StaticData.lives = 3;
        SceneManager.LoadScene("TitleScene");
    }
}
