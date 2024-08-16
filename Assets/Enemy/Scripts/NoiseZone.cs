using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseZone : MonoBehaviour
{
    public GameObject walkNoise;
    public GameObject runNoise;


    void Start()
    {
        walkNoise.gameObject.SetActive(false);
        runNoise.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical") && !Input.GetKey(KeyCode.LeftControl))
        {
            walkNoise.gameObject.SetActive(true);
        }
        else
        {
            walkNoise.gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            runNoise.gameObject.SetActive(true);
        }
        else
        {
            runNoise.gameObject.SetActive(false);
        }
    }
}
