using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAI : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        AttackDelay,
    }

    public static SpiderAI intance;
    public EnemyState myState = EnemyState.Idle;
    public Animator enemyAnim;
    public Transform player;
    public Transform target;  // 타겟(감지된 거미줄)의 위치를 지정
    public GameObject img_hitEffect;

    NavMeshAgent agent;  // NavMeshAgent 컴포넌트를 저장할 변수
    float currentTime;
    int hitCount = 0;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent 컴포넌트를 가져오기
        myState = EnemyState.Idle;
        hitCount = 0;
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
        if (other.gameObject.name == "Player")
        {
            target = player;

            myState = EnemyState.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            myState = EnemyState.Walk;
        }
    }

    public void Idle()
    {
        enemyAnim.SetTrigger("Idle");

        currentTime = 0;
    }

    public void Walk()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            enemyAnim.SetTrigger("Walk");

            if (target != player)
            {
                float dist = Vector3.Distance(agent.transform.position, target.transform.position);
                if (dist <= 0.2f)
                {
                    agent.isStopped = true;
                    enemyAnim.SetTrigger("Idle");
                }
                else
                {
                    agent.isStopped = false;
                    enemyAnim.SetTrigger("Walk");
                }
            }
        }
        currentTime = 0;
    }

    public void Attack()
    {
        currentTime += Time.deltaTime;
        transform.forward = player.forward * -1;
        enemyAnim.SetTrigger("Attack");

        Cursor.lockState = CursorLockMode.None;
        img_hitEffect.gameObject.SetActive(true);

        if(currentTime > 1.1f)
        {
            myState = EnemyState.AttackDelay;
            img_hitEffect.gameObject.SetActive(false);
            currentTime = 0;
        }
    }

    public void AttackDelay()
    {
        enemyAnim.SetTrigger("AttackDelay");

        currentTime += Time.deltaTime;

        if (currentTime > 2.0f)
        {
            myState = EnemyState.Attack;
            currentTime = 0;
        }
    }
}
