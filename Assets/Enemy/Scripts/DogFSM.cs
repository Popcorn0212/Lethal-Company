using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Walk,
        Trace,
        Attack,
        AttackDelay,
    }

    public Animator enemyAnim;



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
