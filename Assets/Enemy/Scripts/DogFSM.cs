using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Walk,
        Trace,
        Attack,
        ReTrace,
        AttackDelay,
    }

    public EnemyState myState;
    public Animator enemyAnim;
    public Transform player;
    NavMeshAgent agent;
    Transform target;
    float currentTime = 0;


    void Start()
    {
        myState = EnemyState.Idle;
        enemyAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch (myState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Walk:
                Walk();
                break;
            case EnemyState.Trace:
                Trace();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.ReTrace:
                ReTrace();
                break;
            case EnemyState.AttackDelay:
                AttackDelay();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Walk" || other.gameObject.name == "Run")
        {
            target = player;
            transform.forward = player.forward * -1;
            agent.SetDestination(target.position);
        }

        if(other.gameObject.name == "Player")
        {
            myState = EnemyState.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            myState = EnemyState.ReTrace;
        }
    }

    public void Idle()
    {
        enemyAnim.SetBool("isWalk", false);

    }

    public void Walk()
    {
        enemyAnim.SetBool("isWalk", true);

    }
    
    public void Trace()
    {
        enemyAnim.SetBool("isTrace", true);

        if(target = null)
        {
            enemyAnim.SetBool("isTrace", false);
        }
    }
    
    public void Attack()
    {
        currentTime += Time.deltaTime;
        transform.forward = player.forward * -1;
        enemyAnim.SetTrigger("Attack");

        if(currentTime > 1)
        {
            myState = EnemyState.AttackDelay;
            currentTime = 0;
        }
    }

    public void ReTrace()
    {
        enemyAnim.SetTrigger("ReTrace");

    }
    
    public void AttackDelay()
    {
        enemyAnim.SetTrigger("AttackDelay");

    }
}
