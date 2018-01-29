using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVoiceController : MonoBehaviour
{
    public float timeBetweenVoice;

    public GameObject[] voices;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Voices());
	}
	
    //Metodo para ir repitiendo sonidos aleatorios en el zombie
    IEnumerator Voices ()
    {
        while(true)
        {
            float timeSpeed = (Random.Range(timeBetweenVoice - 2, timeBetweenVoice + 2));
            int num = (Random.Range(0, voices.Length));
            voices[num].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(timeSpeed);
        }
    }
}
