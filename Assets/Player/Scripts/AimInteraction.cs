using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInteraction : MonoBehaviour
{
    public bool isInteraction = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        isInteraction = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInteraction = false;
    }
}
