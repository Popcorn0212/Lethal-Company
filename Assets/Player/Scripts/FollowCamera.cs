using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 타겟으로 지정된 위치로 나를 이동시킨다.
    public float rotX;
    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {


        if (player != null)
        {

            // 카메라의 위치를 타겟 트랜스폼의 위치로 지정한다.
            //if (!dynamicCam)
            //{
            //    transform.position = target.position;
            //}
            //else
            //{
            //    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);
            //}

            // 카메라의 정면 방향을 플레이어의 정면 방향으로 설정한다.
            //Vector3 dir = (player.position - transform.position).normalized;
            transform.forward = player.forward;

            // 사용자의 마우스 상하 회전 값을 x축 회전으로 넣는다.
            transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
