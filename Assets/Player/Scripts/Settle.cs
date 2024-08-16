using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Settle : MonoBehaviour
{
    Scrap Scrap;
    public int totalValue;
    public TMP_Text Value;

    void Start()
    {
        
    }


    void Update()
    {
        Value.text = totalValue.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scrap")
        {
            Scrap = other.GetComponent<Scrap>();
            totalValue += Scrap.scrapValue;
        }
    }
}
