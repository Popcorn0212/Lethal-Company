using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public List<string> objectNames;

    void Start()
    {
        objectNames = new List<string>();
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
                                    // ī�޶��� �þ߿� �ִ� ������Ʈ�� �̸��� ����Ʈ�� �߰��մϴ�.
                                    objectNames.Add(collider.gameObject.name);
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

