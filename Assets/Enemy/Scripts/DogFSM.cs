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
        AttackDelay,
    }

    public EnemyState myState;
    public Animator enemyAnim;
    public Transform player;
    public Collider walk;
    public Collider run;
    NavMeshAgent agent;
    Transform target;
    Vector3 curPos;
    Vector3 nextPos;
    float currentTime = 0;
    float idleTime = 3;
    float walkRad = 10;


    void Start()
    {
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
            case EnemyState.AttackDelay:
                AttackDelay();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(walk || run)
        //{
           // myState = EnemyState.Trace;
           // enemyAnim.SetTrigger("Trace");

            //if (other.gameObject.name == "Player")
            //{
            //    myState = EnemyState.Attack;
            //    enemyAnim.SetTrigger("Attack");
            //}
        //}
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

        if(target.magnitude < 5)
        {
            myState = EnemyState.Trace;
            enemyAnim.SetTrigger("Trace");
            agent.isStopped = false;
        }
    }
    
    public void Trace()
    {
        agent.SetDestination(player.position);
        enemyAnim.SetTrigger("Trace");

        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        if (dir.magnitude < 0.3f)
        {
            // 공격 범위 이내로 들어가면 상태를 Attack 상태로 전환한다.
            currentTime = 0;

            // 타겟을 향해 회전한다.
            Vector3 lookDir = player.position - transform.position;
            lookDir.Normalize();
            transform.rotation = Quaternion.LookRotation(lookDir);

            myState = EnemyState.Attack;
            enemyAnim.SetTrigger("Attack");

            agent.isStopped = true;
            agent.ResetPath();
        }
    }
    
    public void Attack()
    {
        // 공격을 한다


        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > 0.3f)
        {
            // 다시 추격 상태로 전환한다.
            agent.isStopped = false;
            myState = EnemyState.Trace;
            enemyAnim.SetTrigger("Trace");
            currentTime = 0;
            return;
        }
    }
    
    public void AttackDelay()
    {
        currentTime += Time.deltaTime;
        enemyAnim.SetTrigger("AttackDelay");

        if (currentTime > 2)
        {
            currentTime = 0;
            myState = EnemyState.Attack;
            enemyAnim.SetTrigger("Attack");
        }
    }
}
