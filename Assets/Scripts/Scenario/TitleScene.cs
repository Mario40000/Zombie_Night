using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;

    public float time;

    private void Start()
    {
        StaticData.life = 100;
        StaticData.lives = 3;
        StaticData.speed = 0;
    }

   
    //Metodo para empezar a jugar
    public void StartGame ()
    {
        StartCoroutine(StartCoroutine());
    }

    IEnumerator StartCoroutine ()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MainScene");
    }

    //Metodo para salir del juego
    public void ExitGame ()
    {
        StartCoroutine(ExitCoroutine());
    }

    IEnumerator ExitCoroutine()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}
