using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // 공장 안으로 들어가는 장치
    public Transform innerPos;
    public GameObject target;
    CharacterController cc;

    private void Start()
    {
        cc = target.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            cc.enabled = false;
            other.transform.position = innerPos.position;
        }
        cc.enabled = true;
    }
}
