using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnOff : MonoBehaviour
{
    public GameObject flash;
    public GameObject light;
    bool isHand = false;
    bool isOn = false;

    void Start()
    {
        flash.gameObject.SetActive(false);
        light.gameObject.SetActive(false);
        isHand = false;
        isOn = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            isHand = false;
            flash.gameObject.SetActive(false);
        }
        if (!isHand)
        {
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                isHand = true;
                flash.gameObject.SetActive(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Alpha5))
            {
                isHand = false;
                flash.gameObject.SetActive(false);
            }
        }
        
        if (isHand && !isOn)
        {
            if (Input.GetButtonDown("R"))
            {
                isOn = true;
                light.gameObject.SetActive(true);
            }
        }
        else if(isHand && isOn)
        {
            if (Input.GetButtonDown("R"))
            {
                isOn = false;
                light.gameObject.SetActive(false);
            }
        }
    }
}
