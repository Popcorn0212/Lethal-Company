using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera cam;
    Vector3 camOriginPos;

    public bool letsShake;

    void Start()
    {
        cam = Camera.main;
        camOriginPos = cam.transform.position;
    }

    void Update()
    {
        if (letsShake)
        {
            StartCoroutine(CamShake(0.6f, 0.3f));

        }
    }

    IEnumerator CamShake(float duration, float magnitude) //ī�޶� ��鸮�� �ϴ� �ڷ�ƾ, float �۵��ð�, float �۵�����
    {
        float timer = 0;

        while (timer <= duration)
        {
            gameObject.transform.position = Random.insideUnitSphere * magnitude + camOriginPos;
            timer += Time.deltaTime; //�ð� �帣��
            yield return null;
        }

        gameObject.transform.position = camOriginPos; //ī�޶� ����ġ
        letsShake = false; //�׸� ���������� (�� ���� ����)
    }

}
