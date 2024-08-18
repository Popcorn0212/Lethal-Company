using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public Transform upPos;
    public Transform downPos;
    public GameObject fire;
    public GameObject smoke;
    float currentTime = 0;
    public bool isStart = false;

    private void Update()
    {
        if(isStart)
        {
            ShipLeave();
        }
    }

    public void ShipLeave()
    {
        currentTime += Time.deltaTime;

        fire.gameObject.SetActive(true);
        smoke.gameObject.SetActive(true);

        transform.position = Vector3.Lerp(transform.position, upPos.transform.position, 0.003f);

        if (currentTime > 2)
        {
            currentTime = 0;
            smoke.gameObject.SetActive(false);
        }
    }

    public void ShipAlive()
    {
        currentTime += Time.deltaTime;

        fire.gameObject.SetActive(true);
        smoke.gameObject.SetActive(false);

        transform.position = Vector3.Lerp(transform.position, downPos.transform.position, 0.003f);

        if (currentTime > 1.5f)
        {
            currentTime = 0;
            smoke.gameObject.SetActive(true);
        }
    }
}
