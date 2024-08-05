using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyArea : MonoBehaviour
{
    public GameObject img_dead;  // 사망 화면 지정

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 플레이어가 낭떨어지(사망 구역)에 접촉시 사망 화면 활성화
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            img_dead.gameObject.SetActive(true);
        }
    }
}
