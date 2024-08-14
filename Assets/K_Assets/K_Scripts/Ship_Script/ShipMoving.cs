using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoving : MonoBehaviour
{
    [Header("������ ���� ����")]
    public Transform departPos;
    public Transform landPos;


    [Header("���� ���� Ȯ�� ����")]
    public bool alreadyLanding;

    [Header("�̷� ���� Ȯ�� ����")]
    public bool departing;

    [Header("�÷��̾� ã��")]
    public GameObject player;

    //���� Lerp�� �ۼ�Ʈ
    float landPercent = 0;
    
    //�̷� Lerp�� �ۼ�Ʈ
    float departPercent = 0;


    void Start()
    {
        
    }

    void Update()
    {
        //�谡 õõ�� ���������� ���ڴ�
        //�׸��� ���� ���δ� bool�� üũ�Ǿ�� �Ѵ�(�߰� ������ �Ǿ�� �ϹǷ�...)
        //Lerp�� õõ�� �����ϱ�

        if (!departing && !alreadyLanding) //���� ���۽� (���� �������� �ʾҰ�, �̷������� ����)
        {
            landPercent += Time.deltaTime * 0.2f ;
            Vector3 result = Vector3.Lerp(departPos.position, landPos.position, landPercent);

            player.GetComponent<CharacterController>().Move(result - transform.position);

            transform.position = result;
            

            if (Vector3.Distance(transform.position, landPos.position) < 0.3f)
            {
                alreadyLanding = true;
            }
        }
        else if (!departing && alreadyLanding) //�Լ��� �������� �� (�̷��ϱ� ������)
        {
            transform.position = landPos.position;

        }
        else if (departing)
        {
            landPercent += Time.deltaTime * 0.2f;
            Vector3 result = Vector3.Lerp(landPos.position, departPos.position, departPercent);
            player.GetComponent<CharacterController>().Move(result - transform.position);

            transform.position = result;
        }

    }
}
