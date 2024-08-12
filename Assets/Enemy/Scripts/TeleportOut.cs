using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOut : MonoBehaviour
{
    // 밖으로 나가는 장치
    public Transform outerPos;
    public GameObject target;
    public GameObject dirLight;

    CharacterController cc;

    private void Start()
    {
        cc = target.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            cc.enabled = false;
            other.transform.position = outerPos.position;

            dirLight.gameObject.SetActive(true);
            RenderSettings.fog = true;
        }
        cc.enabled = true;
    }
}
