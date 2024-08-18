using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
    public GameObject img_escape;

    private void OnTriggerEnter(Collider other)
    {
        img_escape.gameObject.SetActive(true);
    }
}
