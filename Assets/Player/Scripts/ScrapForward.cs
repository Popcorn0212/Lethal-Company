using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapForward : MonoBehaviour
{
    public Transform PlayerHead;
    Scrap Scrap;
    Transform Child;

    void Start()
    {
        Child = transform.GetChild(0);
        Scrap = Child.GetComponent<Scrap>();
    }


    void Update()
    {
        //Vector3 objectARotation = PlayerHead.eulerAngles;

        //if (Scrap.isGrab == true)
        //{
            

        //}
        //else
        //{
        //    transform.eulerAngles = new Vector3(0, objectARotation.y, objectARotation.z);
        //}
    }
}
