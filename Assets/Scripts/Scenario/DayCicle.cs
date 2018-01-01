using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour {

    public float durationInMinutes = 3.0f;
    public GameObject lightsController;
    public GameObject fullController;
    public GameObject skyStars;

    private float timer;
    private float pertcentDay;
    private float turnSpeed;

    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
    }

    // Comprobamos i es de noche o de dia y avanzamos la posicion del sol
    void Update()
    {
        CheckTime();
        UpdateLights();

        turnSpeed = 360.0f / (durationInMinutes * 60.0f) * Time.deltaTime;
        transform.RotateAround(transform.position, transform.right, turnSpeed);
        
        Debug.Log(pertcentDay);
    }

    //Actualizamos la luz del escenario
    void UpdateLights ()
    {
        if (IsNight())
        {
            fullController.SetActive(true);
            lightsController.SetActive(true);
            skyStars.SetActive(true);
            if (GetComponent<Light>().intensity > 0.0f)
            {
                GetComponent<Light>().intensity -= 0.05f;
            }
        }
        else
        {
            lightsController.SetActive(false);
            fullController.SetActive(false);
            skyStars.SetActive(false);
            if (GetComponent<Light>().intensity < 1.0f)
            {
                GetComponent<Light>().intensity += 0.05f;
            }
        }

    }

    //Contador para el ciclo
    void CheckTime()
    {
        timer += Time.deltaTime;
        pertcentDay = timer / (durationInMinutes * 60.0f);
        if (timer > (durationInMinutes * 60.0f))
        {
            timer = 0.0f;
        }
    }
    //Devolvemos true si es de noche
    bool IsNight()
    {
        bool c = false;
        if (pertcentDay > 0.5f)
        {
            c = true;
        }
        return c;

    }
}
