using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private Animator m_Animator;
    float speed;
    bool isColliding;


    void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();

    }
    private void Start()
    {
        speed = agent.speed;
    }
    void Update()
    {
        agent.destination = Target.transform.position;
        
        if (!isColliding)
        {
            m_Animator.speed = agent.velocity.magnitude;
            m_Animator.SetBool("isAttacking", false);
            if (agent.speed > 2)
            {
                m_Animator.SetBool("isRunning", true);
                m_Animator.SetBool("isWalking", false);

            }
            else if (agent.speed <= 2f)
            {
                m_Animator.SetBool("isRunning", false);
                m_Animator.SetBool("isWalking", true);

            }
            else
            {
                m_Animator.SetBool("isRunning", false);
                m_Animator.SetBool("isWalking", false);
            }
        }
        else
        {
            m_Animator.SetBool("isRunning", false);
            m_Animator.SetBool("isWalking", false);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_Animator.SetTrigger("NormalAttack01_SwordShield");

            m_Animator.SetBool("isAttacking", true);

            isColliding = true;
        }
       
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_Animator.SetTrigger("NormalAttack01_SwordShield");
           
            m_Animator.SetBool("isAttacking", true);

            isColliding = true;


        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            m_Animator.SetBool("isAttacking", true);
            
            
            isColliding = true;

        }
        else
        {
            m_Animator.SetBool("isAttacking", false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_Animator.SetBool("isAttacking", false);
            isColliding = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            m_Animator.SetBool("isAttacking", true);
            m_Animator.SetBool("isRunning", false);
            m_Animator.SetBool("isWalking", false);
            agent.speed = 0;
            isColliding = true;

        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_Animator.SetBool("isAttacking", false);
            isColliding = false;
            agent.speed = speed;

        }
    }
}