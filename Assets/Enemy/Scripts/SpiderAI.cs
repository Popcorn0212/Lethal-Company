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

                break;
            case EnemyState.Walk:

                break;
            case EnemyState.Attack:

                break;
            case EnemyState.AttackDelay:

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

    public void Idle()
    {
        enemyAnim.SetTrigger("Idle");
        agent.isStopped = true;
    }

    public void Walk()
    {
        agent.isStopped = false;

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        enemyAnim.SetTrigger("Walk");
    }

    public void Attack()
    {
        enemyAnim.SetTrigger("Attack");
    }

    public void AttackDelay()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if(dist > 4.0f)
        {
            myState = EnemyState.Walk;
        }
    }
}
