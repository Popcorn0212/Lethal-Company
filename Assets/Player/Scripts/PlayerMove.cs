using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float climbSpeed = 3f; // ��ٸ��� ������ �ӵ�
    public LayerMask ladderMask; // ��ٸ� ���̾�
    public Transform orientation; // ī�޶� �÷��̾��� ������ �����ϱ� ���� ����

    private bool isClimbing = false; // ���� Ŭ���̹� ����
    private CharacterController characterController;

    public float moveSpeed = 7.0f;
    public float rotSpeed = 200.0f;
    public float yVelocity = 100.0f;
    public float jumpPower = 20.0f;
    public float maxStamina = 100;
    public float currentStamina;
    public float currentTime;
    public float hitDelay = 1.5f;
    public bool staminaOring = false;
    public bool isSprint = false;
    public int hp = 4;
    public int maxJumpCount = 2;
    int jumpCount;

    float rotX;
    public float rotY;
    float yPos;

    CharacterController cc;

    SprintCam SprintCam;
    public GameObject sprintCam;

    Vector3 gravityPower;

    void Start()
    {
        sprintCam = GameObject.Find("Main Camera");

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        // ������ ȸ�� ���·� ������ �ϰ�ʹ�.
        rotY = transform.eulerAngles.y;

        // ĳ���� ��Ʈ�ѷ� ������Ʈ�� ������ ��Ƴ��´�.
        cc = GetComponent<CharacterController>();

        // �߷� ���� �ʱ�ȭ�Ѵ�.
        gravityPower = Physics.gravity;

        jumpCount = maxJumpCount;

        characterController = GetComponent<CharacterController>();

        SprintCam = sprintCam.GetComponent<SprintCam>();
    }

    void Update()
    {
        Move();
        Rotate();

        //transform.forward = head.forward;

        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 climbDirection = orientation.up * verticalInput; // ������ ����
            characterController.Move(climbDirection * climbSpeed * Time.deltaTime);
        }

        currentTime += Time.deltaTime;
    }

    void Move()
    {
        // 1. ���� �̵� ���
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ���� ���� ���⿡ ���� �̵��ϵ��� �����Ѵ�.

        // 1-1. ���� ���� ���͸� �̿��ؼ� ����ϴ� ���
        //Vector3 dir = transform.forward * v + transform.right * h;
        //dir.Normalize();

        // 1-2. ���� ȸ�� ���� ���� ���� ���� ���͸� ���� ������ ���ͷ� ��ȯ�ϴ� �Լ��� �̿��ϴ� ���
        Vector3 dir = new Vector3(h, 0, v); // ���� ���� ����
        dir = transform.TransformDirection(dir);
        dir.Normalize();

        // 2. ���� �̵� ���

        // �߷� ����
        yPos += gravityPower.y * yVelocity * Time.deltaTime;


        // �ٴڿ� ������� ������ yPos�� ���� 0���� �ʱ�ȭ�Ѵ�.
        if (cc.collisionFlags == CollisionFlags.CollidedBelow)
        {
            yPos = 0;
            maxJumpCount = jumpCount;
        }

        // Ű������ �����̽��ٸ� ������ �������� ������ �ϰ� �ϰ� �ʹ�.
        if (Input.GetButtonDown("Jump"))
        {
            maxJumpCount -= 1;
            if (maxJumpCount > -1)
            {
                yPos = jumpPower;
            }
        }

        dir.y = yPos;

        //transform.position += dir * moveSpeed * Time.deltaTime;
        cc.Move(dir * moveSpeed * Time.deltaTime);
        //cc.SimpleMove(dir * moveSpeed * Time.deltaTime);

        // Ű������ ���� ����Ʈ�� ������ ������ �÷��̾��� �̵��ӵ��� ������ �ʹ�.
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            isSprint = true;
        }
        else
        {
            isSprint = false;
        }

        if (isSprint == true)
        {
            moveSpeed = 10;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                currentStamina -= 0.1f;
            }
        }
        else
        {
            moveSpeed = 5;
            if (currentStamina < maxStamina)
            {
                currentStamina += 0.3f;
            }
        }


        if (currentStamina <= 0 && !staminaOring)
        {
            currentStamina -= 300;  // ���¹̳��� -n�� ����
            staminaOring = true;  // ���������� ���
        }

        // ���¹̳��� 0���� ũ�� staminaOring�� �ٽ� false�� ����
        if (currentStamina > 0)
        {
            staminaOring = false;
        }

    }

    void Rotate()
    {
        float mouseX = 0;
        mouseX = Input.GetAxis("Mouse X");

        // �� �� ���� ȸ�� ���� �̸� ����Ѵ�.
        rotY += mouseX * rotSpeed * Time.deltaTime;

        // ���� ȸ�� ���� ���� transform ȸ�� ������ �����Ѵ�.
        transform.eulerAngles = new Vector3(0, rotY, 0);
        HeadMove.rotY = rotY;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {

            if (currentTime > hitDelay)
            {
                //hp--;
                currentTime = 0;
                TakeDamage(1);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsLadder(other))
        {
            isClimbing = true;
            characterController.slopeLimit = 90f; // ��ٸ����� ��� ���� ����
            characterController.stepOffset = 0f; // �߰��� ���� ����
            yVelocity = 0;
            moveSpeed = 5;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (IsLadder(other))
        {
            isClimbing = false;
            characterController.slopeLimit = 45f; // �⺻ ��� �������� ����
            characterController.stepOffset = 0.3f; // �⺻ �߰��� ���̷� ����
            yVelocity = 0.8f;
            moveSpeed = 5;
        }
    }

    private bool IsLadder(Collider collider)
    {
        return ladderMask == (ladderMask | (1 << collider.gameObject.layer));
    }

    public void TakeDamage(int damage)
    {
        // HP ����
        hp -= damage;
        SprintCam.TriggerShake();

    }
}
