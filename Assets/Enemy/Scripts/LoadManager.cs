using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    public GameObject img_gameMenu;  // 게임 메뉴 화면 지정


    void Start()
    {

    }

    void Update()
    {
        // Esc 키를 누를 시 게임 메뉴 화면 활성화
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            img_gameMenu.gameObject.SetActive(true);
        }
    }


    // 메인 메뉴 "호스트" 버튼
    public void Host()
    {
        SceneManager.LoadScene(1);  // 게임시작
    }

    // 메인 메뉴 "종료" 버튼
    public void Quit()
    {
#if UNITY_EDITOR
        // 1. 에디터일 경우 플레이 모드 끄기
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. 빌드한 어플리케이션일 경우 앱 종료
        Application.Quit();
#endif
    }

    // 게임 메뉴/사망시 "나가기" 버튼
    public void Exit()
    {
        SceneManager.LoadScene(0);  // 메인 메뉴로
    }

    // 게임 메뉴 "계속하기" 버튼
    public void Resume()
    {
        img_gameMenu.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
