using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZone : MonoBehaviour
{
    ScrapValue sv;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scrap"))
        {
            sv = other.GetComponent<ScrapValue>();
            if (sv != null)
            {
                CountScrapValue.csv.ValueCount(sv.value);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Scrap"))
        {
            sv = other.GetComponent<ScrapValue>();
            if (sv != null)
            {
                CountScrapValue.csv.ValueCount(-sv.value);
            }
        }
    }
}
