using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestriansLifeControllerFemale : MonoBehaviour
{
    public int amountHits;
    public GameObject explosion;
    public GameObject money;
    public Transform instancier;

    private GameObject sound;
    private GameObject voice;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        sound = GameObject.Find("DeadSound");
        voice = GameObject.Find("FemaleScream");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (amountHits <= 0)
        {
            KillPedestrian();
        }
    }

    //Metodo para matar al peaton
    void KillPedestrian()
    {
        sound.GetComponent<AudioSource>().Play();
        Instantiate(money, instancier.position, Quaternion.identity);
        Instantiate(explosion, instancier.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            voice.GetComponent<AudioSource>().Play();
            amountHits--;
            agent.speed = 1;
        }
    }
}
