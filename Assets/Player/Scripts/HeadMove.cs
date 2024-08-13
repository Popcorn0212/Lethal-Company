using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    public Transform player;
    public static float rotY;

    // ȸ�� ���� �̸� ����ϱ� ���� ȸ����(x, y) ����
    float rotX;


    void Start()
    {
        // ������ ȸ�� ���·� ������ �ϰ�ʹ�.
        rotX = transform.eulerAngles.x;

    }

    void Update()
    {
        transform.forward = player.forward;
        Rotate();
    }

    void Rotate()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        // �� �� ���� ȸ�� ���� �̸� ����Ѵ�.
        rotX += mouseY * rotSpeed * Time.deltaTime;

        // ���� ȸ���� -60�� ~ +60�������� �����Ѵ�.
        if (rotX > 60.0f)
        {
            rotX = 60.0f;
        }
        else if (rotX < -60.0f)
        {
            rotX = -60.0f;
        }

        // ���� ȸ�� ���� ���� transform ȸ�� ������ �����Ѵ�.
        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
        Camera.main.transform.GetComponent<FollowCamera>().rotX = rotX;
    }
}
