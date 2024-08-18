using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintCam : MonoBehaviour
{
    public float shakeAmount = 0.1f; // 흔들림의 강도
    public float shakeFrequency = 5f; // 흔들림의 빈도
    private Vector3 originalLocalPosition; // 부모 오브젝트에 상대적인 카메라의 원래 위치
    private float shakeTimer;
    private Transform parentTransform; // 부모 오브젝트의 Transform

    public float shakeAmount2 = 0.1f; // 흔들림의 강도
    public float shakeFrequency2 = 5f; // 흔들림의 빈도
    private float shakeTimer2 = 0f; // 흔들림 타이머
    public bool shouldShake; // 흔들림 활성화 여부

    void Start()
    {
        // 카메라의 원래 위치를 부모 오브젝트에 상대적인 위치로 저장
        parentTransform = transform.parent;
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Shift 키가 눌려 있을 때 흔들림 타이머 증가
            shakeTimer += Time.deltaTime * shakeFrequency;

            // 흔들림 효과 적용
            float shakeOffset = Mathf.Sin(shakeTimer) * shakeAmount;
            // 부모 오브젝트에 상대적인 위치를 기준으로 흔들림 적용
            transform.localPosition = originalLocalPosition + new Vector3(0f, shakeOffset, 0f);
        }
        else
        {
            // Shift 키가 눌려 있지 않을 때 원래 위치로 복원
            transform.localPosition = originalLocalPosition;
            shakeTimer = 0f; // 흔들림 타이머 초기화
        }

        if (shouldShake)
        {
            // 흔들림 타이머 증가
            shakeTimer2 += Time.deltaTime * shakeFrequency2;

            // 흔들림 효과 적용
            float shakeOffset = Mathf.Sin(shakeTimer2) * shakeAmount2;
            transform.localPosition = originalLocalPosition + new Vector3(0f, shakeOffset, 0f);

            // 흔들림이 일정 시간 후 끝나도록 설정 (예: 0.2초)
            if (shakeTimer2 >= 5f)
            {
                transform.localPosition = originalLocalPosition;
                shouldShake = false;
                shakeTimer2 = 0f;
            }
        }
    }
    public void TriggerShake()
    {
        print(1);
        shouldShake = true;
        shakeTimer2 = 0;
    }
}
