using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintCam : MonoBehaviour
{
    public float shakeAmount = 0.1f; // ��鸲�� ����
    public float shakeFrequency = 5f; // ��鸲�� ��
    private Vector3 originalLocalPosition; // �θ� ������Ʈ�� ������� ī�޶��� ���� ��ġ
    private float shakeTimer;
    private Transform parentTransform; // �θ� ������Ʈ�� Transform

    public float shakeAmount2 = 0.1f; // ��鸲�� ����
    public float shakeFrequency2 = 5f; // ��鸲�� ��
    private float shakeTimer2 = 0f; // ��鸲 Ÿ�̸�
    public bool shouldShake; // ��鸲 Ȱ��ȭ ����

    void Start()
    {
        // ī�޶��� ���� ��ġ�� �θ� ������Ʈ�� ������� ��ġ�� ����
        parentTransform = transform.parent;
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Shift Ű�� ���� ���� �� ��鸲 Ÿ�̸� ����
            shakeTimer += Time.deltaTime * shakeFrequency;

            // ��鸲 ȿ�� ����
            float shakeOffset = Mathf.Sin(shakeTimer) * shakeAmount;
            // �θ� ������Ʈ�� ������� ��ġ�� �������� ��鸲 ����
            transform.localPosition = originalLocalPosition + new Vector3(0f, shakeOffset, 0f);
        }
        else
        {
            // Shift Ű�� ���� ���� ���� �� ���� ��ġ�� ����
            transform.localPosition = originalLocalPosition;
            shakeTimer = 0f; // ��鸲 Ÿ�̸� �ʱ�ȭ
        }

        if (shouldShake)
        {
            // ��鸲 Ÿ�̸� ����
            shakeTimer2 += Time.deltaTime * shakeFrequency2;

            // ��鸲 ȿ�� ����
            float shakeOffset = Mathf.Sin(shakeTimer2) * shakeAmount2;
            transform.localPosition = originalLocalPosition + new Vector3(0f, shakeOffset, 0f);

            // ��鸲�� ���� �ð� �� �������� ���� (��: 0.2��)
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
