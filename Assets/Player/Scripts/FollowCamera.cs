using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Ÿ������ ������ ��ġ�� ���� �̵���Ų��.
    public float rotX;
    public Transform head;

    void Start()
    {
        
    }


    void Update()
    {
        if (head != null)
        {

            // ī�޶��� ��ġ�� Ÿ�� Ʈ�������� ��ġ�� �����Ѵ�.
            //if (!dynamicCam)
            //{
            //    transform.position = target.position;
            //}
            //else
            //{
            //    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);
            //}

            // ī�޶��� ���� ������ �÷��̾��� ���� �������� �����Ѵ�.
            //Vector3 dir = (player.position - transform.position).normalized;
            transform.forward = head.forward;

            // ������� ���콺 ���� ȸ�� ���� x�� ȸ������ �ִ´�.
            transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
