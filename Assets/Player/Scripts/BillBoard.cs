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
            // 나의 정면 방향을 메인 카메라가 나를 바라보는 방향과 일치시킨다.
            transform.forward = (Camera.main.transform.position - transform.position).normalized * -1;
        }
    }
}
