using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null && Camera.main.gameObject.activeInHierarchy)
        {
            // ���� ���� ������ ���� ī�޶� ���� �ٶ󺸴� ����� ��ġ��Ų��.
            transform.forward = (Camera.main.transform.position - transform.position).normalized * -1;
        }
    }
}
