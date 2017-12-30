using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text lifeText;
    public Text livesText;
    public Text dieText;
    public GameObject lightsController;
    public GameObject fullController;
    public GameObject explosion;
    private GameObject instancier;

	// Use this for initialization
	void Start ()
    {
        StaticData.life = 100;
        lightsController.SetActive(false);
        fullController.SetActive(false);
        dieText.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeText.text = "Life: " + StaticData.life;
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
            dieText.text = "YOU DIE";
        }
       
        yield return new WaitForSeconds(3);
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
