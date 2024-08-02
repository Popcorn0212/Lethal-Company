using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public float gravity = -9.81f; // �߷��� ����
    public float initialVelocity = 0f; // �ʱ� �ӵ�
    public float timeStep = 0.02f; // �ð� ����

    public bool isGrab = false;

    private float velocity;
    private float time;

    void Start()
    {
        velocity = initialVelocity;
        time = 0f;
    }


    void Update()
    {
        // �ð� ���� ������Ʈ
        time += Time.deltaTime;

        // �ӵ��� ��ġ ������Ʈ
        velocity += gravity * Time.deltaTime;
        transform.position += new Vector3(0, velocity * Time.deltaTime, 0);

        // �ٴڿ� ����� �� ��ġ�� �����ϰ� �ӵ��� 0���� ����
        if (transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

            gravity = 0;
        }
        if (isGrab == true)
        {
            gravity = 0;
            velocity = 0;
        }
        if( isGrab == false)
        {
            gravity = -9.81f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            isGrab = true;
        }
        else
        {
            isGrab = false;
        }
    }

}
