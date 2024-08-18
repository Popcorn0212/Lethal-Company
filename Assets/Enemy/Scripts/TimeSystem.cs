using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    public Text text_timer;  // Ÿ�̸Ӹ� ����� �ؽ�Ʈ ����
    public Text text_dayTime;  // ����/���� �� ����� �ؽ�Ʈ ����
    public List<Image> img_timeIcons = new List<Image>();  // �ð��� ���� ǥ�� �����ܵ��� ����
    public GameObject img_dead;  // ��� ȭ�� ����
    public GameObject dog;

    float min;  // ��
    int hour = 8;  // ��


    void Start()
    {
        // ���� �ʱ�ȭ
        min = 0;
        hour = 8;
        text_dayTime.text = "����";
        dog.gameObject.SetActive(false);
        img_timeIcons[0].gameObject.SetActive(true);
        img_timeIcons[1].gameObject.SetActive(false);
        img_timeIcons[2].gameObject.SetActive(false);
    }

    void Update()
    {
        Timer();  // Ÿ�̸� �Լ� ����
    }

    // �ð��� �帣�� �ϰ� �ؽ�Ʈ�� ����ϴ� �Լ�
    void Timer()
    {
        min += Time.deltaTime;  // "��"�� ���ʸ��� ����

        text_timer.text = string.Format("{0:D2}:{1:D2}", hour, (int)min * 4);  // �ؽ�Ʈ�� ���� "��:��" �� ���, "��"�� ���ʸ��� 4�� ������

        // ���� "��"�� 15(4 * 15 = 60)�̻��� ��� "��"�� �����ϰ�, "��"�� 0 ���� �ʱ�ȭ
        if((int)min >= 15)
        {
            min = 0;
            hour++;
        }

        // ���� "��"�� 12 �� ���� ���
        if(hour >= 12 && (int)min > 0)
        {
            hour = 1;  // 1�� ����
            text_dayTime.text = "����";  // Ÿ�̸� �ؽ�Ʈ�� "����"�� ����
            img_timeIcons[0].gameObject.SetActive(false);  // ���� �ð� �������� ��Ȱ��ȭ
            img_timeIcons[1].gameObject.SetActive(true);  // ���� �ð� �������� Ȱ��ȭ
        }

        // ���� "��"�� 5 �� ���� ���
        if(hour == 5)
        {
            img_timeIcons[1].gameObject.SetActive(false);  // ���� �ð� ������ ��Ȱ��ȭ
            img_timeIcons[2].gameObject.SetActive(true);  // �� �ð� ������ Ȱ��ȭ
        }

        // ���� "��"�� 7 �� ���� ���
        if(hour == 6)
        {
            //img_dead.gameObject.SetActive(true);  // ��� ȭ�� Ȱ��ȭ
            dog.gameObject.SetActive(true);
        }
    }
}
