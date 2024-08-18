using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI: MonoBehaviour
{

    public float maxStamina = 100.0f;
    public float currentStamina;

    public Slider Slider;

    PlayerMove PlayerMove;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerMove = player.GetComponent<PlayerMove>();
        }
    }


    void Update()
    {
        if (Slider != null)
        {
            UpdateStaminaUI();
        }
 
    }

    void UpdateStaminaUI()
    {
        maxStamina = PlayerMove.maxStamina;
        currentStamina = PlayerMove.currentStamina;

        Slider.value = currentStamina;
    }
}
