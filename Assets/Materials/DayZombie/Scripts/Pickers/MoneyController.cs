using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{

    public int speed;
    public int value;

    private GameObject sound;
	// Use this for initialization
	void Start ()
    {
        sound = GameObject.Find("MoneySound");
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            StaticData.money += value;
            Destroy(gameObject);
        }
    }
}
