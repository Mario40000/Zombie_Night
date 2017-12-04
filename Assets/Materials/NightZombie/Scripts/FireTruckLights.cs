using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTruckLights : MonoBehaviour {

    public GameObject light1;
    public GameObject light2;

    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        light1.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        light2.transform.Rotate(Vector3.up * Time.deltaTime * speed * -1);
    }
}
