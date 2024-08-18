using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;  // NavMeshAgent ������Ʈ�� ������ ����

    public Transform target;  // Ÿ��(�÷��̾�)�� ��ġ�� ����
    public GameObject img_dead;  // ��� ȭ�� ����
    public GameObject img_hit;
    float currentTime = 0;
    bool isHit = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent ������Ʈ�� ��������
        img_dead.gameObject.SetActive(false);  // ��� ȭ�� ��Ȱ��ȭ
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);  // ������ Ÿ������ �������� ����
        }
    }

    // �÷��̾�� ���˽� �ǰ� ȭ�� Ȱ��ȭ
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            currentTime += Time.deltaTime;
            img_hit.gameObject.SetActive(true);

            if (currentTime >= 1)
            {
                img_hit.gameObject.SetActive(false);
            }
            if(currentTime >= 2.5f)
            {
                img_hit.gameObject.SetActive(true);
                currentTime = 0;
            }
        }
        else
        {
            img_hit.gameObject.SetActive(false);
        }
    }
}
