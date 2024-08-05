using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    public GameObject img_gameMenu;  // ���� �޴� ȭ�� ����


    void Start()
    {

    }

    void Update()
    {
        // Esc Ű�� ���� �� ���� �޴� ȭ�� Ȱ��ȭ
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            img_gameMenu.gameObject.SetActive(true);
        }
    }


    // ���� �޴� "ȣ��Ʈ" ��ư
    public void Host()
    {
        SceneManager.LoadScene(1);  // ���ӽ���
    }

    // ���� �޴� "����" ��ư
    public void Quit()
    {
#if UNITY_EDITOR
        // 1. �������� ��� �÷��� ��� ����
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. ������ ���ø����̼��� ��� �� ����
        Application.Quit();
#endif
    }

    // ���� �޴�/����� "������" ��ư
    public void Exit()
    {
        SceneManager.LoadScene(0);  // ���� �޴���
    }

    // ���� �޴� "����ϱ�" ��ư
    public void Resume()
    {
        img_gameMenu.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
