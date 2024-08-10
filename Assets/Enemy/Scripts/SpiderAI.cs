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
    public Transform target;  // Ÿ��(������ �Ź���)�� ��ġ�� ����
    //public GameObject img_dead;  // ��� ȭ�� ����

    NavMeshAgent agent;  // NavMeshAgent ������Ʈ�� ������ ����
    float currentTime;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent ������Ʈ�� ��������
        myState = EnemyState.Idle;
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
        }
        enemyAnim.SetTrigger("Walk");

        currentTime = 0;
    }

    public void Attack()
    {
        currentTime += Time.deltaTime;

        transform.forward = player.forward * -1;

        enemyAnim.SetTrigger("Attack");

        if(currentTime > 1.1f)
        {
            myState = EnemyState.AttackDelay;
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
