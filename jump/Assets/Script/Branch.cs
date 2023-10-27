using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Branch : MonoBehaviour
{
    void Start()
    {
        InitBranch();
    }

    void Update()
    {
        // ȭ���� ����� �������� ����
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (pos.y < -30)
        {
            Destroy(gameObject);
        }
    }

    // ��������(Branch) �ʱ�ȭ
    void InitBranch()
    {
        // �������� ũ��
        float sx = Random.Range(0.5f, 1);
        // �������� ����
        int x = (Random.Range(0, 2) == 0) ? -1 : 1; // -1 OR 1
        int y = (Random.Range(0, 2) == 0) ? -1 : 1; // -1 OR 1

        // ����� ũ�� ����
        transform.localScale = new Vector3(sx * x, y, 1);
    }
}
