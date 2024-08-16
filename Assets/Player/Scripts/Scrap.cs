using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public bool isGrab = false;
    public Transform PlayerHead;
    Vector3 objectARotation;

    public int scrapValue = 100;

    void Start()
    {
    
    }


    void Update()
    {
        objectARotation = PlayerHead.eulerAngles;
        if (isGrab)
        {
            transform.eulerAngles = new Vector3(objectARotation.x, objectARotation.y, objectARotation.z);

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
