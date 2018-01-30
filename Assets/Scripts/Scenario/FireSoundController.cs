using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundController : MonoBehaviour
{
    public GameObject mainTheme;

    //Al entrar en la zona del incendio intensificamos el FX
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainTheme.GetComponent<AudioSource>().volume = 0.05f;
            gameObject.GetComponent<AudioSource>().volume = 1f;
        }
    }

    //Al salir lo dejamos como estaba
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainTheme.GetComponent<AudioSource>().volume = 0.15f;
            gameObject.GetComponent<AudioSource>().volume = 0f;
        }
    }

}
