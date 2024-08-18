using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DogFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Walk,
        Trace,
        Attack,
        AttackDelay,
    }

    public EnemyState myState;
    public Animator enemyAnim;
    public Transform player;
    public GameObject img_hit;
    public GameObject model;

    AudioSource hitSound;
    NavMeshAgent agent;
    Transform target;
    Vector3 curPos;
    Vector3 nextPos;

    float currentTime = 0;
    float idleTime = 3;
    float walkRad = 20;


    void Start()
    {
        hitSound = model.GetComponent<AudioSource>();
        myState = EnemyState.Idle;
        agent = GetComponent<NavMeshAgent>();
        curPos = transform.position;
        nextPos = curPos;
        currentTime = 0;
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
            //case EnemyState.AttackDelay:
            //    AttackDelay();
            //    break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(walk || run)
        //{
        // myState = EnemyState.Trace;
        // enemyAnim.SetTrigger("Trace");

        if (other.gameObject.name == "Player")
        {
            myState = EnemyState.Attack;
            enemyAnim.SetTrigger("Attack");
            currentTime = 0;

            currentTime += Time.deltaTime;

            img_hit.gameObject.SetActive(true);

            if (currentTime >= 1)
            {
                img_hit.gameObject.SetActive(false);
            }
            if (currentTime >= 2.5f)
            {
                img_hit.gameObject.SetActive(true);
                currentTime = 0;
            }
        }
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            myState = EnemyState.Trace;
            enemyAnim.SetTrigger("Trace");
            currentTime = 0;
        }
    }

    public void Idle()
    {
        currentTime += Time.deltaTime;

        if(currentTime > idleTime)
        {
            currentTime = 0;
            myState = EnemyState.Walk;
            enemyAnim.SetBool("isWalk", true);

            agent.SetDestination(nextPos);
        }
    }

    public void Walk()
    {
        currentTime = 0;

        Vector3 dir = nextPos - transform.position;
        Vector3 target = player.position - transform.position;

        if(dir.magnitude < 0.5f)
        {
            Vector2 newPos = Random.insideUnitCircle * walkRad;
            nextPos = curPos + new Vector3(newPos.x, 0, newPos.y);

            myState = EnemyState.Idle;
            enemyAnim.SetBool("isWalk", false);

            agent.isStopped = true;
            agent.ResetPath();
        }

        if (target.magnitude < 10)
        {
            myState = EnemyState.Trace;
            enemyAnim.SetTrigger("Trace");
            agent.isStopped = false;
        }
    }
    
    public void Trace()
    {
        currentTime = 0;

        agent.SetDestination(player.position);
        agent.speed = 9;

        Vector3 dir = player.position - transform.position;

        if (dir.magnitude <= 0.5f)
        {
            // 공격 범위 이내로 들어가면 상태를 Attack 상태로 전환한다.
            //currentTime = 0;

            // 타겟을 향해 회전한다.
            //Vector3 lookDir = player.position - transform.position;
            //lookDir.Normalize();
            //transform.rotation = Quaternion.LookRotation(lookDir);

            //myState = EnemyState.Attack;
            //enemyAnim.SetTrigger("Attack");

            agent.isStopped = true;
            agent.ResetPath();
        }
    }
    
    public void Attack()
    {
        // 공격을 한다
        hitSound.Play();
    }
    
    //public void AttackDelay()
    //{
    //    currentTime += Time.deltaTime;
    //    enemyAnim.SetTrigger("AttackDelay");

    //    if (currentTime >= 2)
    //    {
    //        currentTime = 0;
    //        myState = EnemyState.Attack;
    //        enemyAnim.SetTrigger("Attack");
    //    }
    //}
}
