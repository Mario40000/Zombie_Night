using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie1 : MonoBehaviour {

    private Transform player;
    private bool target = false;
    private Animator animator;

    public NavMeshAgent agent;



	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (target == true && player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent.SetDestination(player.position);
            animator.SetBool("Spoted", true);
            
        }
        else
        {
            animator.SetBool("Spoted", false);
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = true;
        }
    }


}
