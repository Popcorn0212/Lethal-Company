using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settle : MonoBehaviour
{
    Scrap Scrap;
    public int totalValue;
    public Text Value;

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
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scrap")
        {
            Scrap = other.GetComponent<Scrap>();
            totalValue -= Scrap.scrapValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scrap")
        {
            Scrap = other.GetComponent<Scrap>();
            totalValue -= Scrap.scrapValue;
        }
    }
}
