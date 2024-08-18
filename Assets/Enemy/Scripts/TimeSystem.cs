using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    public Text text_timer;  // 타이머를 출력할 텍스트 지정
    public Text text_dayTime;  // 오전/오후 를 출력할 텍스트 지정
    public List<Image> img_timeIcons = new List<Image>();  // 시간대 별로 표시 아이콘들을 지정
    public GameObject img_dead;  // 사망 화면 저장
    public GameObject dog;

    float min;  // 분
    int hour = 8;  // 시


    void Start()
    {
        // 변수 초기화
        min = 0;
        hour = 8;
        text_dayTime.text = "오전";
        dog.gameObject.SetActive(false);
        img_timeIcons[0].gameObject.SetActive(true);
        img_timeIcons[1].gameObject.SetActive(false);
        img_timeIcons[2].gameObject.SetActive(false);
    }

    void Update()
    {
        Timer();  // 타이머 함수 실행
    }

    // 시간을 흐르게 하고 텍스트로 출력하는 함수
    void Timer()
    {
        min += Time.deltaTime;  // "분"을 매초마다 갱신

        text_timer.text = string.Format("{0:D2}:{1:D2}", hour, (int)min * 4);  // 텍스트로 현재 "시:분" 을 출력, "분"을 매초마다 4씩 오르게

        // 현재 "분"이 15(4 * 15 = 60)이상일 경우 "시"를 갱신하고, "분"은 0 으로 초기화
        if((int)min >= 15)
        {
            min = 0;
            hour++;
        }

        // 현재 "시"가 12 를 넘을 경우
        if(hour >= 12 && (int)min > 0)
        {
            hour = 1;  // 1로 변경
            text_dayTime.text = "오후";  // 타이머 텍스트를 "오후"로 변경
            img_timeIcons[0].gameObject.SetActive(false);  // 오전 시간 아이콘을 비활성화
            img_timeIcons[1].gameObject.SetActive(true);  // 오후 시간 이이콘을 활성화
        }

        // 현재 "시"가 5 를 넘을 경우
        if(hour == 5)
        {
            img_timeIcons[1].gameObject.SetActive(false);  // 오후 시간 아이콘 비활성화
            img_timeIcons[2].gameObject.SetActive(true);  // 밤 시간 아이콘 활성화
        }

        // 현재 "시"가 7 을 넘을 경우
        if(hour == 6)
        {
            //img_dead.gameObject.SetActive(true);  // 사망 화면 활성화
            dog.gameObject.SetActive(true);
        }
    }
}
