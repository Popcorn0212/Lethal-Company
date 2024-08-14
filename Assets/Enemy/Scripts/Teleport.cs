using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // ���� ������ ���� ��ġ
    public Transform innerPos;
    public GameObject target;
    public GameObject dirLight;

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

            dirLight.gameObject.SetActive(false);
            RenderSettings.fog = false;
        }
        cc.enabled = true;
    }
}
