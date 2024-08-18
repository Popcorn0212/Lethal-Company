using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Image hpImage;

    public int currentHP = 3;
    public GameObject img_dead;
    public GameObject img_hit;
    public GameObject shipCam;
    public GameObject shipControl;
    public GameObject playerObj;
    public GameObject playerHead;
    AudioSource hitSound;

    float currentTime = 0;
    bool isTimer = false;

    PlayerMove PlayerMove;
    GameObject player;
    ShipController sc;

    void Start()
    {
        img_dead.gameObject.SetActive(false);
        player = GameObject.Find("Player");
        sc = shipControl.GetComponent<ShipController>();
        hitSound = playerHead.GetComponent<AudioSource>();
        currentTime = 0;

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

        if(isTimer)
        {
            currentTime += Time.deltaTime;
        }
    }

    void UpdateHealthUI()
    {
        currentHP = PlayerMove.hp;

        if (currentHP == 3)
        {
            hitSound.Play();
            hpImage.color = Color.white;
        }
        if (currentHP == 2)
        {
            hitSound.Play();
            hpImage.color = Color.yellow;
        }
        if (currentHP == 1)
        {
            hitSound.Play();
            hpImage.color = Color.red;
        }
        if (currentHP == 0)
        {
            hitSound.Play();
            hpImage.color = Color.red;
            playerObj.gameObject.SetActive(false);
            isTimer = true;

            img_dead.gameObject.SetActive(true);

            if(currentTime >= 2.5f)
            {
                Cursor.lockState = CursorLockMode.None;
                img_hit.gameObject.SetActive(false);
                shipCam.gameObject.SetActive(true);
                sc.isStart = true;
                currentTime = 0;
            }
        }
    }
}
