using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{

    Material mat; // ���͸���
    float speed = 0.05f; // ��ũ�Ѹ� �ӵ�

    void Start()
    {
        mat = GetComponent<Renderer>().material; 
        // ������ ��, Sky�� ���͸����� �޾ƿ�
    }

    void Update()
    {
        // ���͸����� Offset �Ӽ��� �޾ƿ�
        Vector2 ofs = mat.mainTextureOffset;
        // Offset.x �� ������ �ӵ���ŭ ����
        ofs.x += speed * Time.deltaTime;

        // ������ ���� ����� ���͸��� ����
        mat.mainTextureOffset = ofs;
    }
}
