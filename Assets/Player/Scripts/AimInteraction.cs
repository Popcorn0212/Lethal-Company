using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimInteraction : MonoBehaviour
{
    public bool isInteraction = false;
    public bool isHold = false;
    public bool useLadder = false;
    public bool targetIsLadder = false;
    public int nowInvenSlot = 1;
    Scrap scrap;

    public Transform hand;
    public Transform dropPoint;
    public Transform inventory;

    public GameObject player;
    public GameObject targetScrap;

    public GameObject text_pickUp;

    public List<GameObject> inventorySlot;

    void Start()
    {
        nowInvenSlot = 1;
        player = GameObject.Find("Player");
        useLadder = false;
    }

    void Update()
    {
        PickUpDown();
        InventorySwap();
        Ladder();
    }

    private void OnTriggerEnter(Collider other)
    {
        isInteraction = true;
        if (other.tag == "Scrap")
        {
            targetScrap = other.gameObject;
            targetScrap.GetComponent<Scrap>();
        }
        else
        {
            targetScrap = null;
        }

        if (other.tag == "Ladder")
        {
            targetIsLadder = true;
        }
        else
        {
            targetIsLadder= false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isInteraction = false;
        targetScrap=null;
    }

    void PickUpDown()
    {
        if (targetScrap != null)
        {
            scrap = targetScrap.GetComponent<Scrap>();
        }
        // 만약 오브젝트와 상호작용 중이라면 GameObject targetScarp에 상호작용중인 게임 오브젝트 넣기 

        if (isInteraction && Input.GetKeyDown(KeyCode.E))
        {

            for (int i = 0; i < inventorySlot.Count; i++)
            {
                if (inventorySlot[i] == null)
                {
                    inventorySlot[i] = targetScrap;
                    if (inventorySlot[i] != null)
                    {
                        nowInvenSlot = i;
                        break;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (nowInvenSlot == 1 && inventorySlot[1] != null)
            {
                scrap = inventorySlot[1].gameObject.GetComponent<Scrap>();
                inventorySlot[1].gameObject.transform.position = dropPoint.transform.position;
                inventorySlot[1] = null;
            }
            if (nowInvenSlot == 2 && inventorySlot[2] != null)
            {
                scrap = inventorySlot[2].gameObject.GetComponent<Scrap>();
                inventorySlot[2].gameObject.transform.position = dropPoint.transform.position;
                inventorySlot[2] = null;
            }
            if (nowInvenSlot == 3 && inventorySlot[3] != null)
            {
                scrap = inventorySlot[3].gameObject.GetComponent<Scrap>();
                inventorySlot[3].gameObject.transform.position = dropPoint.transform.position;
                inventorySlot[3] = null;
            }
            if (nowInvenSlot == 4 && inventorySlot[4] != null)
            {
                scrap = inventorySlot[4].gameObject.GetComponent<Scrap>();
                inventorySlot[4].gameObject.transform.position = dropPoint.transform.position;
                inventorySlot[4] = null;
            }
        }
    
    }

    void InventorySwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowInvenSlot = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowInvenSlot = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nowInvenSlot = 3;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            nowInvenSlot = 4;

        }

        if (nowInvenSlot == 1)
        {
            if (inventorySlot[1] != null)
            {
                inventorySlot[1].gameObject.transform.position = hand.transform.position;
            }
            if (inventorySlot[2] != null)
            {
                inventorySlot[2].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[3] != null)
            {
                inventorySlot[3].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[4] != null)
            {
                inventorySlot[4].gameObject.transform.position = inventory.transform.position;
            }
        }
        if (nowInvenSlot == 2)
        {
            if (inventorySlot[2] != null)
            {
                inventorySlot[2].gameObject.transform.position = hand.transform.position;
            }
            if (inventorySlot[1] != null)
            {
                inventorySlot[1].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[3] != null)
            {
                inventorySlot[3].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[4] != null)
            {
                inventorySlot[4].gameObject.transform.position = inventory.transform.position;
            }
        }
        if (nowInvenSlot == 3)
        {
            if (inventorySlot[3] != null)
            {
                inventorySlot[3].gameObject.transform.position = hand.transform.position;
            }
            if (inventorySlot[2] != null)
            {
                inventorySlot[2].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[1] != null)
            {
                inventorySlot[1].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[4] != null)
            {
                inventorySlot[4].gameObject.transform.position = inventory.transform.position;
            }
        }
        if (nowInvenSlot == 4)
        {
            if (inventorySlot[4] != null)
            {
                inventorySlot[4].gameObject.transform.position = hand.transform.position;
            }
            if (inventorySlot[2] != null)
            {
                inventorySlot[2].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[3] != null)
            {
                inventorySlot[3].gameObject.transform.position = inventory.transform.position;
            }
            if (inventorySlot[1] != null)
            {
                inventorySlot[1].gameObject.transform.position = inventory.transform.position;
            }
        }

    }

    void Ladder()
    {
        if (targetIsLadder == true && Input.GetKeyDown(KeyCode.E))
        {
            useLadder = true;
        }

        if (useLadder == true && Input.GetKeyDown(KeyCode.E))
        {
            useLadder = false;
        }
    }
}
