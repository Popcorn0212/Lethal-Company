using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FontColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Text text_font;  // ������ �ؽ�Ʈ ��������
    private FontStyle originalFontStyle;  // ���� ��Ʈ ��Ÿ�� ����
    private Color originalColor;  // ���� ��Ʈ ���� ����
    private bool isClicked = false;  // ���콺 Ŭ�� ����
    private static FontColor currentlySelected;  // ���콺 Ŭ�� ��� Ȯ��

    void Start()
    {
        if (text_font == null)
        {
            text_font = GetComponent<Text>();  // �ؽ�Ʈ ������Ʈ ��������
        }
        originalFontStyle = text_font.fontStyle;  // ���� ��Ʈ ��Ÿ�� ����
        originalColor = new Color(255f / 255f, 111f / 255f, 47f / 255f, 255f / 255f); // �ʱ� ���� ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentlySelected != null)
        {
            // Ŭ���� ������Ʈ�� UI ������Ʈ���� Ȯ��
            if (EventSystem.current.currentSelectedGameObject == null ||
                EventSystem.current.currentSelectedGameObject != currentlySelected.gameObject)
            {
                currentlySelected.ResetSelection();  // ���� ��� �ʱ�ȭ
                currentlySelected = null;  // //
            }
        }
    }

    // ���콺 �����Ͱ� ��ư ������ ������ ���
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isClicked)
        {
            text_font.color = Color.black;  // ��Ʈ ���� ���������� ����
            text_font.fontStyle = FontStyle.Bold;  // ��Ʈ ��Ÿ���� ����ü�� ����
        }
    }

    // ���콺 �����Ͱ� ��ư �������� ����� ���
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicked)
        {
            text_font.color = originalColor;  // ��Ʈ�� ���� ������ ����
            text_font.fontStyle = originalFontStyle;  // ��Ʈ ��Ÿ���� �⺻���� ����
        }
    }

    // ���콺 Ŭ���� ���� ���
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.ResetSelection();
        }

        isClicked = true;  // Ŭ�� ���θ� true ��
        currentlySelected = this;  // ������ ����� �ڽ�����
        text_font.color = Color.black;  // ��Ʈ ���� ���������� ����
        text_font.fontStyle = FontStyle.Bold;  // ��Ʈ ��Ÿ���� ����ü�� ����
    }

    // ������ ��� �ʱ�ȭ
    private void ResetSelection()
    {
        isClicked = false;  // Ŭ�� ���θ� false ��
        text_font.color = originalColor;  // ��Ʈ ���� ���� ������ ����
        text_font.fontStyle = originalFontStyle;  // ��Ʈ ��Ÿ���� �⺻���� ����
    }
}
