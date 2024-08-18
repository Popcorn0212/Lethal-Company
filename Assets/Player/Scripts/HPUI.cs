using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Image hpImage;

    public int currentHP = 3;
    public GameObject img_dead;

    PlayerMove PlayerMove;
    GameObject player;

    void Start()
    {
        img_dead.gameObject.SetActive(false);

        player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerMove = player.GetComponent<PlayerMove>();
        }
    }


    void Update()
    {
        if (hpImage != null)
        {
            UpdateHealthUI();
        }
    }
    void UpdateHealthUI()
    {
        currentHP = PlayerMove.hp;

        if (currentHP == 3)
        {
            hpImage.color = Color.white;
        }
        if (currentHP == 2)
        {
            hpImage.color = Color.yellow;
        }
        if (currentHP == 1)
        {
            hpImage.color = Color.red;
        }
        if (currentHP == 0)
        {
            hpImage.color = Color.red;
            img_dead.gameObject.SetActive(true);
        }
    }
}
