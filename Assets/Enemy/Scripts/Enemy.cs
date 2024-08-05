using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;  // NavMeshAgent ������Ʈ�� ������ ����

    public Transform target;  // Ÿ��(�÷��̾�)�� ��ġ�� ����
    public GameObject img_dead;  // ��� ȭ�� ����

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent ������Ʈ�� ��������
        img_dead.gameObject.SetActive(false);  // ��� ȭ�� ��Ȱ��ȭ
    }

    void Update()
    {
        agent.SetDestination(target.position);  // ������ Ÿ������ �������� ����
    }

    // �÷��̾�� ���˽� ��� ȭ�� Ȱ��ȭ
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            img_dead.gameObject.SetActive(true);
        }
    }
}
