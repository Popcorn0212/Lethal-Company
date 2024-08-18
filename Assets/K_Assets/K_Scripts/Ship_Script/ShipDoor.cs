using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDoor : MonoBehaviour
{
    AudioSource doorSound;

    [Header("�÷��̾� ���ӿ�����Ʈ")]
    public Transform player;

    //�÷��̾�� �� ���� �Ÿ� ���
    [Header("�÷��̾� ��ȣ�ۿ� ���� �Ÿ�")]
    [Range(1.0f, 6.0f)]
    public float interactionDistance = 2.0f; //��ȣ�ۿ� ������ �Ÿ�
    public bool showGizmoSphare;
    public bool showGizmoLine;

    [Header("�� ���� ��ư")]
    public GameObject button;

    [Header("��-������ġ-������ġ")]
    public GameObject leftDoor;
    public Transform leftClose;
    public Transform leftOpen;
    public GameObject rightDoor;
    public Transform rightClose;
    public Transform rightOpen;

    [Header("�� �������� �ӵ�")]
    [Range(3.0f, 25.0f)]
    public float moneSpd = 8;
    //�� �������� ���� ������ �ֱ�
    float delayTime = 0f;

    public bool isDoorOpen;

    [Header("�� ���� UI")]
    public GameObject openUI;

    void Start()
    {
        openUI.SetActive(false);
        doorSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDoorOpen)
        {
            //Invoke("Open", 0);//��������¡?
            Open();
        }
        else
        {
            //Invoke("Close", 0);
            Close();
        }


        //���� �÷��̾��� �Ÿ��� ���.
        float distanceToPlayer = Vector3.Distance(button.transform.position, player.position);

        if (distanceToPlayer > interactionDistance)
        {
            openUI.SetActive(false);
            return;
        }
        else
        {
            openUI.SetActive(true);
            delayTime -= Time.deltaTime;
            if (delayTime < 0 && Input.GetKey(KeyCode.E)) //�� �տ��� eŰ�� ������ ���� ����.
            {
                doorSound.Play();

                #region ���������� ������ġ�ִ� �ڵ�
                //�̷��� �ϴϱ� ���� ������ ���� ������ ĳ�ű��ϴ�
                //Ȥ�ø𸣴� ����
                //if (!isDoorOpen)
                //{
                //    Open();
                //    //���� ���

                //}
                //else if (isDoorOpen)
                //{
                //    Close();
                //    //���� ���
                //}
                #endregion

                if (!isDoorOpen)
                {
                    isDoorOpen = true;
                    delayTime = 1.0f;
                }
                else
                {
                    isDoorOpen = false;
                    delayTime = 1.0f;
                }

            }
        }

    }


    void Close()
    {
        leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftClose.position, moneSpd * Time.deltaTime);
        rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightClose.position, moneSpd * Time.deltaTime);
        leftDoor.GetComponentInParent<BoxCollider>().enabled = true;
        rightDoor.GetComponentInParent<BoxCollider>().enabled = true;
    }

    void Open()
    {
        leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftOpen.position, moneSpd * Time.deltaTime);
        rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightOpen.position, moneSpd * Time.deltaTime);
        leftDoor.GetComponentInParent<BoxCollider>().enabled = false;
        rightDoor.GetComponentInParent<BoxCollider>().enabled = false;
    }

    #region ������ �Ÿ� �׸���
    private void OnDrawGizmos()
    {
        // Gizmos ���� ����
        Gizmos.color = Color.green;

        if (showGizmoLine)
        {
            Gizmos.color = Color.yellow;
            // ���� �÷��̾� ������ �� �׸���
            Gizmos.DrawLine(button.transform.position, player.position);
        }

        if (showGizmoSphare)
        {
            Gizmos.color = Color.green;
            // ��ȣ�ۿ� ������ �Ÿ� ǥ��
            Gizmos.DrawWireSphere(button.transform.position, interactionDistance);
        }
    }
    #endregion


}
