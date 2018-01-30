using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AIZombieControlScript : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        private Animator animator;
        

        public int damageForce;

        public GameObject[] attacks;
        public GameObject alertSound;

        private bool isAttacking = false;
        private bool isAlert = false;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animator = GetComponent<Animator>();
            

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                
            }
            



        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Human" || other.gameObject.tag == "Player")
            {

                target = other.GetComponent<Transform>();

                if (isAlert == false)
                {
                    
                    StartCoroutine(Alert());
                }

                
            }
        }


        //Metodo para atacar al personaje
        void OnCollisionEnter (Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (isAttacking == false)
                {
                    StartCoroutine(Attack());
                }
                
            }
        }

        //Metodo para quietar vida al personaje
        IEnumerator Attack ()
        {
            isAttacking = true;
            StaticData.life -= damageForce;
            int num = (UnityEngine.Random.Range(0, attacks.Length));
            attacks[num].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.5f);
            isAttacking = false;
        }

        //Metodo para hacer sonar una alerta al ser detectados
        IEnumerator Alert ()
        {
            isAlert = true;
            alertSound.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.5f);
            alertSound.GetComponent<AudioSource>().Stop();
        }

    }
}