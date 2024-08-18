using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDelayEvent : MonoBehaviour
{
    DogFSM dogState;

    void Start()
    {
        dogState = transform.parent.GetComponent<DogFSM>();
    }

    public void ChangeToAttackDelay()
    {
        dogState.myState = DogFSM.EnemyState.AttackDelay;
    }

    public void AttackHit()
    {
        dogState.Attack();
    }
}
