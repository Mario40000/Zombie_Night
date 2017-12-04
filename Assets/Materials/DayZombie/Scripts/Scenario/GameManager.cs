using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text lifeText;
    public Text moneyText;
    public Text livesText;
    public GameObject explosion;
    private GameObject instancier;

	// Use this for initialization
	void Start ()
    {
        StaticData.life = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeText.text = "Life: " + StaticData.life;
        moneyText.text = StaticData.money + " $$$";
        livesText.text = "Lives: " + StaticData.lives;
		if(StaticData.life <= 0)
        {
            StartCoroutine(GameOver());
        }
	}

    //Metodod de final de partida
    IEnumerator GameOver ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        instancier = GameObject.FindGameObjectWithTag("Player");
        
        
        if (player != null)
        {
            Instantiate(explosion, instancier.GetComponent<Transform>().position, Quaternion.identity);
            StaticData.lives--;
            Destroy(player);
        }
       
        yield return new WaitForSeconds(1);
        if(StaticData.lives > 0)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
        
    }

}
