using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public float rotSpeed = 200.0f;

    // 회전 값을 미리 계산하기 위한 회전축(x, y) 변수
    float rotX;
    float rotY;
        void Start()
    {
        // 최초의 회전 상태로 시작을 하고싶다.
        rotX = transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;

    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 각 축 별로 회전 값을 미리 계산한다.
        rotX += mouseY * rotSpeed * Time.deltaTime;
        rotY += mouseX * rotSpeed * Time.deltaTime;

        // 상하 회전은 -60도 ~ +60도까지로 제한한다.
        if (rotX > 60.0f)
        {
            rotX = 60.0f;
        }
        else if (rotX < -60.0f)
        {
            rotX = -60.0f;
        }

        // 계산된 회전 값을 나의 transform 회전 값으로 적용한다.
        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
        Camera.main.transform.GetComponent<FollowCamera>().rotX = rotX;
    }
}
