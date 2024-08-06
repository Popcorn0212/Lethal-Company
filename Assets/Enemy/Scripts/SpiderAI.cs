using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAI : MonoBehaviour
{

    NavMeshAgent agent;  // NavMeshAgent 컴포넌트를 저장할 변수
    float currentTime;

    public Transform player;
    public Transform target;  // 타겟(감지된 거미줄)의 위치를 지정
    //public GameObject img_dead;  // 사망 화면 지정

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent 컴포넌트를 가져오기
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
