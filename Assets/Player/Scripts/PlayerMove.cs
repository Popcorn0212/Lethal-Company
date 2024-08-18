using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float climbSpeed = 3f; // 사다리를 오르는 속도
    public LayerMask ladderMask; // 사다리 레이어
    public Transform orientation; // 카메라나 플레이어의 방향을 조정하기 위한 변수

    private bool isClimbing = false; // 현재 클라이밍 상태
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

        // 최초의 회전 상태로 시작을 하고싶다.
        rotY = transform.eulerAngles.y;

        // 캐릭터 컨트롤러 컴포넌트를 변수에 담아놓는다.
        cc = GetComponent<CharacterController>();

        // 중력 값을 초기화한다.
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
            Vector3 climbDirection = orientation.up * verticalInput; // 오르는 방향
            characterController.Move(climbDirection * climbSpeed * Time.deltaTime);
        }

        currentTime += Time.deltaTime;
    }

    void Move()
    {
        // 1. 수평 이동 계산
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 나의 정면 방향에 따라서 이동하도록 변경한다.

        // 1-1. 로컬 방향 벡터를 이용해서 계산하는 방법
        //Vector3 dir = transform.forward * v + transform.right * h;
        //dir.Normalize();

        // 1-2. 나의 회전 값에 따라서 월드 방향 벡터를 로컬 방향의 벡터로 변환하는 함수를 이용하는 방법
        Vector3 dir = new Vector3(h, 0, v); // 월드 방향 벡터
        dir = transform.TransformDirection(dir);
        dir.Normalize();

        // 2. 수직 이동 계산

        // 중력 적용
        yPos += gravityPower.y * yVelocity * Time.deltaTime;


        // 바닥에 닿아있을 때에는 yPos의 값을 0으로 초기화한다.
        if (cc.collisionFlags == CollisionFlags.CollidedBelow)
        {
            yPos = 0;
            maxJumpCount = jumpCount;
        }

        // 키보드의 스페이스바를 누르면 위쪽으로 점프를 하게 하고 싶다.
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

        // 키보드의 왼쪽 쉬프트를 누르고 있으면 플레이어의 이동속도를 높히고 싶다.
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
            currentStamina -= 300;  // 스태미나에 -n을 더함
            staminaOring = true;  // 수정했음을 기록
        }

        // 스태미나가 0보다 크면 staminaOring을 다시 false로 설정
        if (currentStamina > 0)
        {
            staminaOring = false;
        }

    }

    void Rotate()
    {
        float mouseX = 0;
        mouseX = Input.GetAxis("Mouse X");

        // 각 축 별로 회전 값을 미리 계산한다.
        rotY += mouseX * rotSpeed * Time.deltaTime;

        // 계산된 회전 값을 나의 transform 회전 값으로 적용한다.
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
            characterController.slopeLimit = 90f; // 사다리에서 경사 제한 해제
            characterController.stepOffset = 0f; // 발걸음 높이 제거
            yVelocity = 0;
            moveSpeed = 5;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (IsLadder(other))
        {
            isClimbing = false;
            characterController.slopeLimit = 45f; // 기본 경사 제한으로 복원
            characterController.stepOffset = 0.3f; // 기본 발걸음 높이로 복원
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
        // HP 감소
        hp -= damage;
        SprintCam.TriggerShake();

    }
}
