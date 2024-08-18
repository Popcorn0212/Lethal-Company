using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosStuck : MonoBehaviour
{
    public Transform stuckPos;
    public bool stuckActive = false;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        cc.enabled = true;
    }

    void Update()
    {
        if (stuckActive)
        {
            Stuck();
        }
    }

    void Stuck()
    {
        cc.enabled = false;
        transform.position = stuckPos.position;
    }
}
