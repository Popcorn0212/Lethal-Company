using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WebTrigger : MonoBehaviour
{
    public SpiderAI sa;
    public GameObject spider;
    public float currentTime;
    bool timer = false;

    void Start()
    {
        sa = spider.GetComponent<SpiderAI>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            sa.myState = SpiderAI.EnemyState.Walk;
            sa.target = this.transform;
        }
    }
}
