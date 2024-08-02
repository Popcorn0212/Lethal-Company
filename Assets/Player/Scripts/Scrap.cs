using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public float gravity = -9.81f; // 중력의 세기
    public float initialVelocity = 0f; // 초기 속도
    public float timeStep = 0.02f; // 시간 간격

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
        // 시간 간격 업데이트
        time += Time.deltaTime;

        // 속도와 위치 업데이트
        velocity += gravity * Time.deltaTime;
        transform.position += new Vector3(0, velocity * Time.deltaTime, 0);

        // 바닥에 닿았을 때 위치를 조정하고 속도를 0으로 설정
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
