using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public BoxCollider col;

    public static Enemy en;
    public Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<BoxCollider>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        other = col;
        if(col.gameObject.tag == "Player")
        {
            agent.SetDestination(target.position);
        }
    }

    public void Trace()
    {
        
    }
}
