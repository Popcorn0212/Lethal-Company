using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FontColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Text text_font;  // 변경할 텍스트 가져오기
    private FontStyle originalFontStyle;  // 원래 폰트 스타일 저장
    private Color originalColor;  // 원래 폰트 색상 저장
    private bool isClicked = false;  // 마우스 클릭 여부
    private static FontColor currentlySelected;  // 마우스 클릭 대상 확인

    void Start()
    {
        if (text_font == null)
        {
            text_font = GetComponent<Text>();  // 텍스트 컴포넌트 가져오기
        }
        originalFontStyle = text_font.fontStyle;  // 원래 폰트 스타일 지정
        originalColor = new Color(255f / 255f, 111f / 255f, 47f / 255f, 255f / 255f); // 초기 색상 설정
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentlySelected != null)
        {
            // 클릭한 오브젝트가 UI 오브젝트인지 확인
            if (EventSystem.current.currentSelectedGameObject == null ||
                EventSystem.current.currentSelectedGameObject != currentlySelected.gameObject)
            {
                currentlySelected.ResetSelection();  // 선택 대상 초기화
                currentlySelected = null;  // //
            }
        }
    }

    // 마우스 포인터가 버튼 범위에 들어왔을 경우
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isClicked)
        {
            text_font.color = Color.black;  // 폰트 색을 검정색으로 변경
            text_font.fontStyle = FontStyle.Bold;  // 폰트 스타일을 볼드체로 변경
        }
    }

    // 마우스 포인터가 버튼 범위에서 벗어났을 경우
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicked)
        {
            text_font.color = originalColor;  // 폰트를 원래 색으로 변경
            text_font.fontStyle = originalFontStyle;  // 폰트 스타일을 기본으로 변경
        }
    }

    // 마우스 클릭을 했을 경우
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.ResetSelection();
        }

        isClicked = true;  // 클릭 여부를 true 로
        currentlySelected = this;  // 선택한 대상을 자신으로
        text_font.color = Color.black;  // 폰트 색을 검정색으로 유지
        text_font.fontStyle = FontStyle.Bold;  // 폰트 스타일을 볼드체로 유지
    }

    // 선택한 대상 초기화
    private void ResetSelection()
    {
        isClicked = false;  // 클릭 여부를 false 로
        text_font.color = originalColor;  // 폰트 색을 원래 색으로 변경
        text_font.fontStyle = originalFontStyle;  // 폰트 스타일을 기본으로 변경
    }
}
