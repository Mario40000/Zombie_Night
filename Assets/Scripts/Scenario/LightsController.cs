using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour {

    public int time;
    public GameObject[] Controllers;
    public GameObject fullController;
    
    // Use this for initialization
    void Start ()
    {
        fullController.SetActive(true);
        StartCoroutine(LightsOut());
	}


    IEnumerator LightsOut ()
    {
        
        //Esperamos 5 segundos para empezar
        yield return new WaitForSeconds(5);
        //Vamos apagando y encendiendo luces al azar por el escenario
        while (true)
        {
            
                GameObject lightOut = Controllers[Random.Range(0, Controllers.Length)];
                lightOut.SetActive(false);
                yield return new WaitForSeconds(time);
                lightOut.SetActive(true);
            
        }


    }
}
