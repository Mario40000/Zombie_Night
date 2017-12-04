using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarKillController : MonoBehaviour
{

    public Transform instancier;
    public GameObject money;
    public GameObject explosion;

    private GameObject sound;

	// Use this for initialization
	void Start ()
    {
        sound = GameObject.Find("DeadSound");
	}
	
	
    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Car")
        {
            sound.GetComponent<AudioSource>().Play();
            Instantiate(money, instancier.position, Quaternion.identity);
            Instantiate(explosion, instancier.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
