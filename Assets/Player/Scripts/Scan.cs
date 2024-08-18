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
     // ���� �ִ� ��� �ݶ��̴��� �˻��մϴ�.
     Collider[] allColliders = GameObject.FindObjectsOfType<Collider>();
        foreach (Collider collider in allColliders)
        {
            // ������Ʈ�� ���� ��ǥ�� ī�޶��� ����Ʈ ��ǥ�� ��ȯ�մϴ�.
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(collider.transform.position);


            // ����Ʈ ��ǥ�� ��ȿ���� Ȯ���մϴ�.
            if (viewportPos.z > 0 && viewportPos.x >= 0 && viewportPos.x <= 1 && viewportPos.y >= 0 && viewportPos.y <= 1)
            {
                if (!IsObstructed(collider))
                {
                    if (collider.CompareTag("Scrap"))
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            scanSound.Play();
                            // ī�޶��� �þ߿� �ִ� ������Ʈ�� ����Ʈ�� �߰��մϴ�.
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
            // ���̰� ��ǥ ������Ʈ�� �浹�ߴ��� Ȯ���մϴ�.
            if (hit.collider == target)
            {
                return false; // ��ֹ��� �����Ƿ� �������� �ʾҽ��ϴ�.
            }
        }

        return true; // ���̰� ��ǥ ������Ʈ�� ������� �������Ƿ� ������ �ֽ��ϴ�.
    }
}

