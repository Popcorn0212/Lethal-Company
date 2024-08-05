using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;  // NavMeshAgent 컴포넌트를 저장할 변수

    public Transform target;  // 타겟(플레이어)의 위치를 지정
    public GameObject img_dead;  // 사망 화면 지정

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent 컴포넌트를 가져오기
        img_dead.gameObject.SetActive(false);  // 사망 화면 비활성화
    }

    void Update()
    {
        agent.SetDestination(target.position);  // 지정한 타겟으로 목적지를 설정
    }

    // 플레이어와 접촉시 사망 화면 활성화
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            img_dead.gameObject.SetActive(true);
        }
    }
}
