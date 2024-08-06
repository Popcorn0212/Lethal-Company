using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAI : MonoBehaviour
{

    NavMeshAgent agent;  // NavMeshAgent ������Ʈ�� ������ ����
    float currentTime;

    public Transform player;
    public Transform target;  // Ÿ��(������ �Ź���)�� ��ġ�� ����
    //public GameObject img_dead;  // ��� ȭ�� ����

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent ������Ʈ�� ��������
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            target = player;
        }
    }
}
