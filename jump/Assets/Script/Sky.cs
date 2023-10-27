using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{

    Material mat; // 매터리얼
    float speed = 0.05f; // 스크롤링 속도

    void Start()
    {
        mat = GetComponent<Renderer>().material; 
        // 시작할 때, Sky의 매터리얼을 받아옴
    }

    void Update()
    {
        // 매터리얼의 Offset 속성을 받아옴
        Vector2 ofs = mat.mainTextureOffset;
        // Offset.x 를 지정한 속도만큼 누적
        ofs.x += speed * Time.deltaTime;

        // 누적된 연산 결과를 매터리얼에 적용
        mat.mainTextureOffset = ofs;
    }
}
