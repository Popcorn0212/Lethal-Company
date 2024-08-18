using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public bool isGrab = false;
    public Transform PlayerHead;
    Vector3 objectARotation;

    public int scrapValue = 100;

    Transform parent;
    Transform child;
    Transform grandchild;

    public float currentTime;

    public bool isScaned;

    void Start()
    {
        //PlayerHead = transform.Find("Head");

        // 부모 오브젝트의 Transform을 참조합니다.
        parent = transform;

        // 첫 번째 자식 오브젝트를 참조합니다 (인덱스 0)
        child = parent.GetChild(0);

        // 그 자식 오브젝트의 첫 번째 자식 오브젝트를 찾습니다
        grandchild = child.GetChild(0);

        grandchild.gameObject.SetActive(false);
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        objectARotation = PlayerHead.eulerAngles;
        if (isGrab)
        {
            transform.eulerAngles = new Vector3(objectARotation.x, objectARotation.y, objectARotation.z);
            isScaned = false;
        }

        if (isScaned)
        {
            currentTime = 0;
            grandchild.gameObject.SetActive(true); 
        }
        if (isScaned == false && currentTime > 5)
        {
            grandchild.gameObject.SetActive(false);
        }
        if (isScaned == false && isGrab) 
        {
            grandchild.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            isGrab = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            isGrab = false;
            transform.eulerAngles = new Vector3(0, objectARotation.y, objectARotation.z);

        }
    }
}
