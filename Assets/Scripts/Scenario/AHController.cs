using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AHController : MonoBehaviour {

    public Text finalText;
    public Transform rotor;
    public Transform heli;
    public GameObject mainCam;
    public GameObject cam;

    private bool win = false;

    void FixedUpdate ()
    {
        if (win == true)
        {
            rotor.Rotate(Vector3.up * Time.deltaTime * StaticData.speed);
            heli.Rotate(Vector3.up * Time.deltaTime * StaticData.speed);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            cam.SetActive(false);
            mainCam.SetActive(true);
            GameObject PJ = GameObject.FindGameObjectWithTag("Player");
            PJ.SetActive(false);
            StartCoroutine(WinGame());
        }
    }

    IEnumerator WinGame()
    {
        win = true;
        finalText.text = "You escape";
        
        while (StaticData.speed < 1000)
        {
            yield return new WaitForSeconds(1);
            StaticData.speed += 50;
        }

        SceneManager.LoadScene("TitleScene");
        
    }
}
