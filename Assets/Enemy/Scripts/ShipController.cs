using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Transform upPos;
    public Transform downPos;


    void Start()
    {

    }

    void Update()
    {

    }

    public void ShipLeave()
    {

        transform.position = Vector3.Lerp(transform.position, upPos.transform.position, 0.003f);
    }

    public void ShipAlive()
    {

        transform.position = Vector3.Lerp(transform.position, downPos.transform.position, 0.003f);
    }
}
