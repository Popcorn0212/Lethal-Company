using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScrapValue : MonoBehaviour
{
    public static CountScrapValue csv;
    int valueCount = 0;
    public Text text_valueCounter;


    void Awake()
    {
        // 싱글턴 패턴 구현
        if (csv == null)
        {
            csv = this;
        }
        else if (csv != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        valueCount = 0;
        UpdateText();
    }

    public void ValueCount(int value)
    {
        valueCount += value;
        UpdateText();
    }

    void UpdateText()
    {
        text_valueCounter.text = valueCount.ToString();
    }
}
