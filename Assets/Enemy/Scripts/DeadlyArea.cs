using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyArea : MonoBehaviour
{
    public GameObject img_dead;  // ��� ȭ�� ����

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // �÷��̾ ��������(��� ����)�� ���˽� ��� ȭ�� Ȱ��ȭ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            img_dead.gameObject.SetActive(true);
        }
    }
}
