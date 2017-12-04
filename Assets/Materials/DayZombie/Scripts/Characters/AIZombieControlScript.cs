using System;
using UnityEngine;

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
        private AudioSource punch;

        public int damageForce;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animator = GetComponent<Animator>();
            punch = GetComponent<AudioSource>();

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
                
            }
        }


        //Metodo para dañar al player
        void OnCollisionEnter (Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                punch.Play();
                StaticData.life -= damageForce;
            }
        }



    }
}