using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public List<GameObject> scraps;
    private List<Scrap> scrapComponents;
    Scrap Scrap;
    AudioSource scanSound;

    void Start()
    {
        scraps = new List<GameObject>();
        scrapComponents = new List<Scrap>();
        scanSound = GetComponent<AudioSource>();
    }


    void Update()
    {
     // 씬에 있는 모든 콜라이더를 검사합니다.
     Collider[] allColliders = GameObject.FindObjectsOfType<Collider>();
        foreach (Collider collider in allColliders)
        {
            // 오브젝트의 월드 좌표를 카메라의 뷰포트 좌표로 변환합니다.
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(collider.transform.position);


            // 뷰포트 좌표가 유효한지 확인합니다.
            if (viewportPos.z > 0 && viewportPos.x >= 0 && viewportPos.x <= 1 && viewportPos.y >= 0 && viewportPos.y <= 1)
            {
                if (!IsObstructed(collider))
                {
                    if (collider.CompareTag("Scrap"))
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            scanSound.Play();
                            // 카메라의 시야에 있는 오브젝트를 리스트에 추가합니다.
                            scraps.Add(collider.gameObject);
                            if (scraps[0] != null)
                            {
                                Scrap = scraps[0].GetComponent<Scrap>();
                                Scrap.isScaned = true;
                            }
                            //if (scraps[1] != null)
                            //{
                            //    Scrap = scraps[1].GetComponent<Scrap>();
                            //    Scrap.isScaned = true;
                            //}
                            //if (scraps[2] != null)
                            //{
                            //    Scrap = scraps[2].GetComponent<Scrap>();
                            //    Scrap.isScaned = true;
                            //}
                            //if (scraps[3] != null)
                            //{
                            //    Scrap = scraps[3].GetComponent<Scrap>();
                            //    Scrap.isScaned = true;
                            //}
                            scraps.Clear();
                        }
                    }
                }
            }
        }

        
    }

    private bool IsObstructed(Collider target)
    {
        Ray ray = new Ray(Camera.main.transform.position, target.transform.position - Camera.main.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // 레이가 목표 오브젝트와 충돌했는지 확인합니다.
            if (hit.collider == target)
            {
                return false; // 장애물이 없으므로 가려지지 않았습니다.
            }
        }

        return true; // 레이가 목표 오브젝트를 통과하지 못했으므로 가려져 있습니다.
    }
}

